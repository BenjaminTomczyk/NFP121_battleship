﻿using System;
using System.Collections.Generic;
using Battleship.Model.Entities;

namespace Battleship.Repository.Interfaces
{
	public interface IUserRepository
	{
		List<Game> GetUserHistory(string id);
	}

}

