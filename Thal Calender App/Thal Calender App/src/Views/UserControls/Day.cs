﻿using System;
using System.ComponentModel;
using Thal_Calender_App.DataTypes;

namespace Thal_Calender_App.src.Views.UserControls
{
    public class Day : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ThalDate date;
        private string notes;
        private bool enabled;
        private bool isTargetMonth;
        private bool isToday;

        public bool IsToday
        {
            get { return isToday; }
            set
            {
                isToday = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsToday"));
            }
        }

        public bool IsTargetMonth
        {
            get { return isTargetMonth; }
            set
            {
                isTargetMonth = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsTargetMonth"));
            }
        }

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Enabled"));
            }
        }

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Notes"));
            }
        }

        public ThalDate Date
        {
            get { return date; }
            set
            {
                date = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Date"));
            }
        }
    }
}
