using Microsoft.AspNetCore.Mvc;
using RESTApi.FileWorker;
using RESTApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApi.Controllers
{
    public class LotControl : ILotControl
    {
         

        private IOuter outer;
        public void setValues(IOuter outer) => this.outer = outer;
        public Result Delete(ILot lot)
        {
            if (lot == null)
            {
                return Result.Error;
            }
            if (lot.ID == 0)
            {
                return Result.Error;
            }
            Task.Run(() => outer.Del(lot));
            return Result.Ok;
        }

        public IList<ILot> Get()
        {
            return outer.Read();
        }

        public Result Post(ILot lot)
        {
            if (lot == null)
            {
                return Result.Error;
            }

            Task.Run(() => outer.Add(lot));
            return Result.Ok;
        }

        public Result Put(ILot lot)
        {
            if (lot == null)
            {
                return Result.Error;
            }
            
            Task.Run(() => outer.Change( lot));
            return Result.Ok;
        }
    }
}
