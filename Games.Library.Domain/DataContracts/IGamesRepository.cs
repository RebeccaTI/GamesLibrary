
using Games.Library.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Games.Library.Domain.DataContracts
{
    public interface IGamesRepository
    {
        Task<int> AddGame(Game game);
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetGameById(int id);
        Task<int> UpdateGame(Game game, int id);
        void DeleteGame(int id);
    }
}
