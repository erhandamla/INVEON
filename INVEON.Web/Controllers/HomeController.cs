using INVEON.Business.Abstract;
using INVEON.Data.UnitOfWork;
using System.Web.Mvc;

namespace INVEON.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public HomeController(IUnitOfWork uow, IProductService productService, IUserService userService) 
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

    }
}