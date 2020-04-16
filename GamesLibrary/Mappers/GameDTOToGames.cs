using Games.Library.Application.Base;
using Games.Library.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Library.Application.Mappers
{
    public class GameDTOToGame : MapperBase<GameDTO, Game>
    {
        public override Game Map(GameDTO gameDTO)
        {
            return new Game()
            {
                Id = gameDTO.Id,
                Name = gameDTO.Name,
                Release = gameDTO.Release,
                Platforms = gameDTO.Platforms
            };
        }
    }
}
