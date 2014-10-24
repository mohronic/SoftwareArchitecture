using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar_System.AccountSubSystem
{
    class AllUsersForm : Form
    {
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn _firstName;
        private DataGridViewTextBoxColumn _lastName;

        private ListBox listBox1;
        public AllUsersForm(IList<User> users)
        {
            InitializeComponent(users);
        }
        private void InitializeComponent(IList<User> users)
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._firstName,
            this._lastName});
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(286, 163);
            this.dataGridView1.TabIndex = 0;
            dataGridView1.DataSource = users;
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
            // AllUsersForm
            // 
            this.ClientSize = new System.Drawing.Size(311, 282);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AllUsersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
