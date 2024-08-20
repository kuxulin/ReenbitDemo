using AutoMapper;
using Core.Models;
using Core.Models.ViewModels;

namespace Core.Extensions;

public class MappingProfile :Profile
{
    public MappingProfile()
    {
        CreateMap<Message, MessageGetViewModel>()
            .ForMember(mv => mv.AuthorName, options => options.MapFrom(m => m.Author.UserName))
            .ForMember(mv => mv.CreatedAt, options => options.MapFrom(m => m.CreatedDate));
        CreateMap<Chat, ChatGetViewModel>()
            .ForMember(c => c.FirstUserName, options => options.MapFrom(m => m.FirstUser.UserName))
            .ForMember(c => c.SecondUserName, options => options.MapFrom(m => m.SecondUser.UserName));
    }
}
