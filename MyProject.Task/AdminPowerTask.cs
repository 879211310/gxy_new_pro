﻿using System;
using System.Collections.Generic;
using MyProject.Core.Entities;
using MyProject.Data.Daos;
namespace MyProject.Tasks
{
	/// <summary>
	///
	/// </summary>
	public class AdminPowerTask
	{
		private readonly AdminPowerDao _adminPower = new AdminPowerDao();

	    public AdminPower Get(string controllerName, string actionName)
	    {
	        return _adminPower.Get(controllerName, actionName);
	    }

	    public List<AdminPower> GetListByMenuId(int menuId)
	    {
	        return _adminPower.GetListByMenuId(menuId);
	    }

	    public void Add(AdminPower info)
	    {
	        _adminPower.Add(info);
	    }

	    public void DeleteByPowerId(int powerId)
	    {
	        _adminPower.DeleteByPowerId(powerId);
	    }

	    public List<AdminPower> GetAll()
	    {
	        return _adminPower.GetAll();
	    }
	}
}

