using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;
using SignalR_Project.Models.ViewModels;
using SignalR_Project.Helpers;

namespace SignalR_Project.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }
        [ForeignKey("FromUser")]
        public string FromUserId { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
        [ForeignKey("ToUser")]
        public string ToUserId { get; set; }
        public virtual ApplicationUser ToUser { get; set; }
        public virtual Room ToRoom { get; set; }
        public int ToRoomId { get; set; }
        public int Stick { get; set; }
    }
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageViewModel>()
                 .ForMember(dst => dst.Id, opt => opt.MapFrom(x => x.Id))
                 .ForMember(dst => dst.From, opt => opt.MapFrom(x => x.FromUser.DisplayName))
                 .ForMember(dst => dst.To, opt => opt.MapFrom(x => x.ToRoom.Name))
                 .ForMember(dst => dst.Avatar, opt => opt.MapFrom(x => x.FromUser.Avatar))
                 .ForMember(dst => dst.Content, opt => opt.MapFrom(x => BasicEmojis.ParseEmojis(x.Content)))
                 .ForMember(dst => dst.Timestamp, opt => opt.MapFrom(x => new DateTime(long.Parse(x.Timestamp)).ToLongTimeString()))
                 .ForMember(dst => dst.Stick, opt => opt.MapFrom(x => x.Stick));
            CreateMap<MessageViewModel, Message>();
        }
    }
}