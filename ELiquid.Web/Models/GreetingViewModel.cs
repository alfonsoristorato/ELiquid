using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ELiquid.Data.Models;

namespace ELiquid.Web.Models
{
    public class GreetingViewModel
    {
        public IEnumerable<ElecLiquid> ElecLiquid { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }

    }
}