using System;
using System.Windows.Forms;
using Calendar_System.AccountSubSystem;
using Calendar_System.StorageSubSystem;

namespace Calendar_System.MainSystem
{
    public class AdminForm : Form
    {
        private IStorage _abstractStorage;
        private AdminControl _adminControl ;
        private Button _createAccountButton;
        private Button _modifyAccountButton;

        public AdminForm(AdminControl adminControl, IStorage abstractStorage)
        {
            _abstractStorage = abstractStorage;
            _adminControl = adminControl;
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this._createAccountButton = new System.Windows.Forms.Button();
            this._modifyAccountButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _createAccountButton
            // 
            this._createAccountButton.Location = new System.Drawing.Point(12, 161);
            this._createAccountButton.Name = "_createAccountButton";
            this._createAccountButton.Size = new System.Drawing.Size(158, 31);
            this._createAccountButton.TabIndex = 0;
            this._createAccountButton.Text = "Create new account";
            this._createAccountButton.UseVisualStyleBackColor = true;
            this._createAccountButton.Click += new System.EventHandler(this._createAccountButton_Click);
            // 
            // _modifyAccountButton
            // 
            this._modifyAccountButton.Location = new System.Drawing.Point(183, 161);
            this._modifyAccountButton.Name = "_modifyAccountButton";
            this._modifyAccountButton.Size = new System.Drawing.Size(166, 31);
            this._modifyAccountButton.TabIndex = 1;
            this._modifyAccountButton.Text = "Modify account";
            this._modifyAccountButton.UseVisualStyleBackColor = true;
            this._modifyAccountButton.Click += new System.EventHandler(this._modifyAccountButton_Click);
            // 
            // AdminClient
            // 
            this.ClientSize = new System.Drawing.Size(361, 207);
            this.Controls.Add(this._modifyAccountButton);
            this.Controls.Add(this._createAccountButton);
            this.Name = "AdminClient";
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
    }
}
