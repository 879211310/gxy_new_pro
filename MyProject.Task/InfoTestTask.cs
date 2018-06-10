using MyProject.Core.Entities;
using MyProject.Data.Daos;
using MyProject.Services.MvcPager;
using MyProject.Services.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Task
{
    public class InfoTestTask
    {
        private readonly InfoTestDao _dao = new InfoTestDao();

        //分页查询
        public PagedList<InfoTest> GetPagedList(int pageIndex, int pageSize)
        {
            return  _dao.GetPagedList(pageIndex, pageSize);
        }

        //列表查询
        public List<InfoTest> GetList()
        {
            return _dao.GetList();
        }

        //查找信息
        public InfoTest GetInfoTest(int id)
        {
            return _dao.GetInfoTest(id);
        }

        //更新
        public void UpdateInfoTest(int age)
        {
            _dao.UpdateInfoTest(age);
        }
        public void UpdateInfoTest()
        {
            var infoTest = new InfoTest();//也可以是实体
            _dao.Update(infoTest);
        }

        //删除
        public void DelInfoTest(int id)
        {
            _dao.DelInfoTest(id);
        }

        //添加
        public void AddInfoTest(InfoTest infoTest)
        {
            _dao.Add(infoTest);
        }
    }
}
