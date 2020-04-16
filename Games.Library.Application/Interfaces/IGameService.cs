using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Games.Library.Domain.Model;

namespace Games.Library.Application.Interfaces
{
    public interface IGameService
    {
        Task<int> AddGame(Game game);
        Task<IEnumerable<Game>> GetAll();
        Task<Game> GetGameById(int id);
        Task<int> UpdateGame(Game game, int id);
        void DeleteGame(int id);
    }
}
