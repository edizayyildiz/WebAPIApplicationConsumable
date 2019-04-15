using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIApplicationConsumable.Models;

namespace WebAPIApplicationConsumable.Controllers
{
    public class CategoryController : ApiController
    {
        public IEnumerable<Category> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Categories.ToList();
            }
        }
        public bool Post([FromBody]Category category)
        {
            using (var db = new ApplicationDbContext())
            {
                try
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
