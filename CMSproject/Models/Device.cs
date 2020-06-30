using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSproject.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsConnected { get; set; }

        //Foreign key
        public string UserId { get; set; }

        //Navigation property
        public User User { get; set; }

    }
}
