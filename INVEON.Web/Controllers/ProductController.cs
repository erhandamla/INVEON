using INVEON.Business.Abstract;
using INVEON.Data.UnitOfWork;
using INVEON.Dtos.ViewModels;
using INVEON.Web.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INVEON.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public ProductController(IUnitOfWork uow, IProductService productService, IUserService userService)
        {
            _uow = uow;
            _productService = productService;
            _userService = userService;
        }
        public ActionResult Index(int id)
        {
            var product = _productService.Find(id);
            var viewModel = new ProductViewModel
            {
                Image = ConvertToBase64(product.Image),
                Barcode = product.Barcode,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                IsActive = product.IsActive,
                InStock = product.InStock,
                CreatedBy = product.CreatedBy
            };

            return View(viewModel);
        }

        public ActionResult List()
        {
            var productList = _productService.GetList().Where(w=>w.IsActive).ToList();
            var list = new List<ProductViewModel>();
            foreach (var product in productList)
            {
                var model = new ProductViewModel
                {
                    Id = product.Id,
                    Image = ConvertToBase64(product.Image),
                    Barcode = product.Barcode,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    IsActive = product.IsActive,
                    InStock = product.InStock,
                    CreatedBy = product.CreatedBy,
                    CreatedDate = product.CreatedDate
                };

                list.Add(model);
            }
            return View(list);
        }

        [IsAdminFilter]
        public ActionResult Update(int id)
        {
            var product = _productService.Find(id);
            var viewModel = new ProductUpdateViewModel
            {
                Barcode = product.Barcode,
                Id = product.Id,
                Description = product.Description,
                ImageBase64 = ConvertToBase64(product.Image),
                Instock = product.InStock,
                IsActive = product.IsActive,
                Name = product.Name,
                Price = product.Price
            };

            return View(viewModel);
        }

        //[IsAdminFilter]
        [HttpPost]
        public ActionResult Update(ProductUpdateViewModel product)
        {
            if (Request.Files["ImageData"].ContentLength !=  0)
            {
                product.Image = ConvertToBytes(Request.Files["ImageData"]);
                product.UpdatedBy = (int)Session.Contents["UserId"];    
            }
            _productService.Update(product);
            return RedirectToAction(nameof(List));
        }

        [IsAdminFilter]
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductInsertViewModel product)
        {
            product.Image = ConvertToBytes(Request.Files["ImageData"]);
            product.CreatedBy = (int)Session.Contents["UserId"];
            _productService.Add(product);
            return RedirectToAction(nameof(List));
        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public string ConvertToBase64(byte[] array)
        {
            return "data:image/jpeg;base64," + Convert.ToBase64String(array, 0, array.Length);
        }

        public ActionResult Delete(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("List", "Product");
        }
    }
}