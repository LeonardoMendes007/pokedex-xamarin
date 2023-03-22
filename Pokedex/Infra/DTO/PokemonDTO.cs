using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Infra.DTO
{
    public class PokemonDTO
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
