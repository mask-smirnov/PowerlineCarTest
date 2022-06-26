using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerlineCarTest
{
    public class TravelTimeCalculationResult
    {
        public bool Success; //доедет - не доедет
        public string FailReason; //почему не доедет
        public decimal TravelTime; //за какое время доедет

        public TravelTimeCalculationResult(bool _success, decimal _travelTime, string _failReason = "")
        {
            Success = _success;
            FailReason = _failReason;
            TravelTime = _travelTime;
        }
    }
}
