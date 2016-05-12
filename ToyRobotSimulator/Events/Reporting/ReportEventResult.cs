using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Events.Reporting
{
    public class ReportEventResult : IEventResult<ReportEvent>
    {
        private readonly Report report;

        public ReportEventResult(Report report)
        {
            this.report = report;
        }

        public Report Value
        {
            get { return report; }
        }
    } 
}
