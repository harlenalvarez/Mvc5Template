using Mvc5Template.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc5Template.App_Code.DataAccess
{
    public class ApplicationIdentityInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        public delegate void InitializerDelegate();
        private InitializerDelegate initDB;

        public void AddInit(InitializerDelegate initializer)
        {
            initDB += initializer;
        }

        public void RemoveInit(InitializerDelegate initializer)
        {
            initDB -= initializer;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            initDB();
            base.Seed(context);
        }

       
    }
}