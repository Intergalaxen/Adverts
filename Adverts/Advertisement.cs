using System;

namespace Adverts
{
    class Advertisement
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime StartEndDateTime { get; set; }

        public string GetWeekday()
        {
            return StartEndDateTime.DayOfWeek.ToString();
        }

        public bool EndsSoon()
        {
            var TwelveHoursLesft = DateTime.Now;
            TwelveHoursLesft = TwelveHoursLesft.AddHours(12);
            if (StartEndDateTime > TwelveHoursLesft)
                return false;
            return true;
        }
    }
}
