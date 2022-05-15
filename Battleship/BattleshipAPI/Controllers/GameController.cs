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

        [HttpGet("{id}")]
        public async Task<Game> Game(string id)
        {
            _gameService.SetIA();
            return await _gameService.StartGame(id);
        }

        [HttpGet("get/{id}")]
        public Game GetGame(int id)
        {
            return _shipService.setCurrentGame(id);
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

        [HttpPost("setIA")]
        public Game SetGameIA(string level)
        {
            //_gameService.setIAGrid();
            return _gameService.SetGameIA(level);
        }

        [HttpPost("tryShoot")]
        public bool TryShoot(Position position)
        {
            return _gameService.TryShoot(position);
        }
    }
}

