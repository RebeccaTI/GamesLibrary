using Games.Library.Application.Interfaces;
using Games.Library.Domain.DataContracts;
using Games.Library.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Games.Library.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGamesRepository _gamesRepository;

        public GameService(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<int> AddGame(Game game)
        {
            return await _gamesRepository.AddGame(game);
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            return await _gamesRepository.GetAll();
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _gamesRepository.GetGameById(id);
        }
        public void DeleteGame(int id)
        {
            _gamesRepository.DeleteGame(id);
        }

        public async Task<int> UpdateGame(Game game, int id)
        {
            //var result  = await _gamesRepository.UpdateGame(game, id);
            // return result;
            return await _gamesRepository.UpdateGame(game, id);
        }
    }
}


