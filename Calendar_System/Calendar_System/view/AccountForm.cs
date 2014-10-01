using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar_System.model;

namespace Calendar_System.view
{
    class AccountForm : Form
    {
        private Label _lastNameLabel;
        private TextBox _lastNameTB;
        private TextBox _firstNameTB;
        private Label _emailLabel;
        private TextBox _emailTB;
        private TextBox _phoneTB;
        private Label _telephoneLabel;
        private Label _firstNameLabel;
        //For new account
        public AccountForm() { }
        
        //For existing account
        public AccountForm(User user)
        {
            InitializeComponent();
            _firstNameTB.Text = user.FirstName;
            _lastNameTB.Text = user.LastName;
            _phoneTB.Text = user.Phone;
            _emailTB.Text = user.Email;
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
            this.SuspendLayout();
            // 
            // _firstNameLabel
            // 
            this._firstNameLabel.AutoSize = true;
            this._firstNameLabel.Location = new System.Drawing.Point(12, 9);
            this._firstNameLabel.Name = "_firstNameLabel";
            this._firstNameLabel.Size = new System.Drawing.Size(78, 17);
            this._firstNameLabel.TabIndex = 0;
            this._firstNameLabel.Text = "First name:";
            // 
            // _lastNameLabel
            // 
            this._lastNameLabel.AutoSize = true;
            this._lastNameLabel.Location = new System.Drawing.Point(181, 9);
            this._lastNameLabel.Name = "_lastNameLabel";
            this._lastNameLabel.Size = new System.Drawing.Size(78, 17);
            this._lastNameLabel.TabIndex = 1;
            this._lastNameLabel.Text = "Last name:";
            // 
            // _lastNameTB
            // 
            this._lastNameTB.Location = new System.Drawing.Point(184, 29);
            this._lastNameTB.Name = "_lastNameTB";
            this._lastNameTB.Size = new System.Drawing.Size(163, 22);
            this._lastNameTB.TabIndex = 2;
            // 
            // _firstNameTB
            // 
            this._firstNameTB.Location = new System.Drawing.Point(15, 29);
            this._firstNameTB.Name = "_firstNameTB";
            this._firstNameTB.Size = new System.Drawing.Size(163, 22);
            this._firstNameTB.TabIndex = 3;
            // 
            // _emailLabel
            // 
            this._emailLabel.AutoSize = true;
            this._emailLabel.Location = new System.Drawing.Point(12, 54);
            this._emailLabel.Name = "_emailLabel";
            this._emailLabel.Size = new System.Drawing.Size(46, 17);
            this._emailLabel.TabIndex = 4;
            this._emailLabel.Text = "Email:";
            // 
            // _emailTB
            // 
            this._emailTB.Location = new System.Drawing.Point(15, 74);
            this._emailTB.Name = "_emailTB";
            this._emailTB.Size = new System.Drawing.Size(332, 22);
            this._emailTB.TabIndex = 5;
            // 
            // _phoneTB
            // 
            this._phoneTB.Location = new System.Drawing.Point(15, 119);
            this._phoneTB.Name = "_phoneTB";
            this._phoneTB.Size = new System.Drawing.Size(332, 22);
            this._phoneTB.TabIndex = 6;
            // 
            // _telephoneLabel
            // 
            this._telephoneLabel.AutoSize = true;
            this._telephoneLabel.Location = new System.Drawing.Point(12, 99);
            this._telephoneLabel.Name = "_telephoneLabel";
            this._telephoneLabel.Size = new System.Drawing.Size(80, 17);
            this._telephoneLabel.TabIndex = 7;
            this._telephoneLabel.Text = "Telephone:";
            // 
            // AccountForm
            // 
            this.ClientSize = new System.Drawing.Size(363, 393);
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
    }
}
