using AutoMapper;
using Portfolio_Fatnis.Models;
using Portfolio_Fatnis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio_Fatnis.AutoMapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<OperatingSystem, OperationSystemViewModel>().ReverseMap();

            CreateMap<Project, ProjectViewModel>().ReverseMap();
        }
    }
}
