using System;
using System.Linq;
using System.Windows.Forms;
using Calendar_System.control;
using Calendar_System.model;

namespace Calendar_System.view
{
    class CalendarClient : Form
    {
        private AbstractStorage _abstractStorage = new StorageImp();
        private control.CalendarControl _cControl;
        private Button _createEntryButton;
        private ÁbstractCalendar _calendarView;

        public CalendarClient(control.CalendarControl cControl)
        {
            _cControl = cControl;
            _calendarView = new CalendarWeekly();
            InitializeComponent();
        }

        private void Setup()
        {
            Console.Out.WriteLine("Hello");
            //TODO create menu
            //TODO add calendarView
        }
        //Changes the view from weekView to monthView and vice versa.
        private void ChangeView()
        {
            if (_calendarView.GetType() == typeof(CalendarWeekly))
            {
                _calendarView = new CalendarMonthly();
            }
            else
            {
                _calendarView = new CalendarWeekly();
            }
        }

        private void InitializeComponent()
        {
            this._createEntryButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _createEntryButton
            // 
            this._createEntryButton.Location = new System.Drawing.Point(12, 12);
            this._createEntryButton.Name = "_createEntryButton";
            this._createEntryButton.Size = new System.Drawing.Size(132, 29);
            this._createEntryButton.TabIndex = 0;
            this._createEntryButton.Text = "Create new entry";
            this._createEntryButton.UseVisualStyleBackColor = true;
            this._createEntryButton.Click += new System.EventHandler(this._createEntryButton_Click);
            // 
            // CalendarClient
            // 
            this.ClientSize = new System.Drawing.Size(540, 408);
            this.Controls.Add(this._createEntryButton);
            this.Name = "CalendarClient";
            this.ResumeLayout(false);

        }

        private void _createEntryButton_Click(object sender, EventArgs e)
        {
            _cControl.CreateEntryControl();
        }
    }
}
