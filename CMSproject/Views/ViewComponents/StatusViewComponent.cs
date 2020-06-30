using CMSproject.Data;
using CMSproject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Views.ViewComponents
{
    public class StatusViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public StatusViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int deviceId)
        {
            var device = await context.Devices.FindAsync(deviceId);

            var model = new Status()
            {
                IsConnected = device.IsConnected
            };

            return View(model);
        }
    }
}
