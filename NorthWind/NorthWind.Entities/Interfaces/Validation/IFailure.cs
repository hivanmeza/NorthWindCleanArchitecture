using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Validation
{
    public interface IFailure
    {
        string PropertyName { get; }
        string ErrorMessage { get; }
    }
}
