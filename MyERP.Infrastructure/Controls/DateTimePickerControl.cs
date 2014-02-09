using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MyERP.Controls
{
    [TemplatePart(Name = "PART_LayoutRoot", Type = typeof(Panel))]
    public class DateTimePickerControl : Control
    {
        private Panel rootPanel;
        private DateTimePickerViewModel innerViewModel;

        // Using a DependencyProperty as the backing store for CanUserSelectTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanUserSelectTimeProperty =
        DependencyProperty.Register("CanUserSelectTime", typeof(bool), typeof(DateTimePickerControl), new PropertyMetadata(true));

        // Using a DependencyProperty as the backing store for SelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValueProperty =
        DependencyProperty.Register("SelectedValue", typeof(DateTime), typeof(DateTimePickerControl), new PropertyMetadata(DateTime.MinValue, OnSelectedValuePropertyChanged));

        public DateTimePickerControl()
        {
            //this.Unloaded += this.OnDateTimePickerControlUnloaded;
        }

        private static void OnSelectedValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newDateTime = (DateTime)e.NewValue;
            var dateTimePicker = (d as DateTimePickerControl);

            if (dateTimePicker.innerViewModel != null)
            {
                dateTimePicker.innerViewModel.PropertyChanged -= dateTimePicker.OnViewModelPropertyChanged;
                dateTimePicker.innerViewModel.UpdateDate(newDateTime);
                dateTimePicker.innerViewModel.PropertyChanged += dateTimePicker.OnViewModelPropertyChanged;
            }
        }

        public bool CanUserSelectTime
        {
            get
            {
                return (bool)GetValue(CanUserSelectTimeProperty);
            }
            set
            {
                SetValue(CanUserSelectTimeProperty, value);
            }
        }

        public DateTime SelectedValue
        {
            get
            {
                return (DateTime)GetValue(SelectedValueProperty);
            }
            set
            {
                SetValue(SelectedValueProperty, value);
            }
        }

        void OnDateTimePickerControlUnloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= this.OnDateTimePickerControlUnloaded;
            innerViewModel.PropertyChanged -= this.OnViewModelPropertyChanged;
        }

        public override void OnApplyTemplate()
        {
            this.rootPanel = this.GetTemplateChild("PART_LayoutRoot") as Panel;

            this.innerViewModel = this.rootPanel.DataContext as DateTimePickerViewModel;
            this.innerViewModel.UpdateDate(this.SelectedValue);
            this.innerViewModel.PropertyChanged += this.OnViewModelPropertyChanged;

            base.OnApplyTemplate();
        }

        private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.SelectedValue = (sender as DateTimePickerViewModel).Date;
        }
    }

    public class DateTimePickerViewModel : INotifyPropertyChanged
    {
        private int day;
        private int month;
        private int year;
        private int minute;
        private int hour;

        public DateTimePickerViewModel()
        {
            var dateTime = DateTime.MinValue;
            this.day = dateTime.Day;
            this.month = dateTime.Month;
            this.year = dateTime.Year;
            this.minute = dateTime.Minute;
            this.hour = dateTime.Hour;
        }

        internal void UpdateDate(DateTime dateTime)
        {
            this.Year = dateTime.Year;
            this.Month = dateTime.Month;
            this.Day = dateTime.Day;
            this.Hour = dateTime.Hour;
            this.Minute = dateTime.Minute;
        }

        public DateTime Date
        {
            get
            {
                return new DateTime(year, month, day, hour, minute, 0);
            }
        }

        public int Day
        {
            get
            {
                return this.day;
            }
            set
            {
                this.day = value;
                this.RaisePropertyChanged("Day");
                this.RaisePropertyChanged("DayString");
            }
        }

        public int Month
        {
            get
            {
                return this.month;
            }
            set
            {
                this.month = value;
                if (DateTime.DaysInMonth(this.Year, value) < this.Day)
                {
                    this.day = DateTime.DaysInMonth(this.Year, value);
                    this.RaisePropertyChanged("Day");
                }
                this.RaisePropertyChanged("Month");
                this.RaisePropertyChanged("MonthString");
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
                this.RaisePropertyChanged("Year");
                this.RaisePropertyChanged("YearString");
            }
        }

        public int Hour
        {
            get
            {
                return this.hour;
            }
            set
            {
                this.hour = value;
                this.RaisePropertyChanged("Hour");
                this.RaisePropertyChanged("HourString");
                this.RaisePropertyChanged("AMPMString");
            }
        }

        public int AMPMHour
        {
            get
            {
                return this.hour;
            }
            set
            {
                if (Math.Abs(this.hour - value) < 12)
                {
                    this.RaisePropertyChanged("AMPMHour");
                    return;
                }

                this.hour = value;
                this.RaisePropertyChanged("Hour");
                this.RaisePropertyChanged("HourString");
                this.RaisePropertyChanged("AMPMString");
            }
        }

        public int Minute
        {
            get
            {
                return this.minute;
            }
            set
            {
                this.minute = value;
                this.RaisePropertyChanged("Minute");
                this.RaisePropertyChanged("MinuteString");
            }
        }

        public string MonthString
        {
            get
            {
                return String.Format("{0:MMM}", this.Date).ToUpper();
            }
        }

        public string DayString
        {
            get
            {
                return String.Format("{0:dd}", this.Date);
            }
        }

        public string YearString
        {
            get
            {
                return String.Format("{0:yyyy}", this.Date);
            }
        }

        public string HourString
        {
            get
            {
                return String.Format("{0:hh}", this.Date).ToUpper();
            }
        }

        public string MinuteString
        {
            get
            {
                return String.Format("{0:mm}", this.Date).ToUpper();
            }
        }

        public string AMPMString
        {
            get
            {
                return String.Format("{0:tt}", this.Date);
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
