using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;

namespace Projeto.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //-> Auction
        public virtual ICollection<Bid> Bid { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        public virtual ICollection<Address> Address { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<AuctionState> AuctionState { get; set; }
        public DbSet<ArtWork> ArtWork { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Auction> Auction { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Price> Price { get; set;}
        public DbSet<Finality> Finality { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        //public DbSet<PurchasedItem> PurchaseItem { get; set; }
        public ApplicationDbContext()
            : base("VisualArtDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}