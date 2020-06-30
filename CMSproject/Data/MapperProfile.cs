using AutoMapper;
using CMSproject.Models;
using CMSproject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Device, DeviceIndex>();
            CreateMap<DeviceCreate, Device>();
            CreateMap<Device, DeviceRemove>();
        }
    }
}
