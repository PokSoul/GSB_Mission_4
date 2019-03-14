using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB_Mission_4
{
    class GestionDate
    {
        public string getCurrentMonth(DateTime date)
        {
            return date.Month.ToString();
        }

        public string getPreviousMonth(DateTime date)
        {
            var previousMonth = date.Month - 1;
            return previousMonth.ToString();
        }

        public string getNextMonth(DateTime date)
        {
            var nextMonth = date.Month + 1;
            return nextMonth.ToString();
        }
    }
}
