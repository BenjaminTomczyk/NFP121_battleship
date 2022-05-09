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

namespace BattleshipAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public void Game()
        {
        }


    }
}

