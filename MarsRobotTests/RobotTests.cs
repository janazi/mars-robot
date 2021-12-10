using MarsRobot;
using NUnit.Framework;

namespace MarsRobotTests
{
    public class RobotTests
    {

        [Test]
        public void Shoud_set_x_plateau_max_to_five()
        {
            const string plateauSize = "5x5";
            var robot = new Robot(plateauSize);
            Assert.AreEqual(5, robot.MaxPlateauX);
        }

        [Test]
        public void Shoud_set_y_plateau_max_to_four()
        {
            const string plateauSize = "5x4";
            var robot = new Robot(plateauSize);
            Assert.AreEqual(4, robot.MaxPlateauY);
        }

        [Test]
        public void Shoud_accept_the_command_to_move()
        {
            const string plateauSize = "5x4";
            const string command = "FF";
            var robot = new Robot(plateauSize);
            Assert.IsTrue(robot.Move(command));
        }

        [Test]
        public void Shoud_reject_the_command_to_move()
        {
            const string plateauSize = "5x4";
            const string command = "YZ";
            var robot = new Robot(plateauSize);
            Assert.IsFalse(robot.Move(command));
        }

        [Test]
        public void Should_be_valid_command()
        {
            const string command = "FF";
            Assert.IsTrue(Robot.ValidateCommand(command));
        }

        [Test]
        public void Should_be_invalid_command()
        {
            const string command = "XX";
            Assert.IsFalse(Robot.ValidateCommand(command));
        }

        [Test]
        public void Should_move_to_right_position()
        {
            const string expectedPosition = "1,4,West";
            const string command = "FFRFLFLF";
            const string plateauSize = "5x5";

            var robot = new Robot(plateauSize);
            robot.Move(command);

            var robotPosition = robot.GetActualPosition();
            Assert.AreEqual(expectedPosition, robotPosition);
        }

        [Test]
        public void Should_not_exceed_plateau_x_limit()
        {
            const string expectedPosition = "3,2,East";
            const string command = "FRFFFF";
            var plateauSize = $"3x3";

            var robot = new Robot(plateauSize);
            robot.Move(command);

            var robotPosition = robot.GetActualPosition();
            Assert.AreEqual(expectedPosition, robotPosition);
        }

        [Test]
        public void Should_not_exceed_plateau_y_limit()
        {
            const string expectedPosition = "3,2,East";
            const string command = "FRFFFF";
            var plateauSize = $"3x3";

            var robot = new Robot(plateauSize);
            robot.Move(command);

            var robotPosition = robot.GetActualPosition();
            Assert.AreEqual(expectedPosition, robotPosition);
        }

    }
}