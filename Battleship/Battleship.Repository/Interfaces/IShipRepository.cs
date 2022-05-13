using System;
using System.Collections.Generic;
using System.Linq;
using Battleship.Model.Entities;

namespace Battleship.Repository.Interfaces
{
	public interface IShipRepository
	{
		Ship AddShip(Ship ship);

		IQueryable<Ship> GetShips(Game game);
	}

}

