using System;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Left;
using ToyRobotSimulator.Events.Move;
using ToyRobotSimulator.Events.Place;
using ToyRobotSimulator.Events.Reporting;
using ToyRobotSimulator.Events.Right;

namespace ToyRobotSimulator
{
    public class ToyRobot
    {

        private readonly Table table;
        private readonly ReportEvent reportEvent;
        private Coordinates currentLocation = new Coordinates(null, null);
        private DirectionList currentDirection = DirectionList.North;

        public ToyRobot(IEventBus eventBus, Table table)
        {
            this.table = table;
            
            //Toy robot needs to report current location to anyone subscribed
            reportEvent = eventBus.Register<ReportEvent>();

            //Command event subscriptions
            eventBus.Subscribe(new ReportRequestedEventHandler(onReportRequested));
            eventBus.Subscribe(new PlaceRequestedEventHandler(onPlaceRequested));
            eventBus.Subscribe(new MoveRequestedEventHandler(onMoveRequested));
            eventBus.Subscribe(new LeftRequestedEventHandler(onLeftRequested));
            eventBus.Subscribe(new RightRequestedEventHandler(onRightRequested));

        }

        private bool onPlaceRequested(object sender, Report report)
        {
            if (table.ValidateCoordinates(report.Coordinates))
            {
                this.currentLocation = report.Coordinates;
                this.currentDirection = report.Direction;
            }

            return true;
        }

        private bool onReportRequested(object sender, object param)
        {
            if(isOnTable())               
                reportEvent.RaiseEvent(sender, new Report(this.currentLocation, this.currentDirection));
            return true;
        }

        private bool isOnTable()
        {
            if (!currentLocation.X.HasValue)
            {
                throw new InvalidOperationException("Not on table!");
            }

            return true;
        }

        private bool onMoveRequested(object sender, object param)
        {
            if (isOnTable())
            {
                currentLocation = table.Move(currentLocation, currentDirection);
            }
            return true;
        }

        private bool onLeftRequested(object sender, object param)
        {
            if (isOnTable())
            {
                changeDirection(-1);
            }
            return true;
        }

        private bool onRightRequested(object sender, object param)
        {
            if (isOnTable())
            {
                changeDirection(1);
            }
            return true;
        }

        private void changeDirection(int rotate)
        {
            var cd = (int)currentDirection;
            cd += rotate;
            if (cd < (int)DirectionList.North)
                currentDirection = DirectionList.West;
            else if (cd > (int)DirectionList.West)
                currentDirection = DirectionList.North;
            else
                currentDirection = (DirectionList)cd;
        }
    }
}
