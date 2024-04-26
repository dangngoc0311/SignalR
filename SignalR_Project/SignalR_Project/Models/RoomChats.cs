using AutoMapper;
using SignalR_Project.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SignalR_Project.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public virtual ApplicationUser UserAccount { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<UserRoom> UserRoom { get; set; }
    }
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();
        }
    }
}