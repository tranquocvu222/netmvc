namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebFirst : DbContext
    {
        public WebFirst()
            : base("name=WebFirst")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public IOrderedQueryable<User> User { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
