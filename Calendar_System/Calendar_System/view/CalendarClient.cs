using System;
using System.Linq;
using System.Windows.Forms;
using Calendar_System.control;
using Calendar_System.model;

namespace Calendar_System.view
{
    public class CalendarClient : Form
    {
        private AbstractStorage _abstractStorage;
        private control.CalendarControl _cControl;
        private Button _createEntryButton;
        private Button _modifyEntryButton;
        private Button _syncButton;
        private ÁbstractCalendar _calendarView;

        public CalendarClient(control.CalendarControl cControl, AbstractStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            _cControl = cControl;
            _calendarView = new CalendarWeekly();
            InitializeComponent();
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
            this._modifyEntryButton = new System.Windows.Forms.Button();
            this._syncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _createEntryButton
            // 
            this._createEntryButton.Location = new System.Drawing.Point(12, 367);
            this._createEntryButton.Name = "_createEntryButton";
            this._createEntryButton.Size = new System.Drawing.Size(132, 29);
            this._createEntryButton.TabIndex = 0;
            this._createEntryButton.Text = "Create new entry";
            this._createEntryButton.UseVisualStyleBackColor = true;
            this._createEntryButton.Click += new System.EventHandler(this._createEntryButton_Click);
            // 
            // _modifyEntryButton
            // 
            this._modifyEntryButton.Location = new System.Drawing.Point(150, 367);
            this._modifyEntryButton.Name = "_modifyEntryButton";
            this._modifyEntryButton.Size = new System.Drawing.Size(161, 29);
            this._modifyEntryButton.TabIndex = 1;
            this._modifyEntryButton.Text = "Modify existing entry";
            this._modifyEntryButton.UseVisualStyleBackColor = true;
            this._modifyEntryButton.Click += new System.EventHandler(this._modifyEntryButton_Click);
            // 
            // _syncButton
            // 
            this._syncButton.Location = new System.Drawing.Point(318, 368);
            this._syncButton.Name = "_syncButton";
            this._syncButton.Size = new System.Drawing.Size(210, 28);
            this._syncButton.TabIndex = 3;
            this._syncButton.Text = "Sync with Google Calendar";
            this._syncButton.UseVisualStyleBackColor = true;
            this._syncButton.Click += new System.EventHandler(this._syncButton_Click);
            // 
            // CalendarClient
            // 
            this.ClientSize = new System.Drawing.Size(540, 408);
            this.Controls.Add(this._syncButton);
            this.Controls.Add(this._modifyEntryButton);
            this.Controls.Add(this._createEntryButton);
            this.Name = "CalendarClient";
            this.ResumeLayout(false);

        }

        private void _createEntryButton_Click(object sender, EventArgs e)
        {
            _cControl.CreateEntryControl("newEntry");
        }

        private void _modifyEntryButton_Click(object sender, EventArgs e)
        {
            _cControl.CreateEntryControl("modifyEntry");
        }

        private void _syncButton_Click(object sender, EventArgs e)
        {
            _cControl.CreateSyncControl();
        }
    }
}
