using System.Collections.Generic;
using System.Windows.Forms;
using Calendar_System.AccountSubSystem;

namespace Calendar_System.WorkgroupSubSystem
{
    public class WorkgroupForm : Form
    {
        private readonly WorkgroupControl _workgroupControl;
        private Workgroup _workgroup;
        private List<ProxyUser> _userList; 
        private TextBox _workgroupNameTB;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn _firstName;
        private DataGridViewTextBoxColumn _lastName;
        private DataGridViewTextBoxColumn _email;
        private DataGridViewTextBoxColumn _phone;
        private BindingSource workgroupFormBindingSource;
        private System.ComponentModel.IContainer components;
        private Button _saveChangesButton;
        private Button _cancelButton;
        private Button _addPeopleButton;
        private Label _workgroupNameLabel;

        public WorkgroupForm(Workgroup workgroup)
        {
            InitializeComponent();
            _workgroupNameTB.Text = workgroup.GetWorkgroupName();
            if (workgroup.GetUserList() != null && workgroup.GetUserList().Count !=0)
            {
                foreach (var user in workgroup.GetUserList())
                {
                    // Add users to list and display them
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._workgroupNameLabel = new System.Windows.Forms.Label();
            this._workgroupNameTB = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workgroupFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._saveChangesButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._addPeopleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workgroupFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _workgroupNameLabel
            // 
            this._workgroupNameLabel.AutoSize = true;
            this._workgroupNameLabel.Location = new System.Drawing.Point(13, 13);
            this._workgroupNameLabel.Name = "_workgroupNameLabel";
            this._workgroupNameLabel.Size = new System.Drawing.Size(92, 13);
            this._workgroupNameLabel.TabIndex = 0;
            this._workgroupNameLabel.Text = "Workgroup name:";
            // 
            // _workgroupNameTB
            // 
            this._workgroupNameTB.Location = new System.Drawing.Point(141, 13);
            this._workgroupNameTB.Name = "_workgroupNameTB";
            this._workgroupNameTB.Size = new System.Drawing.Size(340, 20);
            this._workgroupNameTB.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._firstName,
            this._lastName,
            this._email,
            this._phone});
            this.dataGridView1.Location = new System.Drawing.Point(16, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(465, 295);
            this.dataGridView1.TabIndex = 2;
            // 
            // _firstName
            // 
            this._firstName.HeaderText = "First name:";
            this._firstName.Name = "_firstName";
            this._firstName.ReadOnly = true;
            // 
            // _lastName
            // 
            this._lastName.HeaderText = "Last name:";
            this._lastName.Name = "_lastName";
            this._lastName.ReadOnly = true;
            // 
            // _email
            // 
            this._email.HeaderText = "Email:";
            this._email.Name = "_email";
            this._email.ReadOnly = true;
            // 
            // _phone
            // 
            this._phone.HeaderText = "Phone:";
            this._phone.Name = "_phone";
            this._phone.ReadOnly = true;
            // 
            // _saveChangesButton
            // 
            this._saveChangesButton.Location = new System.Drawing.Point(16, 378);
            this._saveChangesButton.Name = "_saveChangesButton";
            this._saveChangesButton.Size = new System.Drawing.Size(118, 34);
            this._saveChangesButton.TabIndex = 3;
            this._saveChangesButton.Text = "Save changes";
            this._saveChangesButton.UseVisualStyleBackColor = true;
            this._saveChangesButton.Click += new System.EventHandler(this._saveChangesButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(367, 378);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(114, 34);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _addPeopleButton
            // 
            this._addPeopleButton.Location = new System.Drawing.Point(141, 378);
            this._addPeopleButton.Name = "_addPeopleButton";
            this._addPeopleButton.Size = new System.Drawing.Size(118, 34);
            this._addPeopleButton.TabIndex = 5;
            this._addPeopleButton.Text = "Add people";
            this._addPeopleButton.UseVisualStyleBackColor = true;
            // 
            // WorkgroupForm
            // 
            this.ClientSize = new System.Drawing.Size(493, 424);
            this.Controls.Add(this._addPeopleButton);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._saveChangesButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this._workgroupNameTB);
            this.Controls.Add(this._workgroupNameLabel);
            this.Name = "WorkgroupForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workgroupFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void _saveChangesButton_Click(object sender, System.EventArgs e)
        {
            if(_workgroup.UpdateWorkGroup(_workgroupNameTB.Text, _userList))
            {
                _workgroupControl.SendWorkgroupToDb(_workgroup);
                this.Dispose();
            }
        }
    }
}
