
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningBL {
    public class RunningException : Exception {
        public RunningException(string message) : base(message) {
        }

        public RunningException(string message, Exception innerException) : base(message, innerException) {
        }
    }
}
