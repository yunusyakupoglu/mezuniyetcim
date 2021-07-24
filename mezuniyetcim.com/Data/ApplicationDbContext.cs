using mezuniyetcim.com.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace mezuniyetcim.com.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<tblProductCategory> productCategories { get; set; }
        public DbSet<tblProduct> products { get; set; }
        public DbSet<tblProductImage> productImages { get; set; }
        public DbSet<tblVizyon> vizyons { get; set; }
        public DbSet<tblMisyon> misyons { get; set; }
        public DbSet<tblAddress> addresses { get; set; }
        public DbSet<tblPhone> phones { get; set; }
        public DbSet<tblMail> mails { get; set; }
        public DbSet<Events> events { get; set; }

    }
}
