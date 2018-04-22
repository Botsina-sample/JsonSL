using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonProgram
{
    class Configuration
    {
        public string ProjectName { get; set;}
        public bool SetTextSpeed { get; set; }
        public bool ShowProgressBar { get; set; }
        public bool StopOnFailed { get; set; }
    }
}
