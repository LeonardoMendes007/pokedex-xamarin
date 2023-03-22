using PCLExt.FileStorage.Folders;
using Pokedex.Infra.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Infra.Data
{
    public class ApplicationContext
    {
        public SQLiteConnection conexao;
        public ApplicationContext()
        {
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("pokedexdb", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
            conexao = new SQLiteConnection(arquivo.Path);
            conexao.CreateTable<PokemonDTO>();
        }

        public void Insert<T>(T model)
        {
            conexao.Insert(model);
        }

    }
}
