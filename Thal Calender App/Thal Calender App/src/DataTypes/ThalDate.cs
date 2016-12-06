using System;

namespace Thal_Calender_App.src.DataTypes
{
    public class ThalDate
    {
        public ThalDate(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public ThalDate()
        {
            Year = 0;
            Month = 1;
            Day = 1;
        }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Enums.DayOfWeek DayOfWeek
        {
            get
            {
                // Das Thal Jahr hat 14 Monate mit jeweils 27 Tagen
                // dadurch ergibt sich bei der Formel entsprechende offsets
                // welche die Verschiebungen korrigieren die sich aus der ungeraden 
                // Anzahl der Tage pro Monat ergibt. Das Jahr ist irrelevant weil wir
                // keine Schaltjahre haben und das offset sich nach 7 Monaten wiederholt
                var offset = new int[] { 0, 5, 3, 1, 6, 4, 2, 0, 5, 3, 1, 6, 4, 2 };

                return (Enums.DayOfWeek)((Day + Month + offset[Month - 1]) % 7);
            }     
        }

        // Die Methode funktioniert nur wenn wir wenige Tage benutzen
        // wie das errechenen des offsets zum ersten des Monats
        // für alles andere reicht das nicht
        public ThalDate AddDays(int dayCount)
        {
            var tmp = Day + dayCount;

            if (tmp < 0)
            {
                if (Month == 1)
                {
                    return new ThalDate() { Day = 27 + tmp, Month = 14, Year = Year - 1 };
                }
                else
                {
                    return new ThalDate() { Day = 27 + tmp, Month = Month - 1, Year = Year };
                }

            }
            else if(tmp > 27)
            {
                if(Month == 14)
                {
                    return new ThalDate() { Day = tmp - 27, Month = 1, Year = Year + 1 };
                }
                else
                {
                    return new ThalDate() { Day = tmp - 27, Month = Month + 1, Year = Year };                    
                }
                
            } else
            {
                return new ThalDate() { Day = tmp, Month = Month, Year = Year };
            }
        }

        public string toString()
        {
            return Day + "." + Month + "." + Year;
        }

        public static ThalDate parse(string dateString)
        {
            var parts = dateString.Split('.');
            return new ThalDate() { Day = Convert.ToInt32(parts[0]), Month = Convert.ToInt32(parts[1]), Year = Convert.ToInt32(parts[2]) };
        }

        public int DayOfWeekNumber()
        {
            var dow = DayOfWeek;

            switch(dow)
            {
                case Enums.DayOfWeek.Montag: return 1;
                case Enums.DayOfWeek.Dienstag: return 2;
                case Enums.DayOfWeek.Mittwoch: return 3;
                case Enums.DayOfWeek.Donnerstag: return 4;
                case Enums.DayOfWeek.Freitag: return 5;
                case Enums.DayOfWeek.Samstag: return 6;
                case Enums.DayOfWeek.Sonntag: return 7;
                default: return 0;
            }
        }
    }
}
