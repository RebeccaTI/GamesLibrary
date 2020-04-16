using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Games.Library.Application.Interfaces;
using Games.Library.Application.Mappers;
using Games.Library.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GamesLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gamesService;
        private readonly GameDTOToGame _gameDTOToGame;

        public GameController(IGameService gamesService, GameDTOToGame gameDTOToGame)
            
        {
            _gamesService = gamesService;
            _gameDTOToGame = gameDTOToGame;
           
        }
        
       [HttpPost]
        public async Task<ActionResult<GameDTO>> AddGame([FromBody] GameDTO gameDTO)
        {
            var dto = _gameDTOToGame.Map(gameDTO);
            var result = await _gamesService.AddGame(dto);          
            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult<GameDTO>> GetAll()
        {
            var result = await _gamesService.GetAll();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<GameDTO>> GetGameById(int id)
        {
            var result = await _gamesService.GetGameById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame([FromRoute] int id, [FromBody] GameDTO gameDTO)
        {
            var dto = _gameDTOToGame.Map(gameDTO);
            var result = await _gamesService.UpdateGame(dto, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<Game> DeleteGame(int id)
        {
             _gamesService.DeleteGame(id);
            return Ok();
        }

    }
}