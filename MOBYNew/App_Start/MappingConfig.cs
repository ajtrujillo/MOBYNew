using MOBYNew.Models;
using MOBYNew.ViewModels;
using AutoMapper;
using MOBYNew.DTOs;

namespace MOBYNew.App_Start
{
    public static class MappingConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                //Domain to Dto

                cfg.CreateMap<Contact, ContactDto>()
                .ForAllMembers(opt => opt.Condition(r => r != null));
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<ContactType, ContactTypeDto>();
                cfg.CreateMap<Item, ItemDto>();
                cfg.CreateMap<ItemCategory, ItemCategoryDto>();
                cfg.CreateMap<ItemGenre, ItemGenreDto>();

                //Dto's to Domain

                cfg.CreateMap<ContactDto, Contact>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<ContactTypeDto, ContactType>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<ItemDto, Item>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<ItemCategoryDto, ItemCategory>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<ItemGenreDto, ItemGenre>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
            });
        }
    }
}