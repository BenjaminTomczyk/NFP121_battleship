using System;
using System.IdentityModel.Tokens.Jwt;
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
    }
}

