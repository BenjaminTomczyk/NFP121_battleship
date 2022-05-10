using System;
using System.Threading.Tasks;
using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using BattleshipAPI.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController : Controller
    {
        private readonly IShipService _shipService;
        private BattleshipDbContext _ctx;

        public ShipController(IShipService shipService, BattleshipDbContext ctx)
        {
            _shipService = shipService;
            _ctx = ctx;
        }

        [Authorize]
        [HttpPost("placeship")]
        public Ship TestShipPlacement(PlaceShipModel positions)
        {

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

