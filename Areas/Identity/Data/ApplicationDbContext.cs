using System;
using System.Linq;
using System.Threading.Tasks;
using Blog.Areas.Identity.Data.Seeder;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Areas.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Category> Category { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Permission> Permission { get; set;}
        public DbSet<PermissionUser> PermissionUser { get; set;}
        
        public DbSet<Tag> Tag { get; set;}
        
        public DbSet<PostTag> PostTag { get; set; }

        public DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            
            //category
            var categoryEntity = builder.Entity<Category>();
            categoryEntity.HasIndex(c => c.Name)
                .IsUnique();
            categoryEntity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(256);
            
            //post
            var postEntity = builder.Entity<Post>();
            postEntity.HasIndex(p => p.Slug)
                .IsUnique();
            postEntity.HasIndex(p => p.Image)
                .IsUnique()
                .HasFilter("[Image] IS NOT NULL");
            
            postEntity.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(256);
            postEntity.Property(p => p.Slug)
                .IsRequired()
               ;
            postEntity.Property(p => p.Body)
                .IsRequired()
                ;

            postEntity.HasMany(p => p.Comments)
                .WithOne(c => c.Post);
            
            //permission
            var permissionEntity = builder.Entity<Permission>();
            permissionEntity.Property(p => p.Name)
                .IsRequired();
            permissionEntity.Property(p => p.DisplayName)
                .IsRequired();
            
            //permission user
            var permissionUserEntity = builder.Entity<PermissionUser>();
            permissionUserEntity.HasIndex("PermissionId", "UserId")
                .IsUnique();
            
            //Tag
            var tagEntity = builder.Entity<Tag>();
            tagEntity.HasIndex(t => t.Name).IsUnique();
            tagEntity.Property(t => t.Name).IsRequired();
            
            //post tag
            var postTagEntity = builder.Entity<PostTag>();
            postTagEntity.HasIndex("PostId", "TagId").IsUnique();

            // postTagEntity.HasOne(pt => pt.Post)
            //     .WithMany(p => p.PostTags)
            //     .HasForeignKey(pt => pt.PostId);
            //
            // postTagEntity.HasOne(pt => pt.Tag)
            //     .WithMany(t => t.PostTags)
            //     .HasForeignKey(pt => pt.TagId);
            
            
            //comment
            var commentEntity = builder.Entity<Comment>();
            commentEntity.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);
            commentEntity.Property(c => c.Name)
                .HasMaxLength(255);
            commentEntity.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);
            
            commentEntity.HasOne(c => c.Post)
                .WithMany(p => p.Comments);
            
            
            /*
             * start seeders
             */
            
            //permission seeder
            //example of tuple
            (Permission[] permissionList, PermissionUser[] permissionUsers) = PermissionAndUserPermissionSeederData.Data();
            permissionEntity.HasData(permissionList);
            permissionUserEntity.HasData(permissionUsers);
            
            //role seeder
            (IdentityRole[] roles, IdentityUserRole<string>[] userRoles) = RoleAndUserRoleSeederData.Data();
            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        
        }
    }
}
