using FromSql.CoreWeb.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FromSql.CoreWeb.DB.Context
{
    public static class DBInit
    {
        public static void Initialize(FromSqlDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.People.Any())
            {
                return;
            }
            var peopleList = new List<PeopleModel>()
            {
                new PeopleModel() { Name = "张三" },
                new PeopleModel() { Name = "李四" },
                new PeopleModel() { Name = "王五" },
                new PeopleModel() { Name = "赵六" }
            };
            peopleList.ForEach(x => context.Add(x));
            context.SaveChanges();
        }
    }
}
