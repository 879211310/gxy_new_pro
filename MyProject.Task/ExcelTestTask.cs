using MyProject.Core.Entities;
using MyProject.Data.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Task
{
    public class ExcelTestTask
    {
        private readonly ExcelTestDao _dao = new ExcelTestDao();
        public void Add(ExcelTest excel)
        {
            _dao.Add(excel);
        }
    }
}
