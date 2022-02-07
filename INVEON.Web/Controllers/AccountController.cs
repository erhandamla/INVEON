using INVEON.Business.Abstract;
using INVEON.Data.UnitOfWork;
using INVEON.Dtos.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace INVEON.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;

        public AccountController(IUnitOfWork uow, IUserService userService)
        {
            _uow = uow;
            _userService = userService;
        }
        // GET: Account
        public ActionResult Login()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("List","Product");
            }
            return View(new UserLoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            var user = _userService.GetList().Where(w => w.UserName == model.UserName && w.Password == model.Password && w.IsActive).FirstOrDefault();

            if (user != null)
            {
                Session.Add("UserId", user.Id);
                Session.Add("UserName", user.UserName);

                Session.Add("IsAdmin", user.IsAdmin);
            return RedirectToAction("../Product/List");

            }
            else
            {
                TempData["Error"] = "Lütfen kullanıcı adı ve parolanızın doğruluğundan emin olunuz!";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();

            return View(nameof(Login));
        }
    }
}