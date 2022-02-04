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
        public ActionResult Index()
        {
            var product = _productService.GetList();
            var users = _userService.GetList();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            var productList = _productService.GetList();
            return View(productList);
        }

        [IsAdminFilter]
        public ActionResult Update(int id)
        {
            var productList = _productService.GetList();
            return View(productList);
        }

        [IsAdminFilter]
        [HttpPost]
        public ActionResult Update(ProductUpdateViewModel product)
        {
            _productService.Update(product);
            return View(nameof(Update));
        }
    }
}