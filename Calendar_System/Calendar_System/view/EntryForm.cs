using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar_System.control;
using Calendar_System.model;

namespace Calendar_System.view
{
    class EntryForm : Form
    {
        private readonly EntryControl _entryControl;
        private Label _entryNameLabel;
        private TextBox _entryNameTb;
        private Label _locationLabel;
        private RichTextBox _descriptionTb;
        private Label _descriptionLabel;
        private TextBox _locationTb;
        private DateTimePicker _startTimePicker;
        private DateTimePicker _endTimePicker;
        private Label _startTimeLabel;
        private Label _endTimeLabel;
        private Button _createEntryButton;
        private Button _cancelButton;
        private AddPeopleForm _addPeopleForm;
        public EntryForm(EntryControl entryControl, Entry entry)
        {
            _entryControl = entryControl;
            _addPeopleForm = new AddPeopleForm(entry.UserList);
        }

        public EntryForm(EntryControl entryControl)
        {
            _entryControl = entryControl;
            _addPeopleForm = new AddPeopleForm(new List<User>());
        }

        public void SendEntryToControl()
        {
            var entry = new Entry(_startTimePicker.Value, _endTimePicker.Value, _locationTb.Text, _addPeopleForm.GetUserList());
            _entryControl.SendEntryToDb(entry);
        }

        private void InitializeComponent()
        {
            this._entryNameLabel = new System.Windows.Forms.Label();
            this._entryNameTb = new System.Windows.Forms.TextBox();
            this._locationLabel = new System.Windows.Forms.Label();
            this._descriptionTb = new System.Windows.Forms.RichTextBox();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._locationTb = new System.Windows.Forms.TextBox();
            this._startTimePicker = new System.Windows.Forms.DateTimePicker();
            this._endTimePicker = new System.Windows.Forms.DateTimePicker();
            this._startTimeLabel = new System.Windows.Forms.Label();
            this._endTimeLabel = new System.Windows.Forms.Label();
            this._createEntryButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
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
            this._descriptionTb.TabIndex = 3;
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
            this._locationTb.TabIndex = 5;
            // 
            // _startTimePicker
            // 
            this._startTimePicker.Location = new System.Drawing.Point(103, 37);
            this._startTimePicker.Name = "_startTimePicker";
            this._startTimePicker.Size = new System.Drawing.Size(200, 22);
            this._startTimePicker.TabIndex = 6;
            // 
            // _endTimePicker
            // 
            this._endTimePicker.Location = new System.Drawing.Point(103, 65);
            this._endTimePicker.Name = "_endTimePicker";
            this._endTimePicker.Size = new System.Drawing.Size(200, 22);
            this._endTimePicker.TabIndex = 7;
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
            this._createEntryButton.Location = new System.Drawing.Point(15, 354);
            this._createEntryButton.Name = "_createEntryButton";
            this._createEntryButton.Size = new System.Drawing.Size(120, 23);
            this._createEntryButton.TabIndex = 10;
            this._createEntryButton.Text = "Create entry";
            this._createEntryButton.UseVisualStyleBackColor = true;
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(391, 354);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 11;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // EntryForm
            // 
            this.ClientSize = new System.Drawing.Size(478, 389);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._createEntryButton);
            this.Controls.Add(this._endTimeLabel);
            this.Controls.Add(this._startTimeLabel);
            this.Controls.Add(this._endTimePicker);
            this.Controls.Add(this._startTimePicker);
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
    }
}
