using FirstFloor.ModernUI.Presentation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Thal_Calender_App.src.DataTypes;

namespace Thal_Calender_App.src.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ThalDateUpDown.xaml
    /// </summary>
    public partial class ThalDateUpDown : UserControl, INotifyPropertyChanged
    {
        private ICommand _addCommand;
        private ICommand _subCommand;

        public ThalDateUpDown()
        {
            InitializeComponent();
            DataContext = this;
            Date = new ThalDate(1125, 1, 1);
        }

        public ThalDate Date
        {
            get
            {
                return (ThalDate)GetValue(DateProperty);
            }
            set
            {
                SetValue(DateProperty, value);
                NotifyPropertyChanged();
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(param => IncrementDate(), param => true));
            }
        }

        public ICommand SubstractCommand
        {
            get
            {
                return _subCommand ?? (_subCommand = new RelayCommand(param => DecrementDate(), param => true));
            }
        }

        private void IncrementDate()
        {
            Date = Date.AddDays(1);
        }

        private void DecrementDate()
        {
            Date = Date.AddDays(-1);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(ThalDate), typeof(ThalDateUpDown), new PropertyMetadata(new ThalDate(1,1,1)));

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
