using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class specificationBase<T> : ISpecification<T>
    {
        public specificationBase(Expression<Func<T, bool>> filtro)
        {
            Filtro = filtro;
        }

        public specificationBase()
        {
            
        }

        public Expression<Func<T, bool>> Filtro {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

        protected void AgregarInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}