using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Services.Interfaces
{
    public interface IPredictService
    {
        Task<string> IdentificarPokemon(string path);
    }
}
