using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Infrastructure
{
    public class SaldoUtils
    {
        private static SaldoUtils Instance;

        private SaldoUtils()
        { }

        public static SaldoUtils GetInstance()
        {
            if (Instance == null)
                Instance = new SaldoUtils();
            return Instance;
        }

        public Tuple<int, MonthEnum> GetPreviousDate(int currentYear, int currentMonth)
        {
            MonthEnum prevMonth;
            int prevYear;

            if (currentMonth == 0)
            {
                prevMonth = MonthEnum.DECEMBER;
                prevYear = currentYear - 1;
            }
            else
            {
                prevMonth = (MonthEnum)currentMonth - 1;
                prevYear = currentYear;
            }

            return Tuple.Create<int, MonthEnum>(prevYear, prevMonth);
        }
    }
}
