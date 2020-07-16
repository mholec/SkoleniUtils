using System;
using System.Collections.Generic;

namespace Holec.SkoleniUtils
{
    public static class Holidays
    {
        private static List<DateTime> GetDates()
        {
            List<DateTime> dates = new List<DateTime>();
            int year = DateTime.Now.Year;
            for (int i = year; i < year + 2; i++)
            {
                dates.Add(new DateTime(i, 12, 26));
                dates.Add(new DateTime(i, 12, 25));
                dates.Add(new DateTime(i, 12, 24));
                dates.Add(new DateTime(i, 11, 17));
                dates.Add(new DateTime(i, 10, 28));
                dates.Add(new DateTime(i, 07, 06));
                dates.Add(new DateTime(i, 07, 05));
                dates.Add(new DateTime(i, 05, 08));
                dates.Add(new DateTime(i, 05, 01));
                dates.Add(new DateTime(i, 04, 13));
                dates.Add(new DateTime(i, 04, 10));
                dates.Add(new DateTime(i, 01, 01));
            }

            return dates;
        }

        public static readonly List<DateTime> Dates = GetDates();
    }
}