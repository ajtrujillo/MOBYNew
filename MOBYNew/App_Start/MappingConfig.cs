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
                cfg.CreateMap<Contact, ContactFormBaseViewModel>()
                .ForAllMembers(opt => opt.Condition(r => r != null));
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<ContactDto, Contact>();
                cfg.CreateMap<ContactType, ContactTypeDto>();
            });
        }
    }
}