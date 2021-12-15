﻿using System.Linq.Expressions;

namespace NorthWind.Entities.Abstractions
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ConditionExpression { get; }
        public bool IsSatisfiedBy(T entity)
        {
            Func<T, bool> ExpressionDelegate = ConditionExpression.Compile();
            return ExpressionDelegate(entity);
        }
    }
}
