using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaniShop.Models;

namespace SaniShop
{
    public class CustomResolver : IValueResolver<Source, Destination, int>
    {
        public int Resolve(Source source, Destination destination, int member, ResolutionContext context)
        {
            return source.Value1 + source.Value2;
        }

    }
}