using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Reporting;

namespace ToyRobotSimulator.Tests
{
    [TestClass]
    public class ToyRobotTests
    {
        [TestMethod]
        public void Execute_ReportCommand_DoesNotReportsCurrentLocationDueToNotOnTable()
        {
            var eventBus = new EventBus();
            var commandBus = new CommandBus();
            var table = new Table(1, 1);
            var toyRobot = new ToyRobot(eventBus, table);

            Report report = null;
            eventBus.Subscribe(new ReportEventHandler((obj, rep) =>
            {
                report = rep;
                return true;
            }));

            //Send Command
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.IsNull(report, "Report should be null because no place event");

        }

        [TestMethod]
        public void Execute_PlaceCommand_PlacesAtSpecifiedLocationAndReportsNewLocation()
        {
            var eventBus = new EventBus();
            var commandBus = new CommandBus();
            var table = new Table(5, 5);
            var toyRobot = new ToyRobot(eventBus, table);

            //Send Command
            var place = new Report(new Coordinates(1, 1), DirectionList.East);
            commandBus.ExecuteCommand(new PlaceCommand(eventBus, place));

            Report report = null;
            eventBus.Subscribe(new ReportEventHandler((obj, rep) =>
            {
                report = rep;
                return true;
            }));

            //Send report command to verify place command successful
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.IsNotNull(report, "Report is null");

            Assert.AreEqual(1, report.Coordinates.X, "x coordinate should be 1");
            Assert.AreEqual(1, report.Coordinates.Y, "y coordinate should be 1");
            Assert.AreEqual(DirectionList.East, report.Direction, "Direction should be east");




        }


        [TestMethod]
        public void Execute_MoveCommand_MovesToNewLocation()
        {

            var eventBus = new EventBus();
            var commandBus = new CommandBus();
            var table = new Table(5, 5);
            var toyRobot = new ToyRobot(eventBus, table);

            //Send Command
            var place = new Report(new Coordinates(1, 1), DirectionList.East);
            commandBus.ExecuteCommand(new PlaceCommand(eventBus, place));

            Report report = null;
            eventBus.Subscribe(new ReportEventHandler((obj, rep) =>
            {
                report = rep;
                return true;
            }));

            //Send report command to verify place command successful
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.IsNotNull(report, "Report is null");

            Assert.AreEqual(1, report.Coordinates.X, "x coordinate should be 1");
            Assert.AreEqual(1, report.Coordinates.Y, "y coordinate should be 1");
            Assert.AreEqual(DirectionList.East, report.Direction, "Direction should be east");

            //Now send move command
            commandBus.ExecuteCommand(new MoveCommand(eventBus));

            //Send report command to verify move command successful
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.AreEqual(2, report.Coordinates.X, "x coordinate should be 2");
            Assert.AreEqual(1, report.Coordinates.Y, "y coordinate should be 1");
            Assert.AreEqual(DirectionList.East, report.Direction, "Direction should be east");
        }

        [TestMethod]
        public void Execute_LeftCommand_ChangesDirectionFromEastToNorth()
        {

            var eventBus = new EventBus();
            var commandBus = new CommandBus();
            var table = new Table(5, 5);
            var toyRobot = new ToyRobot(eventBus, table);

            //Send Command
            var place = new Report(new Coordinates(1, 1), DirectionList.East);
            commandBus.ExecuteCommand(new PlaceCommand(eventBus, place));

            Report report = null;
            eventBus.Subscribe(new ReportEventHandler((obj, rep) =>
            {
                report = rep;
                return true;
            }));

            //Send report command to verify place command successful
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.IsNotNull(report, "Report is null");

            Assert.AreEqual(1, report.Coordinates.X, "x coordinate should be 1");
            Assert.AreEqual(1, report.Coordinates.Y, "y coordinate should be 1");
            Assert.AreEqual(DirectionList.East, report.Direction, "Direction should be east");

            //Now send left command
            commandBus.ExecuteCommand(new LeftCommand(eventBus));

            //Send report command to verify move command successful
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.AreEqual(1, report.Coordinates.X, "x coordinate should be 1");
            Assert.AreEqual(1, report.Coordinates.Y, "y coordinate should be 1");
            Assert.AreEqual(DirectionList.North, report.Direction, "Direction should be north");
        }

        [TestMethod]
        public void Execute_RightCommand_ChangesDirectionFromEastToSouth()
        {

            var eventBus = new EventBus();
            var commandBus = new CommandBus();
            var table = new Table(5, 5);
            var toyRobot = new ToyRobot(eventBus, table);

            //Send Command
            var place = new Report(new Coordinates(1, 1), DirectionList.East);
            commandBus.ExecuteCommand(new PlaceCommand(eventBus, place));

            Report report = null;
            eventBus.Subscribe(new ReportEventHandler((obj, rep) =>
            {
                report = rep;
                return true;
            }));

            //Send report command to verify place command successful
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.IsNotNull(report, "Report is null");

            Assert.AreEqual(1, report.Coordinates.X, "x coordinate should be 1");
            Assert.AreEqual(1, report.Coordinates.Y, "y coordinate should be 1");
            Assert.AreEqual(DirectionList.East, report.Direction, "Direction should be east");

            //Now send right command
            commandBus.ExecuteCommand(new RightCommand(eventBus));

            //Send report command to verify move command successful
            commandBus.ExecuteCommand(new ReportCommand(eventBus));

            Assert.AreEqual(1, report.Coordinates.X, "x coordinate should be 1");
            Assert.AreEqual(1, report.Coordinates.Y, "y coordinate should be 1");
            Assert.AreEqual(DirectionList.South, report.Direction, "Direction should be south");
        }



    }
}
