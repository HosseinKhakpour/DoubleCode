using DoubleCode.Domain.Entities.Articles;
using DoubleCode.Domain.Entities.Users;
using DoubleCode.Domin.Entities.Tags;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleCode.Infrastructure.Context
{
    public class DoubleCodeContext : IdentityDbContext<User>
    {
        public DoubleCodeContext(DbContextOptions<DoubleCodeContext> options) : base(options)
        {

        }
    
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleGroup> ArticleGroup { get; set; }
        public DbSet<ArticleTag> ArticleTag { get; set; }
        public DbSet<ArticleComment> ArticleComment { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Article>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<ArticleGroup>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<ArticleTag>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<ArticleComment>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Tag>().HasQueryFilter(u => !u.IsDeleted);

            #region SeedData

            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = 1,
            //    IsBlocked = false,
            //    AvatarImageName = "profile.png",
            //    CreateDate = new DateTime(2021, 12, 24, 13, 23, 00),
            //    Email = "hosseinKhakpoor@gmail.com",
            //    UserName = "Admin",
            //    IsEmailActive = true,
            //    Password = "ACzGe/muivlpjt6DH0gaVdzHp0y+h4xgJmT84gKoacZ6ImLRt0zpgRfBElJd1ZBF+Q==",//123 or 1234,
            //    IsDeleted = false,
            //});

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}