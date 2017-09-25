using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MOBYNew.Models;
using MOBYNew.ViewModels;
using AutoMapper;

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
            });
        }
    }
}