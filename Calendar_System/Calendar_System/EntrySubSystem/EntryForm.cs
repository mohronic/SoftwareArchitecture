using System;
using System.Windows.Forms;

namespace Calendar_System.EntrySubSystem
{
    public class EntryForm : Form
    {
        private readonly EntryControl _entryControl;
        private Entry _entry;
        private Label _entryNameLabel;
        private TextBox _entryNameTb;
        private Label _locationLabel;
        private RichTextBox _descriptionTb;
        private Label _descriptionLabel;
        private TextBox _locationTb;
        private DateTimePicker _startDatePicker;
        private DateTimePicker _endDatePicker;
        private Label _startTimeLabel;
        private Label _endTimeLabel;
        private Button _createEntryButton;
        private Button _cancelButton;
        private Button _addPeopleButton;
        private DateTimePicker _startTimePicker;
        private DateTimePicker _endTimePicker;
        private Button _addWorkgroupButton;
        public EntryForm(EntryControl entryControl, Entry entry)
        {
            _entry = entry;
            _entryControl = entryControl;
            InitializeComponent();
            _entryNameTb.Text = entry.GetEntryName();
            _locationTb.Text = entry.GetLocation();
            if (entry.GetStartDate() == DateTime.MinValue)
            {
                _startDatePicker.Value = DateTime.Now.Date;
                _startTimePicker.Value = DateTime.Now;
            }
            else
            {
                _startDatePicker.Value = entry.GetStartDate().Date;
                _startTimePicker.Value = entry.GetStartDate();
            }
            if (entry.GetEndDate() == DateTime.MinValue)
            {
                _endDatePicker.Value = DateTime.Now.Date;
                _endTimePicker.Value = DateTime.Now;
            }
            else
            {
                _endDatePicker.Value = entry.GetEndDate().Date;
                _endTimePicker.Value = entry.GetEndDate();
            }
        }
        private void InitializeComponent()
        {
            this._entryNameLabel = new System.Windows.Forms.Label();
            this._entryNameTb = new System.Windows.Forms.TextBox();
            this._locationLabel = new System.Windows.Forms.Label();
            this._descriptionTb = new System.Windows.Forms.RichTextBox();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._locationTb = new System.Windows.Forms.TextBox();
            this._startDatePicker = new System.Windows.Forms.DateTimePicker();
            this._endDatePicker = new System.Windows.Forms.DateTimePicker();
            this._startTimeLabel = new System.Windows.Forms.Label();
            this._endTimeLabel = new System.Windows.Forms.Label();
            this._createEntryButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._addPeopleButton = new System.Windows.Forms.Button();
            this._addWorkgroupButton = new System.Windows.Forms.Button();
            this._startTimePicker = new System.Windows.Forms.DateTimePicker();
            this._endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // _entryNameLabel
            // 
            this._entryNameLabel.AutoSize = true;
            this._entryNameLabel.Location = new System.Drawing.Point(12, 9);
            this._entryNameLabel.Name = "_entryNameLabel";
            this._entryNameLabel.Size = new System.Drawing.Size(84, 17);
            this._entryNameLabel.TabIndex = 0;
            this._entryNameLabel.Text = "Entry name:";
            // 
            // _entryNameTb
            // 
            this._entryNameTb.Location = new System.Drawing.Point(103, 9);
            this._entryNameTb.Name = "_entryNameTb";
            this._entryNameTb.Size = new System.Drawing.Size(100, 22);
            this._entryNameTb.TabIndex = 1;
            // 
            // _locationLabel
            // 
            this._locationLabel.AutoSize = true;
            this._locationLabel.Location = new System.Drawing.Point(210, 9);
            this._locationLabel.Name = "_locationLabel";
            this._locationLabel.Size = new System.Drawing.Size(66, 17);
            this._locationLabel.TabIndex = 2;
            this._locationLabel.Text = "Location:";
            // 
            // _descriptionTb
            // 
            this._descriptionTb.Location = new System.Drawing.Point(15, 114);
            this._descriptionTb.Name = "_descriptionTb";
            this._descriptionTb.Size = new System.Drawing.Size(451, 190);
            this._descriptionTb.TabIndex = 5;
            this._descriptionTb.Text = "";
            // 
            // _descriptionLabel
            // 
            this._descriptionLabel.AutoSize = true;
            this._descriptionLabel.Location = new System.Drawing.Point(13, 94);
            this._descriptionLabel.Name = "_descriptionLabel";
            this._descriptionLabel.Size = new System.Drawing.Size(83, 17);
            this._descriptionLabel.TabIndex = 4;
            this._descriptionLabel.Text = "Description:";
            // 
            // _locationTb
            // 
            this._locationTb.Location = new System.Drawing.Point(283, 9);
            this._locationTb.Name = "_locationTb";
            this._locationTb.Size = new System.Drawing.Size(100, 22);
            this._locationTb.TabIndex = 2;
            // 
            // _startDatePicker
            // 
            this._startDatePicker.Location = new System.Drawing.Point(103, 37);
            this._startDatePicker.Name = "_startDatePicker";
            this._startDatePicker.Size = new System.Drawing.Size(200, 22);
            this._startDatePicker.TabIndex = 3;
            // 
            // _endDatePicker
            // 
            this._endDatePicker.Location = new System.Drawing.Point(103, 65);
            this._endDatePicker.Name = "_endDatePicker";
            this._endDatePicker.Size = new System.Drawing.Size(200, 22);
            this._endDatePicker.TabIndex = 4;
            // 
            // _startTimeLabel
            // 
            this._startTimeLabel.AutoSize = true;
            this._startTimeLabel.Location = new System.Drawing.Point(13, 37);
            this._startTimeLabel.Name = "_startTimeLabel";
            this._startTimeLabel.Size = new System.Drawing.Size(44, 17);
            this._startTimeLabel.TabIndex = 8;
            this._startTimeLabel.Text = "From:";
            // 
            // _endTimeLabel
            // 
            this._endTimeLabel.AutoSize = true;
            this._endTimeLabel.Location = new System.Drawing.Point(16, 65);
            this._endTimeLabel.Name = "_endTimeLabel";
            this._endTimeLabel.Size = new System.Drawing.Size(29, 17);
            this._endTimeLabel.TabIndex = 9;
            this._endTimeLabel.Text = "To:";
            // 
            // _createEntryButton
            // 
            this._createEntryButton.Location = new System.Drawing.Point(12, 403);
            this._createEntryButton.Name = "_createEntryButton";
            this._createEntryButton.Size = new System.Drawing.Size(120, 29);
            this._createEntryButton.TabIndex = 6;
            this._createEntryButton.Text = "Create entry";
            this._createEntryButton.UseVisualStyleBackColor = true;
            this._createEntryButton.Click += new System.EventHandler(this._createEntryButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(391, 403);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 29);
            this._cancelButton.TabIndex = 9;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _addPeopleButton
            // 
            this._addPeopleButton.Location = new System.Drawing.Point(138, 403);
            this._addPeopleButton.Name = "_addPeopleButton";
            this._addPeopleButton.Size = new System.Drawing.Size(122, 29);
            this._addPeopleButton.TabIndex = 7;
            this._addPeopleButton.Text = "Add people:";
            this._addPeopleButton.UseVisualStyleBackColor = true;
            this._addPeopleButton.Click += new System.EventHandler(this._addPeopleButton_Click);
            // 
            // _addWorkgroupButton
            // 
            this._addWorkgroupButton.Location = new System.Drawing.Point(268, 403);
            this._addWorkgroupButton.Name = "_addWorkgroupButton";
            this._addWorkgroupButton.Size = new System.Drawing.Size(115, 29);
            this._addWorkgroupButton.TabIndex = 8;
            this._addWorkgroupButton.Text = "Add workgroup:";
            this._addWorkgroupButton.UseVisualStyleBackColor = true;
            this._addWorkgroupButton.Click += new System.EventHandler(this._addWorkgroupButton_Click);
            // 
            // _startTimePicker
            // 
            this._startTimePicker.Location = new System.Drawing.Point(310, 38);
            this._startTimePicker.Name = "_startTimePicker";
            this._startTimePicker.Size = new System.Drawing.Size(156, 22);
            this._startTimePicker.TabIndex = 10;
            this._startTimePicker.Format = DateTimePickerFormat.Time;
            this._startTimePicker.ShowUpDown = true;
            // 
            // _endTimePicker
            // 
            this._endTimePicker.Location = new System.Drawing.Point(310, 67);
            this._endTimePicker.Name = "_endTimePicker";
            this._endTimePicker.Size = new System.Drawing.Size(156, 22);
            this._endTimePicker.TabIndex = 11;
            this._endTimePicker.Format = DateTimePickerFormat.Time;
            this._endTimePicker.ShowUpDown = true;
            // 
            // EntryForm
            // 
            this.ClientSize = new System.Drawing.Size(478, 444);
            this.Controls.Add(this._endTimePicker);
            this.Controls.Add(this._startTimePicker);
            this.Controls.Add(this._addWorkgroupButton);
            this.Controls.Add(this._addPeopleButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._createEntryButton);
            this.Controls.Add(this._endTimeLabel);
            this.Controls.Add(this._startTimeLabel);
            this.Controls.Add(this._endDatePicker);
            this.Controls.Add(this._startDatePicker);
            this.Controls.Add(this._locationTb);
            this.Controls.Add(this._descriptionLabel);
            this.Controls.Add(this._descriptionTb);
            this.Controls.Add(this._locationLabel);
            this.Controls.Add(this._entryNameTb);
            this.Controls.Add(this._entryNameLabel);
            this.Name = "EntryForm";
            this.Text = "Create new entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void _addPeopleButton_Click(object sender, EventArgs e)
        {
            _entryControl.CreateAddPeopleForm();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void _createEntryButton_Click(object sender, EventArgs e)
        {
            if(_entry.UpdateEntry(_startDatePicker.Value.Date + _startTimePicker.Value.TimeOfDay, _endDatePicker.Value.Date + _endTimePicker.Value.TimeOfDay, _locationTb.Text, null, _entryNameTb.Text))
            {
                _entryControl.SendEntryToDb(_entry);
                this.Dispose();
            }
        }

        private void _addWorkgroupButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
