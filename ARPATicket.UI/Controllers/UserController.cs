using ARPATicket.UI.Models;
using ARPATicket.UI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARPATicket.UI.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserAPIServices _userAPIServices;

        public UserController(IUserAPIServices userAPIServices)
        {
            _userAPIServices = userAPIServices;
        }

        // GET: UserController
        public async Task<ActionResult> Index()
        {
            List<UserDTO> userList = await _userAPIServices.GetAllUsersAsync();
            return View(userList);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserAddDTO newUser)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var createdUser = await _userAPIServices.CreateUserAsync(newUser);
                    if(createdUser != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View(newUser);   
            }
            catch (Exception ex) 
            {
                return View(newUser);
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
