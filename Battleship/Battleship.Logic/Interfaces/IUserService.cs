using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battleship.Model.Entities;
using Battleship.Model.Entities.Auth;

namespace Battleship.Logic.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterModel model);

        Task<AuthenticationModel> GetTokenAsync(TokenRequestModel model);

        Task<string> AddRoleAsync(AddRoleModel model);

        Task<ApplicationUser> GetUserAsync(string id);

        List<Game> GetPlayerHistory(string id);
    }
}

