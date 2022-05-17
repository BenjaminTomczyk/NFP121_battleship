using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Battleship.Model.Entities;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.IO;
using Battleship.Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Battleship.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Battleship.Logic.Services;

namespace BattleshipAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IShipService _shipService;
        //private readonly IIAService _iaService;

        public GameController(IGameService gameService, IShipService shipService)
        {
            _gameService = gameService;
            _shipService = shipService;
        }

        [HttpGet("start/{id}")]
        public async Task<Game> Game(string id)
        {
            return await _gameService.StartGame(id);
        }

        [HttpGet("history/{id}")]
        public List<PlayerStatisticsModel> GetHistory(string id)
        {
            return _gameService.GetUserHistory(id);
        }

        [HttpGet("history")]
        public List<PlayerStatisticsModel> GetFullHistory()
        {
            return _gameService.GetFullHistory();
        }

        [HttpGet("setIA/{level}")]
        public Game SetGameIA(string level)
        {
            _gameService.SetIAGrid();
            return _gameService.SetGameIA(level);
        }

        [HttpPost("tryShoot")]
        public Explosion TryShoot(Position position)
        {
            return _gameService.UserShoot(position);
        }

        [HttpGet("shootIA")]
        public Explosion ShootIA()
        {
            return _gameService.IAShoot();
        }

        [HttpGet("endGame")]
        public Game VerifEndGame()
        {
            return _gameService.VerifEndGame();
        }
    }
}

