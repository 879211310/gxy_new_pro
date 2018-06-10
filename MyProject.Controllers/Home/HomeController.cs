using System.Linq;
using System.Web.Mvc;
using MyProject.Controllers.SysManage.ViewModels;
using MyProject.Core.Entities;
using MyProject.Tasks;
using MyProject.Services.Mappers;

namespace MyProject.Controllers.Home
{
    public class HomeController : BaseController
    {
        private readonly AdminUserTask _adminUserTask = new AdminUserTask();
        private readonly AdminRoleMenuTask _roleMenuTask = new AdminRoleMenuTask();
        private readonly AdminMenuTask _menusTask = new AdminMenuTask();

        public ActionResult Index()
        {
            var userPassword = _adminUserTask.GetByUserName(LogOnUserName);
            var menuIds = _roleMenuTask.GetListByRoleId(userPassword.RoleId)
                .Select(c => c.MenuId).ToList();
            return View();
        }

        public ActionResult Menu()
        {
            var userPassword = _adminUserTask.GetByUserName(LogOnUserName);
            var menus = _roleMenuTask.GetMenuLstByRoleId(userPassword.RoleId)
                .Select(EntityMapper.Map<AdminMenu, MenuModel>)
                .OrderBy(c => c.SortOrder)
                .ToList();
            return View(menus);
        }

        public ActionResult FirstIndex()
        {
            return View();
        }
    }
}