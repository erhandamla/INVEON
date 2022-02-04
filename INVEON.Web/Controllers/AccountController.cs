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
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            var user = _userService.GetList().Where(w => w.UserName == model.UserName && w.Password == model.Password && w.IsActive).FirstOrDefault();

            if (user != null)
            {
                Session.Add("UserName", user.UserName);
                Session.Add("IsAdmin", user.IsAdmin);
            }
            return View();
        }
    }
}