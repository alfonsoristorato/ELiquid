using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ELiquid.Data.Models;
using ELiquid.Data.Services;

namespace ELiquid.Web.Api
{
    public class ElecLiquidsController : ApiController
    {
        private readonly IElecLiquidData db;
        public ElecLiquidsController(IElecLiquidData db)
        {
            this.db = db;
        }
        public IEnumerable<ElecLiquid> Get()
        {
            var model = db.GetAll();
            return model;
        }
    }
}
