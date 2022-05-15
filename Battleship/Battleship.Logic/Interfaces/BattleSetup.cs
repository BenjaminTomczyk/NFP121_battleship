﻿using System;
using System.Collections.Generic;
using Battleship.Logic.Services;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;

namespace Battleship.Logic.Interfaces
{
    public class BattleSetup : IBattleSetup
    {
        private readonly IShipRepository _shipRepository;
        private readonly IGameService _gameService;

        public List<ShipService> PlaceBoats(Player p1, int gridSize, List<int> requiredShips)
        {
            var res = new List<ShipService>();
            for (int i = 0; i < requiredShips.Count; i++)
            {
                //res.Add(new ShipService(, _shipRepository, _gameService));
            }
            return res;
        }



    }
}