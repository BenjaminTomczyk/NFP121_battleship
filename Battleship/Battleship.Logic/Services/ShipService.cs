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
        private readonly IGameService _gameService;


        public ShipService(IShipRepository shipRepository, IGameService gameService)
        {
            _Id = 0;
            _Positions = new List<Position>();
            _shipRepository = shipRepository;
            _gameService = gameService;
            _Game = GameService.GetInstanceGame();
        }

        public ShipService(Position start, Position end, IShipRepository shipRepository, IGameService gameService)
        {
            _Id = 0;
            _Start = start;
            _End = end;
            _Positions = new List<Position>();
            _shipRepository = shipRepository;
            _gameService = gameService;
        }

        public Game setCurrentGame(int game)
        {
            return _Game = _gameService.GetGame(game);
        }

        public Ship VerifyShipValidity(PlaceShipModel positions)
        {
            bool isValid = false;
            _Start = new Position(positions.Start[0], positions.Start[1]);
            _End = new Position(positions.End[0], positions.End[1]);
            GenerationListPositions();


            if(IsSet()){
                //Console.WriteLine("ok isSET");
                if (IsPositionValidDiagonale() || IsPositionValidHorizontalOrVerticale())
                {
                    //Console.WriteLine("ok isPosition");

                    if (IsInGrid(8)) //osef de la gridsize dans le cdc c'est marqué 8x8 //ok frr le boss j'avoue que c'est tout le temps 8X8 xD

                    {
                        //Console.WriteLine("ok isInGrid");

                        if (!IsCollisionWithListPlaceShip())
                        {
                            //Console.WriteLine("ok isCollisionwithPlace");

                            if (!IsInjuxtapose())
                            {
                                //Console.WriteLine("ok JUXTAPOSER");
                                if (CheckShipSize())
                                {
                                    //Console.WriteLine("ok checksize");
                                    isValid = true;
                                }
                            }
                        }
                    }
                }
            }

            if (isValid)
            {
                Ship newShip = new Ship(_Start, _End, _Positions, null, "User", isValid, _Positions.Count());
                _Game.ShipsPose.Add(newShip);

                this.AddPositionInvalid();

                newShip.Game = _Game;
                Ship s = _shipRepository.AddShip(newShip);
                _gameService.UpdateGame(_Game);

                foreach (Position p in _Game.PositionsInvalid)
                {
                    Console.WriteLine(p.Id);
                }

                return s;
            }
            else return new Ship(null, null, null, null, null, isValid, 0);  
        }

        public bool CheckShipSize()
        {
            switch (_Positions.Count())
            {
                case 2:
                    if (_Game.Ship2Number == 0) return false;
                    else
                    {
                        _Game.Ship2Number--;
                        _Game.PlacedShips++;
                        _gameService.UpdateGame(_Game);
                        return true;    
                    }

                case 3:
                    if (_Game.Ship3Number == 0) return false;
                    else
                    {
                        _Game.Ship3Number--;
                        _Game.PlacedShips++;
                        _gameService.UpdateGame(_Game);
                        return true;
                    }

                case 4:
                    if (_Game.Ship4Number == 0) return false;
                    else
                    {
                        _Game.Ship4Number--;
                        _Game.PlacedShips++;
                        _gameService.UpdateGame(_Game);
                        return true;
                    }

                case 5:
                    if (_Game.Ship5Number == 0) return false;
                    else
                    {
                        _Game.Ship5Number--;
                        _Game.PlacedShips++;
                        _gameService.UpdateGame(_Game);
                        return true;
                    }

                default:
                    return false;
            }
        }

        public bool IsSet() => _Start != null && _End != null;

        public bool IsPositionValidDiagonale()
        {
            if (Math.Abs(_Start.Row - _End.Row) == Math.Abs(_Start.Column - _End.Column)) return true;
            return false;
        }

        public bool IsPositionValidHorizontalOrVerticale()
        {
            if (_Start.Row == _End.Row || _Start.Column == _End.Column) return true;
            return false;
        }

        public bool IsInGrid(int gridSize)
        {
            if (!IsSet()) return false;
            List<int> positions = new List<int>() { _Start.Column, _Start.Row, _End.Column, _End.Row };
            return positions.TrueForAll(p => (0 <= p && p < gridSize));
        }

        public bool IsInjuxtapose()
        {
            foreach (Position posI in _Positions)
            {
                foreach (Position posY in _Game.PositionsInvalid)
                {
                    if (posI.Equals(posY)) return true;
                }
            }
            return false;
        }

        public void AddPositionInvalid()//fonction a appeler quand le bateau est creer définitivement
        {
            if (this._Positions != null && _Game != null)
            {
                foreach (Position posI in _Positions)
                {
                    _Game.PositionsInvalid.Add(new Position(posI.Row, posI.Column + 1));
                    _Game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column + 1));
                    _Game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column));
                    _Game.PositionsInvalid.Add(new Position(posI.Row + 1, posI.Column - 1));
                    _Game.PositionsInvalid.Add(new Position(posI.Row, posI.Column - 1));
                    _Game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column - 1));
                    _Game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column));
                    _Game.PositionsInvalid.Add(new Position(posI.Row - 1, posI.Column + 1));
                }
            }

            _Game.PositionsInvalid = _Game.PositionsInvalid.Distinct().ToList();

            foreach (Position posI in _Positions)
            {
                _Game.PositionsInvalid.Remove(posI);
            }
        }

        public bool IsDiagonale()
        {
            return (_Start.Column != _End.Column && _Start.Row != _End.Row);
        }

        public bool IsCollisionWithListPlaceShip()
        {
            foreach(Ship placeShip in _Game.ShipsPose)
            {
                if (this.IsCollision(placeShip)) return true;
            }
            return false;
        }

        public bool IsCollision(Ship ship1)
        {
            if (ship1==null || (!this.IsSet())) return true;
            this.GenerationListPositions();
            //TODO : mettre la fonction lors de la pose du bateau apres les verifications de si il est valide
            //ship1.GenerationListPositions();


            return this._Positions.Any(ipositionThis => ship1.Positions.Any(ipostionShip1 => ipositionThis.Equals(ipostionShip1)));
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
