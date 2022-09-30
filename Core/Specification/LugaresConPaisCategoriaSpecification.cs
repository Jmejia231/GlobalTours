using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specification
{
    public class LugaresConPaisCategoriaSpecification : specificationBase<Lugar>
    {
        public LugaresConPaisCategoriaSpecification()
        {
            AgregarInclude(x => x.Pais);
            AgregarInclude(x => x.Categoria);
        }

        public LugaresConPaisCategoriaSpecification(int id) : base(x => x.Id == id)
        {
            AgregarInclude(x => x.Pais);
            AgregarInclude(x => x.Categoria);
        }
    }
}