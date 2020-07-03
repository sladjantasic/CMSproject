using AutoMapper;
using CMSproject.Controllers;
using CMSproject.Data;
using CMSproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace CMSprojectTests
{
    public class DeviceControllerTests
    {
        private readonly DevicesController deviceController;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public DeviceControllerTests(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            deviceController = new DevicesController(this.context, this.mapper, this.userManager);
        }
        [Fact]
        public void Test1()
        {

        }
    }
}
