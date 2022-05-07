﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Model.Entities;
using BattleshipAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleshipAPI.Controllers
{
    [Route("api/[controller]")]
    public class ShipController : Controller
    {
        private BattleshipDbContext _ctx;

        public ShipController(BattleshipDbContext ctx)
        {
            _ctx = ctx;
        }

        // GET: api/ship
        [HttpGet]
        public void Get()
        {
           
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

