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

namespace BattleshipAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameController(IGameService gameService, UserManager<ApplicationUser> userManager)
        {
            _gameService = gameService;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<Game> Game(string id)
        {
            _gameService.SetIA();
            return await _gameService.StartGame(id);
        }
    }
}

