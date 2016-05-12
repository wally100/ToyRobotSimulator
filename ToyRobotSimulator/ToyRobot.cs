using System;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Exceptions;
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
        private readonly ExceptionEvent exceptionEvent;
        private Coordinates currentLocation = new Coordinates(null, null);
        private DirectionList currentDirection = DirectionList.NORTH;

        public ToyRobot(IEventBus eventBus, Table table)
        {
            this.table = table;
            
            //Toy robot needs to report current location to anyone subscribed
            reportEvent = eventBus.Register<ReportEvent>();
            exceptionEvent = eventBus.Register<ExceptionEvent>();

            //Command event subscriptions
            eventBus.Subscribe(new ReportRequestedEventHandler(onReportRequested));
            eventBus.Subscribe(new PlaceRequestedEventHandler(onPlaceRequested));
            eventBus.Subscribe(new MoveRequestedEventHandler(onMoveRequested));
            eventBus.Subscribe(new LeftRequestedEventHandler(onLeftRequested));
            eventBus.Subscribe(new RightRequestedEventHandler(onRightRequested));

        }

        private bool onPlaceRequested(object sender, Report report)
        {
            try
            {
                if (table.ValidateCoordinates(report.Coordinates))
                {
                    this.currentLocation = report.Coordinates;
                    this.currentDirection = report.Direction;
                }
            }
            catch (InvalidOperationException ex)
            {
                if (!exceptionEvent.RaiseEvent(sender, ex))
                    throw;
                return false;
            }
          

            return true;
        }

        private bool onReportRequested(object sender, object param)
        {
            if(isOnTable(sender))               
                reportEvent.RaiseEvent(sender, new Report(this.currentLocation, this.currentDirection));
            return true;
        }

        private bool isOnTable(object sender)
        {
            if (!currentLocation.X.HasValue)
            {
                var ex = new InvalidOperationException("Not on table!");
                if (!exceptionEvent.RaiseEvent(sender, ex))
                    throw ex;
                else
                    return false;
            }

            return true;
        }

        private bool onMoveRequested(object sender, object param)
        {
            if (isOnTable(sender))
            {
                try
                {
                    currentLocation = table.Move(currentLocation, currentDirection);
                }
                catch (InvalidOperationException ex)
                { 
                    if (!exceptionEvent.RaiseEvent(sender, ex))
                        throw;
                    return false;
                }
            
            }
            return true;
        }

        private bool onLeftRequested(object sender, object param)
        {
            if (isOnTable(sender))
            {
                changeDirection(-1);
            }
            return true;
        }

        private bool onRightRequested(object sender, object param)
        {
            if (isOnTable(sender))
            {
                changeDirection(1);
            }
            return true;
        }

        private void changeDirection(int rotate)
        {
            var cd = (int)currentDirection;
            cd += rotate;
            if (cd < (int)DirectionList.NORTH)
                currentDirection = DirectionList.WEST;
            else if (cd > (int)DirectionList.WEST)
                currentDirection = DirectionList.NORTH;
            else
                currentDirection = (DirectionList)cd;
        }
    }
}
