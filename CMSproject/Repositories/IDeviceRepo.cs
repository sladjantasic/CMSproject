using CMSproject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Repositories
{
    public interface IDeviceRepo
    {
        void Add(Device device);
        IQueryable<Device> GetAllDevices();
        Task<Device> GetDeviceAsync(int id);
        void Remove(Device device);
        void Update(Device device);
    }
}