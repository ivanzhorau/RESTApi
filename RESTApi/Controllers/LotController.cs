using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTApi.FileWorker;
using RESTApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LotController : ControllerBase
    {
        

        private readonly ILogger<LotController> _logger;

        private ILotControl lotControl;
        public LotController(ILogger<LotController> logger)
        {
            _logger = logger;
            lotControl = new LotControl();
            IOuter jsout = new JSONOuter();
            jsout.setPath("D:\\00Sprobniki\\RESTApi\\RESTApi\\FileWorker\\json.json");
            lotControl.setValues(jsout);

        }

        [HttpGet]
        public IList<ILot> Get()
        {
            return lotControl.Get();
        }

        [HttpPost]
        public ActionResult<ILot> Post(ILot lot) //add new value
        {
            if (lotControl.Post(lot) == Result.Error)
            {
                return BadRequest();
            }
            return Ok(lot);
        }
        [HttpPut]
        public  ActionResult<ILot> Put(ILot lot) //change value
        {
            if (lotControl.Put(lot) == Result.Error)
            {
                return BadRequest();
            }
            return Ok(lot);
        }


        [HttpDelete]
        public ActionResult<ILot> Delete(ILot lot) //delete value
        {
            if (lotControl.Delete(lot) == Result.Error) {
                return BadRequest();
            }
           return  Ok(lot);

        }
    }
}
