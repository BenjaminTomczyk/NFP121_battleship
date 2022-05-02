using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Model.Entities;

namespace BattleshipAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class GameController : ControllerBase
	{
		public GameController()
		{
            
		}

        private static readonly string[] Summaries = new[]
{
            "test", "test2", "test3", "test4", "test4", "test5", "test6", "test7", "test8", "test9"
        };

        [HttpGet]
        public Game Get()
        {
            Game game = new Game()
            {
                GridSize = 30
            };

            return game;
        }
    }
}

