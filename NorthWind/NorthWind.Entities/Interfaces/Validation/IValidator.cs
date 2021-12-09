using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Entities.Interfaces.Validation
{
    public interface IValidator<T>
    {
        IRule<T> AddRuleFor<TProperty>(
            Expression<Func<T,TProperty>> expression,
            bool StopOnFirtFailure);

        bool Validate(T instance);

        List<IFailure> Failures { get; }
        List<IFailure> SetValidatorFor<ItemsType>(IEnumerable<ItemsType> items,
            IValidator<ItemsType> validator);
        IValidationService<T> ServiceValidator { get; }
    }
}
