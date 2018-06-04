using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using SaniShop.Models;
using SaniShop.DAL;
using System.Web.Mvc;

namespace SaniShop.App_Start
{
    public static class MapperConfig
    {
        public static void Main()
        {
            AutoMapper.Mapper.Initialize(config => {
                config.CreateMap<RegiterModal, Regitration>();
                config.CreateMap<PurchasemasterModal, SelectListItem>().ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.supplier_Name.ToString()));
                config.CreateMap<Source, Destination>().ForMember(dest => dest.Total, opt => opt.ResolveUsing<CustomResolver>());                
            });
        }
    }
}