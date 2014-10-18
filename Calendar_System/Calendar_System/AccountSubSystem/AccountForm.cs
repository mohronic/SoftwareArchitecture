using System;
using System.Windows.Forms;

namespace Calendar_System.AccountSubSystem
{
    public class AccountForm : Form
    {
        private readonly AccountControl _accountControl;
        private User _user;
        private Label _lastNameLabel;
        private TextBox _lastNameTB;
        private TextBox _firstNameTB;
        private Label _emailLabel;
        private TextBox _emailTB;
        private TextBox _phoneTB;
        private Label _telephoneLabel;
        private Button _saveAccountButton;
        private Button _cancelButton;
        private CheckBox _adminCheckBox;
        private Label _adminLabel;
        private TextBox _passwordTB;
        private Label _passwordLabel;
        private Label _firstNameLabel;
        public AccountForm(AccountControl accountControl, User user)
        {
            _user = user;
            _accountControl = accountControl;
            InitializeComponent();
            _firstNameTB.Text = _user.GetFirstName();
            _lastNameTB.Text = _user.GetLastName();
            _phoneTB.Text = _user.GetPhone();
            _emailTB.Text = _user.GetEmail();
            _adminCheckBox.Checked = _user.GetAdmin();
        }
        private void InitializeComponent()
        {
            this._firstNameLabel = new System.Windows.Forms.Label();
            this._lastNameLabel = new System.Windows.Forms.Label();
            this._lastNameTB = new System.Windows.Forms.TextBox();
            this._firstNameTB = new System.Windows.Forms.TextBox();
            this._emailLabel = new System.Windows.Forms.Label();
            this._emailTB = new System.Windows.Forms.TextBox();
            this._phoneTB = new System.Windows.Forms.TextBox();
            this._telephoneLabel = new System.Windows.Forms.Label();
            this._saveAccountButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._adminCheckBox = new System.Windows.Forms.CheckBox();
            this._adminLabel = new System.Windows.Forms.Label();
            this._passwordTB = new System.Windows.Forms.TextBox();
            this._passwordLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _firstNameLabel
            // 
            this._firstNameLabel.AutoSize = true;
            this._firstNameLabel.Location = new System.Drawing.Point(12, 9);
            this._firstNameLabel.Name = "_firstNameLabel";
            this._firstNameLabel.Size = new System.Drawing.Size(58, 13);
            this._firstNameLabel.TabIndex = 0;
            this._firstNameLabel.Text = "First name:";
            // 
            // _lastNameLabel
            // 
            this._lastNameLabel.AutoSize = true;
            this._lastNameLabel.Location = new System.Drawing.Point(181, 9);
            this._lastNameLabel.Name = "_lastNameLabel";
            this._lastNameLabel.Size = new System.Drawing.Size(59, 13);
            this._lastNameLabel.TabIndex = 0;
            this._lastNameLabel.Text = "Last name:";
            // 
            // _lastNameTB
            // 
            this._lastNameTB.Location = new System.Drawing.Point(184, 29);
            this._lastNameTB.Name = "_lastNameTB";
            this._lastNameTB.Size = new System.Drawing.Size(163, 20);
            this._lastNameTB.TabIndex = 2;
            // 
            // _firstNameTB
            // 
            this._firstNameTB.Location = new System.Drawing.Point(15, 29);
            this._firstNameTB.Name = "_firstNameTB";
            this._firstNameTB.Size = new System.Drawing.Size(163, 20);
            this._firstNameTB.TabIndex = 1;
            // 
            // _emailLabel
            // 
            this._emailLabel.AutoSize = true;
            this._emailLabel.Location = new System.Drawing.Point(12, 91);
            this._emailLabel.Name = "_emailLabel";
            this._emailLabel.Size = new System.Drawing.Size(35, 13);
            this._emailLabel.TabIndex = 0;
            this._emailLabel.Text = "Email:";
            // 
            // _emailTB
            // 
            this._emailTB.Location = new System.Drawing.Point(15, 107);
            this._emailTB.Name = "_emailTB";
            this._emailTB.Size = new System.Drawing.Size(332, 20);
            this._emailTB.TabIndex = 4;
            // 
            // _phoneTB
            // 
            this._phoneTB.Location = new System.Drawing.Point(15, 146);
            this._phoneTB.Name = "_phoneTB";
            this._phoneTB.Size = new System.Drawing.Size(332, 20);
            this._phoneTB.TabIndex = 5;
            // 
            // _telephoneLabel
            // 
            this._telephoneLabel.AutoSize = true;
            this._telephoneLabel.Location = new System.Drawing.Point(12, 130);
            this._telephoneLabel.Name = "_telephoneLabel";
            this._telephoneLabel.Size = new System.Drawing.Size(61, 13);
            this._telephoneLabel.TabIndex = 0;
            this._telephoneLabel.Text = "Telephone:";
            // 
            // _saveAccountButton
            // 
            this._saveAccountButton.Location = new System.Drawing.Point(13, 353);
            this._saveAccountButton.Name = "_saveAccountButton";
            this._saveAccountButton.Size = new System.Drawing.Size(122, 28);
            this._saveAccountButton.TabIndex = 7;
            this._saveAccountButton.Text = "Save account";
            this._saveAccountButton.UseVisualStyleBackColor = true;
            this._saveAccountButton.Click += new System.EventHandler(this._saveAccountButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(246, 353);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(105, 28);
            this._cancelButton.TabIndex = 8;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _adminCheckBox
            // 
            this._adminCheckBox.AutoSize = true;
            this._adminCheckBox.Location = new System.Drawing.Point(88, 172);
            this._adminCheckBox.Name = "_adminCheckBox";
            this._adminCheckBox.Size = new System.Drawing.Size(44, 17);
            this._adminCheckBox.TabIndex = 6;
            this._adminCheckBox.Text = "Yes";
            this._adminCheckBox.UseVisualStyleBackColor = true;
            // 
            // _adminLabel
            // 
            this._adminLabel.AutoSize = true;
            this._adminLabel.Location = new System.Drawing.Point(12, 173);
            this._adminLabel.Name = "_adminLabel";
            this._adminLabel.Size = new System.Drawing.Size(70, 13);
            this._adminLabel.TabIndex = 0;
            this._adminLabel.Text = "Administrator:";
            // 
            // textBox1
            // 
            this._passwordTB.Location = new System.Drawing.Point(15, 68);
            this._passwordTB.Name = "_passwordTB";
            this._passwordTB.PasswordChar = '*';
            this._passwordTB.Size = new System.Drawing.Size(332, 20);
            this._passwordTB.TabIndex = 3;
            // 
            // _passwordTB
            // 
            this._passwordLabel.AutoSize = true;
            this._passwordLabel.Location = new System.Drawing.Point(12, 52);
            this._passwordLabel.Name = "_passwordLabel";
            this._passwordLabel.Size = new System.Drawing.Size(56, 13);
            this._passwordLabel.TabIndex = 0;
            this._passwordLabel.Text = "Password:";
            // 
            // AccountForm
            // 
            this.ClientSize = new System.Drawing.Size(363, 393);
            this.Controls.Add(this._passwordLabel);
            this.Controls.Add(this._passwordTB);
            this.Controls.Add(this._adminLabel);
            this.Controls.Add(this._adminCheckBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._saveAccountButton);
            this.Controls.Add(this._telephoneLabel);
            this.Controls.Add(this._phoneTB);
            this.Controls.Add(this._emailTB);
            this.Controls.Add(this._emailLabel);
            this.Controls.Add(this._firstNameTB);
            this.Controls.Add(this._lastNameTB);
            this.Controls.Add(this._lastNameLabel);
            this.Controls.Add(this._firstNameLabel);
            this.Name = "AccountForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void _saveAccountButton_Click(object sender, EventArgs e)
        {
            if(_user.UpdateUser(_firstNameTB.Text, _lastNameTB.Text, _emailTB.Text, _phoneTB.Text, _passwordTB.Text, _adminCheckBox.Checked))
            {
                _accountControl.SendAccountToDb(_user);
                this.Dispose();
            }      
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
