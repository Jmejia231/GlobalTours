using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ILugarRepositorio
    {
        // firmas de Nuestros Metodos

        Task<Lugar> GetLugarAsync(int id);

        Task<IReadOnlyList<Lugar>> GetLugaresAsync();
        
    }
}