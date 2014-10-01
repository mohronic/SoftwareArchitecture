using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calendar_System.model;

namespace Calendar_System.view
{
    class WorkgroupForm : Form
    {
        private List<User> _userList; 
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn _firstName;
        private DataGridViewTextBoxColumn _lastName;
        private DataGridViewTextBoxColumn _email;
        private DataGridViewTextBoxColumn _phone;
        private BindingSource workgroupFormBindingSource;
        private System.ComponentModel.IContainer components;
        private Label _workgroupNameLabel;
    
        public WorkgroupForm()
        {
            
        }

        public WorkgroupForm(Workgroup workgroup)
        {
            
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._workgroupNameLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workgroupFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workgroupFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _workgroupNameLabel
            // 
            this._workgroupNameLabel.AutoSize = true;
            this._workgroupNameLabel.Location = new System.Drawing.Point(13, 13);
            this._workgroupNameLabel.Name = "_workgroupNameLabel";
            this._workgroupNameLabel.Size = new System.Drawing.Size(121, 17);
            this._workgroupNameLabel.TabIndex = 0;
            this._workgroupNameLabel.Text = "Workgroup name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(340, 22);
            this.textBox1.TabIndex = 1;
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
            // workgroupFormBindingSource
            // 
            this.workgroupFormBindingSource.DataSource = typeof(Calendar_System.view.WorkgroupForm);
            // 
            // WorkgroupForm
            // 
            this.ClientSize = new System.Drawing.Size(493, 424);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this._workgroupNameLabel);
            this.Name = "WorkgroupForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workgroupFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
