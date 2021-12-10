using RESTApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTApi.FileWorker
{
    public interface IOuter
    {
        void setPath(string filename);
        IList<ILot> Read();
        void Add(ILot lot);

        void Change(ILot lot);

        void Del(ILot lot);
    }
}
