using System;
using Battleship.Logic.Interfaces;

namespace Battleship.Logic.Services
{
    public class Communicator : ICommunicator
    {
        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}