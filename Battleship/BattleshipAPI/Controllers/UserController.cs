using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Model.Entities.Auth;
//using Battleship.Repository.Repositories;
using BattleshipAPI.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BattleshipAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		private BattleshipDbContext _ctx;
		public UsersController(IUserService userService, BattleshipDbContext ctx)
		{
			_userService = userService;
			_ctx = ctx;
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<ActionResult> GetProfileAsync(string id)
		{
			var result = await _userService.GetUserAsync(id);
			var games = _ctx.Game.Where(c => c.Player.Id == id).ToList();
			result.Games = games;
			return Ok(result);
		}

		[HttpPost("register")]
		public async Task<ActionResult> RegisterAsync(RegisterModel model)
		{
			var result = await _userService.RegisterAsync(model);
			return Ok(result);
		}

		[HttpPost("token")]
		public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
		{
			var result = await _userService.GetTokenAsync(model);
			return Ok(result);
		}

		[HttpPost("addrole")]
		public async Task<IActionResult> AddRoleAsync(AddRoleModel model)
		{
			var result = await _userService.AddRoleAsync(model);
			return Ok(result);
		}
	}
}
