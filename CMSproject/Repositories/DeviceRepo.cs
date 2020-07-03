using AutoMapper;
using CMSproject.Data;
using CMSproject.Models;
using CMSproject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Repositories
{
    public class DeviceRepo : IDeviceRepo
    {
        private readonly ApplicationDbContext context;

        public DeviceRepo(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Device> GetAllDevices()
        {
            return context.Devices.AsQueryable();
        }

        public async Task<Device> GetDeviceAsync(int id)
        {
            return await context.Devices.FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Add(Device device)
        {
            context.Add(device);
        }

        public void Remove(Device device)
        {
            context.Remove(device);
        }

        public void Update(Device device)
        {
            context.Update(device);
        }
    }
}
