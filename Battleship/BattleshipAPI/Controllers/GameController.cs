﻿using System;
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

namespace BattleshipAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IShipService _shipService;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameController(IGameService gameService, IShipService shipService, UserManager<ApplicationUser> userManager)
        {
            _gameService = gameService;
            _shipService = shipService;
            _userManager = userManager;
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
            Game game = _gameService.GetGame(id);
            _shipService.setCurrentGame(game);
            return game;
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
    }
}

