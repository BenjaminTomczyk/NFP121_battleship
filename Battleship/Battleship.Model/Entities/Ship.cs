﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Battleship.Model.Entities
{
    public class Ship
    {
        public int Id { get; set; }
        public Position? Start { get; set; }
        public Position? End { get; set; }
        public Game Game { get; set; }
        public string Player { get; set; }
        public int Taille { get; set; }

        public List<Position>? Positions { get; set; }

        public bool IsValid { get; set; }

        public Ship() { }
        public Ship(Position start, Position end, List<Position> positions, Game game, string player, bool isValid, int taille)
        {
            Start = start;
            End = end;
            Positions = positions;
            Game = game;
            Player = player;
            IsValid = isValid;
            Taille = taille;
        }
    }
}