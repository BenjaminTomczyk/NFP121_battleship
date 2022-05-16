using Battleship.Logic.Services;
using Battleship.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Logic.Interfaces
{
    public interface IShipService
    {
        Game setCurrentGame(int game);
        Ship VerifyShipValidity(PlaceShipModel positions);
        bool IsSet();
        bool IsPositionValidDiagonale();
        bool IsPositionValidHorizontalOrVerticale();
        bool IsInGrid(int gridSize);
        bool IsInjuxtapose();
        void AddPositionInvalid();
        bool IsDiagonale();
        bool IsCollision(Ship ship1);
        void SetNewAttributPosition(int startCol, int startRow, int endCol, int endRow);
        void GenerationListPositions();
        void ListPositionStandard(List<Position> listPosition);
        void ListPositionDiagonale(List<Position> listPosition);
        void AddPosition(List<Position> listPosition, int direction);
        void OrderPosition();
        bool CheckShipSize();
        Ship CreateShip(bool isValid);
        Game AddShipToGame(Ship ship);
    }
}