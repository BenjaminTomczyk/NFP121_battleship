using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;
using Battleship.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Logic.Services
{
    public class ShipService : IShipService
    {
        public int _Id;
        public Position _Start;
        public Position _End;
        public List<Position> _Positions;
        public Game _Game;
        public ApplicationUser _User;

        private readonly IShipRepository _shipRepository;
        private readonly IUserService _userService;

        public ShipService() { }
        public ShipService(Position Start, Position End, IShipRepository shipRepository, IUserService userService)
        {
            //TODO mettre un système d'id en place pour l'instant c'est tout le temps 0

            _Id = 0;
            _Start = Start;
            _End = End;
            _Positions = new List<Position>();
            _shipRepository = shipRepository;
            _userService = userService;
        }

        public Game setCurrentGame(Game game)
        {
            _Game = game;
            return _Game;
        }

        public void setCurrentUser(ApplicationUser user)
        {
            _User = user;
        }

        public Ship VerifyShipValidity(PlaceShipModel positions)
        {
            bool isValid = false;
            _Start = new Position(positions.Start[0], positions.Start[1]);
            _End = new Position(positions.End[0], positions.End[1]);
            Game game = _Game;
            GenerationListPositions();

            if (IsSet())
            {
                if (IsPosition())
                {
                    if (IsInGrid(8))
                    {
                        if (!IsCollisionWithListPlaceShip())
                        {
                            if (!IsInjuxtapose(game))
                            {
                                isValid = true;
                            }
                        }
                    }
                }
            }

            if (isValid)
            {
                Ship newShip = new Ship(_Start, _End, _Positions, game, "User", isValid);
                _shipRepository.AddShip(newShip);
                this.AddPositionInvalid(game);
                _Game = game;
                return newShip;
            }
            else return new Ship(null, null, null, null, null, isValid);
        }

        public bool IsSet() => _Start != null && _End != null;

        public bool IsPosition()
        {
            if (Math.Abs(_Start.Row - _End.Row) == Math.Abs(_Start.Column - _End.Column)) return true;
            return false;
        }

        public bool IsInGrid(int gridSize)
        {
            if (!IsSet()) return false;
            List<int> positions = new List<int>() { _Start.Column, _Start.Row, _End.Column, _End.Row };
            return positions.TrueForAll(p => (0 <= p && p < gridSize));
        }

        public bool IsInjuxtapose(Game game)
        {
            foreach (Position posI in _Positions)
            {
                foreach (Position posY in game.PositionsInvalid)
                    if (posI.Equals(posY)) return true;
            }
            return false;
        }

        public void AddPositionInvalid(Game game)//fonction a appeler quand le bateau est creer définitivement
        {
            if (this._Positions != null && game != null)
            {
                foreach (Position posI in _Positions)
                {
                    game.PositionsInvalid.Add(new Position(posI.Row, posI.Column + 1));
                    game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column + 1));
                    game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column));
                    game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column - 1));
                    game.PositionsInvalid.Add(new Position(posI.Row, posI.Column - 1));
                    game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column - 1));
                    game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column));
                    game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column + 1));
                }
            }

            game.PositionsInvalid = game.PositionsInvalid.Distinct().ToList();

            foreach (Position posI in _Positions)
            {
                game.PositionsInvalid.Remove(posI);
            }
        }

        public bool IsDiagonale()
        {
            return (_Start.Column != _End.Column && _Start.Row != _End.Row);
        }

        public bool IsCollisionWithListPlaceShip()
        {//TODO 
            foreach(ShipService placeShip in new List<ShipService>()/*placeShips*/)//TODO : creer un attribut sur la game qui est une list qui contient tout les ship placer ou faire appele a la base de données
            {
                if (this.IsCollision(placeShip)) return true;
            }
            return false;
        }

        public bool IsCollision(ShipService ship1)
        {
            if (!ship1.IsSet()&&!this.IsSet()) return true;
            this.GenerationListPositions();
            //TODO : mettre la fonction lors de la pose du bateau apres les verifications de si il est valide
            ship1.GenerationListPositions();

            return this._Positions.Any(ipositionThis => ship1._Positions.Any(ipostionShip1 => ipositionThis.Equals(ipostionShip1)));
        }

        public void SetNewAttributPosition(int startCol, int startRow, int endCol, int endRow)
        {
            _Start.SetNewValue(startCol, startRow);
            _End.SetNewValue(endCol, endRow);
        }

        public void GenerationListPositions()
        {
            List<Position> listPosition = new List<Position>();
            if (IsSet())
            {
                this.OrderPosition();

                if (!IsDiagonale())
                {
                    ListPositionStandard(listPosition);
                }
                else ListPositionDiagonale(listPosition);
            }

            this._Positions = listPosition;
        }
        public void ListPositionStandard(List<Position> listPosition)
        {
            var listCol = Enumerable.Range(_Start.Column, _End.Column - _Start.Column + 1);
            var listRow = Enumerable.Range(_Start.Row, _End.Row - _Start.Row + 1);

            foreach (var iListCol in listCol)
            {
                foreach (var ilistRow in listRow) listPosition.Add(new Position(ilistRow, iListCol));
            }
        }
        public void ListPositionDiagonale(List<Position> listPosition)
        {
            if (_Start.Row < _End.Row && _Start.Column < _End.Column)
            {
                AddPosition(listPosition, +1);
            }
            else if (_Start.Row > _End.Row && _Start.Column < _End.Column)
            {
                AddPosition(listPosition, -1);
            }
        }

        public void AddPosition(List<Position> listPosition, int direction)
        {
            for (int i = 0; i <= _End.Column - _Start.Column; i++)
            {
                listPosition.Add(new Position(_Start.Row + i * direction, _Start.Column + i));
            }
        }

        public void OrderPosition()
        {
            var startCol = _Start.Column;
            var endCol = _End.Column;
            var startRow = _Start.Row;
            var endRow = _End.Row;

            if (!IsDiagonale())
            {
                startCol = Math.Min(_Start.Column, _End.Column);
                endCol = Math.Max(_Start.Column, _End.Column);
                startRow = Math.Min(_Start.Row, _End.Row);
                endRow = Math.Max(_Start.Row, _End.Row);
            }

            else if (IsDiagonale() && _Start.Column > _End.Column)
            {
                startCol = _End.Column;
                startRow = _End.Row;
                endCol = _Start.Column;
                endRow = _Start.Row;
            }

            SetNewAttributPosition(startCol, startRow, endCol, endRow);

        }
    }
}