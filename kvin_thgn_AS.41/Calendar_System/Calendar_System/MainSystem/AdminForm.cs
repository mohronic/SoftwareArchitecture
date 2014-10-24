using System;
using System.Windows.Forms;
using Calendar_System.AccountSubSystem;
using Calendar_System.StorageSubSystem;

namespace Calendar_System.MainSystem
{
    public class AdminForm : Form
    {
        private AdminControl _adminControl ;
        private Button _createAccountButton;
        private Button _createNewWorkgroupButton;
        private Button _modifyWorkgroupButton;
        private Button _modifyAccountButton;

        public AdminForm(AdminControl adminControl)
        {
            _adminControl = adminControl;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this._createAccountButton = new System.Windows.Forms.Button();
            this._modifyAccountButton = new System.Windows.Forms.Button();
            this._createNewWorkgroupButton = new System.Windows.Forms.Button();
            this._modifyWorkgroupButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _createAccountButton
            // 
            this._createAccountButton.Location = new System.Drawing.Point(12, 164);
            this._createAccountButton.Name = "_createAccountButton";
            this._createAccountButton.Size = new System.Drawing.Size(158, 31);
            this._createAccountButton.TabIndex = 0;
            this._createAccountButton.Text = "Create new account";
            this._createAccountButton.UseVisualStyleBackColor = true;
            this._createAccountButton.Click += new System.EventHandler(this._createAccountButton_Click);
            // 
            // _modifyAccountButton
            // 
            this._modifyAccountButton.Location = new System.Drawing.Point(12, 128);
            this._modifyAccountButton.Name = "_modifyAccountButton";
            this._modifyAccountButton.Size = new System.Drawing.Size(158, 31);
            this._modifyAccountButton.TabIndex = 1;
            this._modifyAccountButton.Text = "Modify account";
            this._modifyAccountButton.UseVisualStyleBackColor = true;
            this._modifyAccountButton.Click += new System.EventHandler(this._modifyAccountButton_Click);
            // 
            // _createNewWorkgroupButton
            // 
            this._createNewWorkgroupButton.Location = new System.Drawing.Point(176, 164);
            this._createNewWorkgroupButton.Name = "_createNewWorkgroupButton";
            this._createNewWorkgroupButton.Size = new System.Drawing.Size(173, 31);
            this._createNewWorkgroupButton.TabIndex = 2;
            this._createNewWorkgroupButton.Text = "Create new workgroup";
            this._createNewWorkgroupButton.UseVisualStyleBackColor = true;
            this._createNewWorkgroupButton.Click += new System.EventHandler(this._createNewWorkgroupButton_Click);
            // 
            // _modifyWorkgroupButton
            // 
            this._modifyWorkgroupButton.Location = new System.Drawing.Point(176, 128);
            this._modifyWorkgroupButton.Name = "_modifyWorkgroupButton";
            this._modifyWorkgroupButton.Size = new System.Drawing.Size(173, 31);
            this._modifyWorkgroupButton.TabIndex = 3;
            this._modifyWorkgroupButton.Text = "Modify workgroup";
            this._modifyWorkgroupButton.UseVisualStyleBackColor = true;
            this._modifyWorkgroupButton.Click += new System.EventHandler(this._modifyWorkgroupButton_Click);
            // 
            // AdminForm
            // 
            this.ClientSize = new System.Drawing.Size(361, 207);
            this.Controls.Add(this._modifyWorkgroupButton);
            this.Controls.Add(this._createNewWorkgroupButton);
            this.Controls.Add(this._modifyAccountButton);
            this.Controls.Add(this._createAccountButton);
            this.Name = "AdminForm";
            this.ResumeLayout(false);

        }

        private void _createAccountButton_Click(object sender, EventArgs e)
        {
            _adminControl.CreateAccountControl("newAccount");
        }

        private void _modifyAccountButton_Click(object sender, EventArgs e)
        {
            _adminControl.CreateAccountControl("modifyAccount");
        }

        private void _modifyWorkgroupButton_Click(object sender, EventArgs e)
        {
            _adminControl.CreateWorkgroupControl("modifyWorkgroup");
        }

        private void _createNewWorkgroupButton_Click(object sender, EventArgs e)
        {
            _adminControl.CreateWorkgroupControl("newWorkgroup");
        }
    }
}
