namespace finalmetal.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class finalcontext : DbContext
    {
       
        public finalcontext()
            : base("name=finalcontext")
        {
        }

        public virtual DbSet<user>Users { get; set; }
        public virtual DbSet<product>Products { get; set; }

        public virtual DbSet<gmail> ContactViewModels { get; set; }
    }

  
}