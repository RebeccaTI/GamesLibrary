 using Dapper;
using Games.Library.Domain.DataContracts;
using Games.Library.Domain.Model;
using Games.Library.Infra.SQL.Intefaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Games.Library.Infra.SQL.Repository
{
    public class GamesRepository : IGamesRepository
    {

        private readonly IDbConnection _connection;
                
        public GamesRepository(IConnectionFactory factory)
        {
            _connection = factory.Connection();
        }

        public async Task<int> AddGame(Game game)
        {
            //game.Id = Guid.NewGuid()

           
                string sQuery = @"Insert into dbo.Game (Name, Release, Platforms) Values (@Name, @Release, @Platforms)";
                var result = await _connection.ExecuteAsync(sQuery, new { game.Name, game.Release, game.Platforms });
                return result;

        }
        public async Task<IEnumerable<Game>> GetAll()
        {           
                string sQuery = @"Select * from dbo.Game";
                var result = await _connection.QueryAsync<Game>(sQuery);
                return result;           
        }

        public async Task<Game> GetGameById(int id)
        {
                string sQuery = @"Select * from dbo.Game where Id = @Id";
                var result = await _connection.QueryFirstOrDefaultAsync<Game>(sQuery, new { Id = id});
                return result;
        }
          public async Task<int> UpdateGame(Game game, int id)
        {
                string sQuery = @"Update dbo.Game Set Name=@Name, Release=@Release, Platforms=@Platforms where Id=@Id";
                var result = await _connection.ExecuteAsync(sQuery, new { Id = id, game.Name, game.Release, game.Platforms });
                return result;
        }

        public async void DeleteGame(int id)
        {         
                string sQuery = @"Delete from dbo.Game where Id=@Id";
                await _connection.ExecuteAsync(sQuery, new { Id = id});
            
        }
    }
}
