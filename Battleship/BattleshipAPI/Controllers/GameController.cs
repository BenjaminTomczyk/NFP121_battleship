using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Battleship.Model.Entities;
using System.Net;

namespace BattleshipAPI.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        // GET: api/game
        [HttpGet]
        public int Get()
        {
            return 2;
        }

        [HttpPost]
        public void PlaceBoat([FromBody] int[] StartEnd)
        {
            //TODO : fonction qui test la validité du bateau et le place ou renvoie une erreur
            //Parameter : tableau d'int contentant start et end
            //PlaceBoat(StartEnd);
        }

        [HttpPost]
        public bool Shoot([FromBody]int pos)
        {
            //TODO : fonction qui test si il y a un bateau et renvoie un bool
            //CheckShootCell(pos);
            return false;
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

