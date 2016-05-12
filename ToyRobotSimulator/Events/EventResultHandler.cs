using System;

namespace ToyRobotSimulator.Events
{
    public delegate bool EventResultHandler<T>(object sender, T result);
}
