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

                cfg.CreateMap<Contact, ContactFormBaseViewModel>()
                .ForAllMembers(opt => opt.Condition(r => r != null));
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<ContactType, ContactTypeDto>();

                //Dto's to Domain

                cfg.CreateMap<ContactDto, Contact>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<ContactTypeDto, ContactType>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                ;
            });
        }
    }
}