using System;
using Battleship.Model.Entities;

namespace Battleship.Repository.Repositories
{
	public interface IJWTManagerRepository
	{
		Tokens Authenticate(User users);
	}
}