using Battleship.Logic.Services;
using Battleship.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Battleship.Logic.Interfaces
{
    public interface IShipService
    {
        Game setCurrentGame(int game);
        Ship VerifyShipValidity(PlaceShipModel positions);
        bool IsSet();
        bool IsPosition();
        bool IsInGrid(int gridSize);
        bool IsInjuxtapose(Game game);
        void AddPositionInvalid(Game game);
        bool IsDiagonale();
        bool IsCollision(ShipService ship1);
        void SetNewAttributPosition(int startCol, int startRow, int endCol, int endRow);
        void GenerationListPositions();
        void ListPositionStandard(List<Position> listPosition);
        void ListPositionDiagonale(List<Position> listPosition);
        void AddPosition(List<Position> listPosition, int direction);
        void OrderPosition();
        
    }
}