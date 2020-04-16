using Games.Library.Application.Base;
using Games.Library.Application.Mappers;
using Games.Library.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesLibrary.API.Mappers
{
    public class GameToGameDTO : MapperBase<Game, GameDTO>
    {
        public override GameDTO Map(Game entry)
        {
            return new GameDTO()
            {
                Id = entry.Id,
                Name = entry.Name,
                Release = entry.Release,
                Platforms = entry.Platforms
            };
        }
    }
}
