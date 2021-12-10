using RESTApi.Model;
using System;

namespace RESTApi
{
    public class Lot:ILot
    {
        
        public int ID { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
    }
}
