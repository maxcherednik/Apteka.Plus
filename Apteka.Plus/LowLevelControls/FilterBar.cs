using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace Apteka.Plus.LowLevelControls
{
    public partial class FilterBar : UserControl
    {
        private DateRange currentDateRange;

        #region Constructor
        public FilterBar()
        {
            InitializeComponent();
        }
        #endregion

        public enum DateRange
        {
            None,
            ExactDate,
            Month,
            ExactDateRange,
            MonthRange
        }

        #region Public properties
        [Browsable(true)]
        [DefaultValue(DateRange.ExactDate)]
        public DateRange DateTimePickerType
        {
            get
            {
                return currentDateRange;
            }
            set
            {
                currentDateRange = value;
                SetupDateTimePicker(currentDateRange);
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool ShowGraphicsButton
        {
            get
            {
                return btnShowGraphics.Visible;
            }
            set
            {
                btnShowGraphics.Visible = value;
            }
        }

        [Browsable(true)]
        [DefaultValue(true)]
        public bool ShowStoreComboBox
        {
            get
            {
                return cbStores.Visible;
            }
            set
            {
                lblStore.Visible = value;
                cbStores.Visible = value;
            }
        }
        #endregion

        #region Events
        #region ShowGraphicsButtonPressed event
        public class ShowGraphicsButtonPressedEventArgs : EventArgs { }

        [Browsable(true)]
        public event EventHandler<ShowGraphicsButtonPressedEventArgs> ShowGraphicsButtonPressed;

        protected virtual void OnShowGraphicsButtonPressed()
        {
            var handler = ShowGraphicsButtonPressed;
            if (handler != null)
                handler(this, new ShowGraphicsButtonPressedEventArgs());
        }
        #endregion

        #region ShowButtonPressed event
        public class ShowButtonPressedEventArgs : EventArgs { }

        [Browsable(true)]
        public event EventHandler<ShowButtonPressedEventArgs> ShowButtonPressed;

        protected virtual void OnShowButtonPressed()
        {
            var handler = ShowButtonPressed;
            if (handler != null)
                handler(this, new ShowButtonPressedEventArgs());
        }
        #endregion


        #endregion

        private void btnShow_Click(object sender, EventArgs e)
        {
            //DisableAll();
            OnShowButtonPressed();
        }

        private void btnShowGraphics_Click(object sender, EventArgs e)
        {
            OnShowGraphicsButtonPressed();
        }

        #region Private methods
        private void DisableAll()
        {
            throw new NotImplementedException();
        }
        private void SetupDateTimePicker(DateRange dateRange)
        {
            switch (dateRange)
            {
                case DateRange.None:
                    dtpFirst.Visible = false;
                    lblDateFirst.Visible = false;
                    dtpSecond.Visible = false;
                    lblDateSecond.Visible = false;
                    break;
                case DateRange.ExactDate:
                    lblDateFirst.Text = "День:";
                    
                    dtpFirst.Format = DateTimePickerFormat.Long;
                    
                    lblDateFirst.Visible = true;
                    dtpFirst.Visible = true;
                    lblDateSecond.Visible = false;
                    dtpSecond.Visible = false;

                    break;
                case DateRange.Month:
                    lblDateFirst.Text = "Месяц:";

                    dtpFirst.Format = DateTimePickerFormat.Custom;
                    dtpFirst.CustomFormat = "MMMM yyyy";

                    lblDateFirst.Visible = true;
                    dtpFirst.Visible = true;
                    dtpSecond.Visible = false;
                    lblDateSecond.Visible = false;
                    break;
                case DateRange.ExactDateRange:
                    lblDateFirst.Text = "С:";
                    lblDateSecond.Text = "По:";

                    dtpFirst.Format = DateTimePickerFormat.Long;
                    dtpSecond.Format = DateTimePickerFormat.Long;

                    lblDateFirst.Visible = true;
                    dtpFirst.Visible = true;
                    lblDateSecond.Visible = true;
                    dtpSecond.Visible = true;
                    break;
                case DateRange.MonthRange:
                    lblDateFirst.Text = "С:";
                    lblDateSecond.Text = "По:";

                    dtpFirst.Format = DateTimePickerFormat.Custom;
                    dtpFirst.CustomFormat = "MMMM yyyy";

                    dtpSecond.Format = DateTimePickerFormat.Custom;
                    dtpSecond.CustomFormat = "MMMM yyyy";


                    lblDateFirst.Visible = true;
                    dtpFirst.Visible = true;
                    lblDateSecond.Visible = true;
                    dtpSecond.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
