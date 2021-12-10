using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApi.Model
{
    public interface ILot
    {
        int ID { get; set; }
        string Text { get; set; }
        string ImagePath { get; set; } 

    }
}
