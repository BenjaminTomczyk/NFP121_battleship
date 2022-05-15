using System;
namespace Battleship.Model.Entities
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            User
        }
        public const string default_lastname = "lastname_user";
        public const string default_firstrname = "fisrtname_user";
        public const string default_username = "user";
        public const string default_email = "user@secureapi.com";
        public const string default_password = "Pa$$w0rd.";
        public const Roles default_role = Roles.User;
    }
}

