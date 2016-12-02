namespace Thal_Calender_App.DataTypes
{
    class ThalDateTime
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Enums.DayOfWeek getDayOfWeek()
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
}
