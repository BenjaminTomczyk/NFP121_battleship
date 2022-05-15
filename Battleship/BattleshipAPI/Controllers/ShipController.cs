using System;
using System.Threading.Tasks;
using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace BattleshipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : Controller
    {
        private readonly IShipService _shipService;
        private readonly IUserService _userService;
        private readonly IGameService _gameService;

        public ShipController(IShipService shipService, IUserService userService, IGameService gameService)
        {
            _shipService = shipService;
            _userService = userService;
            _gameService = gameService;
        }

        [Authorize]
        [HttpPost("placeship")]
        public async Task<Ship> TestShipPlacement(PlaceShipModel positions)
        {
            ApplicationUser user = await _userService.GetUserAsync(positions.UserId);
            Game game = _gameService.GetGame(Int32.Parse(positions.gameId));

            _shipService.setCurrentUser(user);
            _shipService.setCurrentGame(game);
            var result = _shipService.VerifyShipValidity(positions);
            return result;
        }


        // POST api/ship
        [HttpPost]
        public void Post([FromBody]Ship ship)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

