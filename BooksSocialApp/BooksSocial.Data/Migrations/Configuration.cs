namespace BooksSocial.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using System.Web;
    using System.Text;
    using System.Globalization;
    using Microsoft.AspNet.Identity.EntityFramework;
    using BooksSocial.Models;
    using BooksSocial.Data;
    using Microsoft.AspNet.Identity;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
	
    public sealed class Configuration : DbMigrationsConfiguration<BooksSocial.Data.BooksSocialDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
		
		protected override void Seed(BooksSocialDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }
		
        public static void InitializeIdentityForEF(BooksSocialDbContext db)
        {
            var userStore = new UserStore<User>(db);
            var userManager = new UserManager<User>(userStore);

            var roleStore = new RoleStore<IdentityRole>(db);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole { Name = "Admin" });

            var user = new User { UserName = "admin", Email = "admin@gmail.com", PasswordHash = new PasswordHasher().HashPassword("#Lo6omie") };
            db.Users.Add(user);
            db.SaveChanges();
            string userId = db.Users.Where(x => x.Email == "admin@gmail.com" && string.IsNullOrEmpty(x.SecurityStamp))
                .Select(x => x.Id).FirstOrDefault();

            if (!string.IsNullOrEmpty(userId)) userManager.UpdateSecurityStamp(userId);

            userManager.AddToRole(db.Users.Where(u => u.UserName == user.UserName).Select(i => i.Id).FirstOrDefault(), "Admin");
            
        }
    }
}
