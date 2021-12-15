using NorthWind.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces
{
    public interface ILogWritableRepository:IUnitOfWork
    {
        void Add(Log log);
        void Add(string description);
        
    }
}
