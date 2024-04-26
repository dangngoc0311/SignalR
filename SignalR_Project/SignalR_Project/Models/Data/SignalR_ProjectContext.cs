using Microsoft.AspNet.Identity.EntityFramework;
using SignalR_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalR_Project.Models.Data
{
    public class SignalR_ProjectContext : IdentityDbContext<ApplicationUser>
    {
        public SignalR_ProjectContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<UserRoom> UserRooms { get; set; }
        public static SignalR_ProjectContext Create()
        {
            return new SignalR_ProjectContext();
        }
    }
}
