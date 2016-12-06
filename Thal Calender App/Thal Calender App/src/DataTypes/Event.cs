using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thal_Calender_App.src.DataTypes
{
    class Event
    {
        public ThalDate Date
        {
            get;
            set;
        }

        public string title
        {
            get; set;
        }

        public string notes
        {
            get; set;
        }
    }
}
