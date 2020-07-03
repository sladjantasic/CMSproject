using System.Threading.Tasks;

namespace CMSproject.Repositories
{
    public interface IWorkUnit
    {
        IDeviceRepo DeviceRepo { get; }

        Task SaveChangesAsync();
    }
}