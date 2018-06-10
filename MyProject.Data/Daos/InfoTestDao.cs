using MyProject.Core.Entities;
using MyProject.Services.MvcPager;
using MyProject.Services.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Daos
{
    [DbFactory("MyP")]
    public class InfoTestDao : BaseDao<InfoTest>
    {
        //分页查询
        public PagedList<InfoTest> GetPagedList(int pageIndex, int pageSize)
        {
            var sql = Sql.Builder.Where("1=1");
            return PagedList<InfoTest>(pageIndex,pageSize,sql);
        }
        //列表查询
        public List<InfoTest> GetList()
        {
            var sql = Sql.Builder.Where("1=1");
            return Query<InfoTest>(sql).ToList();
        }
        //查找信息
        public InfoTest GetInfoTest(int id)
        {
            var sql = Sql.Builder.Where("Id=@0",id);
            return FirstOrDefault(sql);
        }

        //更新
        public void UpdateInfoTest(int age)
        { 
            var sql = Sql.Builder.Append("update InfoTest set Age=@0", age);
            this.Update(sql);
        }

        //删除
        public void DelInfoTest(int id)
        {
            var sql = Sql.Builder.Where("Id=@0",id);
            this.Delete(sql);
        }
    }
}
