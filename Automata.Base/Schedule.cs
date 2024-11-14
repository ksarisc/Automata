using System;

namespace Automata.Base
{
    public class Schedule
    {
        public DateTimeOffset CreatedOn { get; set; }
        public string TimeZone { get; set; } = string.Empty;

        public DayOfWeek DayOfWeek { get; set; }

        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
        public int Days { get; set; }
        public short Weeks { get; set; }
        public short Months {  get; set; }
        public short Quarters { get; set; }
        public short Years { get; set; }

        public bool BusinessDaysOnly { get; set; }

        public DateTimeOffset GetNextRunOn()
        {
            var now = DateTimeOffset.Now;

            // shift based on timezone

            // check skip days

            // check amount of time to pass

            return now;
        }

        private static DateTimeOffset AddBusinessDays(DateTimeOffset start, int days)
        {
            var dto = start.AddDays(days);
            // check Holiday via API?
            if (dto.DayOfWeek == DayOfWeek.Saturday) return dto.AddDays(2);
            if (dto.DayOfWeek == DayOfWeek.Sunday) return dto.AddDays(1);

            return dto;
        }
    }
}
