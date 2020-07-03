using CMSproject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Repositories
{
    public class WorkUnit : IWorkUnit
    {
        private readonly ApplicationDbContext context;
        public IDeviceRepo DeviceRepo { get; private set; }

        public WorkUnit(ApplicationDbContext context)
        {
            this.context = context;
            DeviceRepo = new DeviceRepo(context);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
