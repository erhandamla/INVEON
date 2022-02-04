using INVEON.Business.Abstract;
using INVEON.Data.UnitOfWork;
using INVEON.Dtos.ViewModels;
using INVEON.Web.Filters;
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
            return View(product);
        }

        public ActionResult List()
        {
            var productList = _productService.GetList();
            return View(productList);
        }

        //[IsAdminFilter]
        public ActionResult Update(int id)
        {
            var product = _productService.Find(id);
            var viewModel = new ProductUpdateViewModel
            {
                Barcode = product.Barcode,
                Id = product.Id,
                Description = product.Description,
                Image = product.Image,
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
            _productService.Update(product);
            return RedirectToAction(nameof(List));
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(ProductInsertViewModel product)
        {
            product.CreatedBy = (int)Session.Contents["UserId"];
            _productService.Add(product);
            return RedirectToAction(nameof(List));
        }
    }
}