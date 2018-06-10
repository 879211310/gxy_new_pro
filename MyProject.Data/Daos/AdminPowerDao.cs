using System;
using System.Collections.Generic;
using System.Linq;
using MyProject.Services.ORM;
using MyProject.Core.Entities;
namespace MyProject.Data.Daos
{
	/// <summary>
	/// 
    /// </summary> 
    [DbFactory("MyP")]
	public class AdminPowerDao : BaseDao<AdminPower>
	{
	    public AdminPower Get(string controllerName, string actionName)
	    {
	        var sql = Sql.Builder
	            .Where("Controller =@0 AND Action = @1", controllerName, actionName);
	        return FirstOrDefault(sql);
	    }

	    public List<AdminPower> GetListByMenuId(int menuId)
	    {
	        var sql = Sql.Builder.Where("MenuId = @0", menuId);
	        return Query(sql).ToList();
	    }

	    public void DeleteByPowerId(int powerId)
	    {
	        var sql = Sql.Builder.Where("PowerId = @0", powerId);
	        Delete(sql);
	    }

	    public List<AdminPower> GetAll()
	    {
	        var sql = Sql.Builder.Where("1=1");
	        return Query(sql).ToList();
	    }
	}
}

