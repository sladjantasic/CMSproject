using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMSproject.Data;
using CMSproject.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using CMSproject.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using CMSproject.Repositories;

namespace CMSproject.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;
        private readonly IWorkUnit workUnit;

        public DevicesController(IMapper mapper, UserManager<User> userManager, IWorkUnit workUnit)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.workUnit = workUnit;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            if (userManager.GetUserAsync(User).Result.FirstName == null)
            {
                return Redirect("/Identity/Account/FirstLogin");
            }
                
            var viewModel = await mapper.ProjectTo<DeviceIndex>(workUnit.DeviceRepo.GetAllDevices()).ToListAsync();

            return View(viewModel);
        }

        // GET: Devices/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var device = await _context.Devices
        //        .Include(d => d.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (device == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(device);
        //}

        // GET: Devices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceCreate viewModel)
        {
            var model = mapper.Map<Device>(viewModel);
            model.UserId = userManager.GetUserId(User);
            model.IsConnected = false;

            if (ModelState.IsValid)
            {
                workUnit.DeviceRepo.Add(model);
                await workUnit.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Devices/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var device = await _context.Devices.FindAsync(id);
        //    if (device == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", device.UserId);
        //    return View(device);
        //}

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Description,IsConnected,UserId")] Device device)
        //{
        //    if (id != device.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(device);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!DeviceExists(device.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", device.UserId);
        //    return View(device);
        //}

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = mapper.Map<DeviceRemove>(await workUnit.DeviceRepo.GetDeviceAsync((int)id));

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await workUnit.DeviceRepo.GetDeviceAsync(id);
            workUnit.DeviceRepo.Remove(device);
            await workUnit.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool DeviceExists(int id)
        //{
        //    return _context.Devices.Any(e => e.Id == id);
        //}

        public async Task<IActionResult> ToggleDeviceStatus(int id)
        {
            var device = await workUnit.DeviceRepo.GetDeviceAsync(id);
            device.IsConnected = !device.IsConnected;
            workUnit.DeviceRepo.Update(device);
            await workUnit.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
