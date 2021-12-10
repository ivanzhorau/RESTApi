using Microsoft.AspNetCore.Mvc;
using RESTApi.FileWorker;
using RESTApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApi.Controllers
{
    public enum Result { 
        Ok,
        Error
    }
    public interface ILotControl
    {
        void setValues(IOuter outer);
        IList<ILot> Get();
        Result Post(ILot lot);
        Result Put(ILot lot);
        Result Delete(ILot lot);

    }
}
