using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuoteApp.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuoteApp.Db
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
