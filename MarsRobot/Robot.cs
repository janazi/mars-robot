using System;
using System.Text.RegularExpressions;

namespace MarsRobot
{

    public class Robot
    {
        private Position _actualPosition = Position.North;
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public int MaxPlateauX { get; private set; }
        public int MaxPlateauY { get; private set; }

        /// <summary>
        /// Set the size of the plateau
        /// </summary>
        /// <param name="plateauXAndY">A string must contains X and Y positions 5x5, 3x4</param>
        public Robot(string plateauXAndY = "5x5")
        {
            PositionX = 1;
            PositionY = 1;
            SetPlateau(plateauXAndY);
        }

        /// <summary>
        /// Input should have x and y positiions
        /// ex: 5x5
        /// </summary>
        /// <param name="plateauXAndY"></param>
        private void SetPlateau(string plateauXAndY)
        {
            var plateauPositions = plateauXAndY.ToLower().Split("x");
            MaxPlateauX = int.Parse(plateauPositions[0]);
            MaxPlateauY = int.Parse(plateauPositions[1]);
        }

        /// <summary>
        /// Returns robots actual position
        /// </summary>
        /// <returns></returns>
        public string GetActualPosition()
        {
            var position = $"{PositionX},{PositionY},{_actualPosition}";
            Console.WriteLine(position);
            return position;
        }

        /// <summary>
        /// Command must have only F to move straight, L to turn left and R to turn right
        /// </summary>
        /// <param name="commands">FFRFLFLF</param>
        public bool Move(string commands = "FFRFLFLF")
        {
            if (!ValidateCommand(commands))
                return false;

            foreach (var command in commands.ToUpper())
            {
                switch (command)
                {
                    case 'F':
                        GoAhead();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
            GetActualPosition();
            return true;
        }

        public static bool ValidateCommand(string command)
        {
            var regex = Regex.Match(command, @"^[FLR]", RegexOptions.IgnoreCase);
            return regex.Success;
        }

        private void GoAhead()
        {
            switch (_actualPosition)
            {
                case Position.North:
                    MovedY(1);
                    break;
                case Position.East:
                    MovedX(1);
                    break;
                case Position.South:
                    MovedY(-1);
                    break;
                case Position.West:
                    MovedX(-1);
                    break;
            }
        }

        private void MovedY(int value)
        {
            if (value < 0)
            {
                if (PositionY > 1)
                    PositionY += value;
                return;
            }

            if (PositionY < MaxPlateauY)
                PositionY += value;
        }

        private void MovedX(int value)
        {
            if (value > 0)
            {
                if (PositionX < MaxPlateauX)
                    PositionX += value;
                return;
            }

            if (PositionX > 1)
                PositionX += value;
        }

        private void TurnLeft()
        {
            _actualPosition = _actualPosition switch
            {
                Position.North => Position.West,
                Position.West => Position.South,
                Position.South => Position.East,
                Position.East => Position.North,
                _ => _actualPosition
            };
        }

        private void TurnRight()
        {
            _actualPosition = _actualPosition switch
            {
                Position.North => Position.East,
                Position.East => Position.South,
                Position.South => Position.West,
                Position.West => Position.North,
                _ => _actualPosition
            };
        }
    }
}