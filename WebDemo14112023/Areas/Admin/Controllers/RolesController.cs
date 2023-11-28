using DatabaseFirstDemo.Models;
using DatabaseFirstDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebDemo14112023.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : BaseController
    {
        private readonly ProductMangementBatch177Context _context;

        IRolesRepository rolesRepository = null;
        public RolesController()
        {
            rolesRepository = new RolesRepository();
        }


        // GET: Admin/Roles
        public IActionResult Index()
        {
            var result = rolesRepository.GetAll();
            return View(result);
            /* return result != null ?
                          View(await result) :
                          Problem("Entity set 'ProductMangementBatch177Context.Roles'  is null.");*/
        }

        // GET: Admin/Roles/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Admin/Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Role role)
        {
            try
            {
                /*         if (ModelState.IsValid)
                         {*/
                rolesRepository.Insert(role);
                SetAlert("Insert Data is success!", "success");
                return Json(new { success = true });
                /*}*/
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = false });
        }

        // GET: Admin/Roles/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Role role = rolesRepository.GetById(id);
            var data = new
            {
                Id = role.Id,
                Name = role.Name
                // Các trường khác
            };

            return new JsonResult(new { success = true, data = data });
        }

        [HttpPost]
        public JsonResult Edit(Role role)
        {
            try
            {
                /*  if (ModelState.IsValid)
                  {*/
                rolesRepository.Update(role);
                SetAlert("Update Data is success!", "success");
                /*}*/
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult Delete(Role role)
        {
            try
            {
                rolesRepository.Delete(role);
                SetAlert("Delete Data is success!", "success");

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            return Json(new { success = true });
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
