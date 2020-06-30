using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Models.ViewModels
{
    public class DeviceCreate
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
