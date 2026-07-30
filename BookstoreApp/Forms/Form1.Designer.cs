namespace BookstoreApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private System.Windows.Forms.ListBox lstBooks;
        private System.Windows.Forms.Button btnAddUpdate;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;

        private void InitializeComponent()
        {
            lstBooks = new ListBox();
            btnAddUpdate = new Button();
            btnNew = new Button();
            btnDelete = new Button();
            btnManageAuthors = new Button();
            SuspendLayout();
            // 
            // lstBooks
            // 
            lstBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstBooks.Location = new Point(12, 12);
            lstBooks.Name = "lstBooks";
            lstBooks.Size = new Size(560, 404);
            lstBooks.TabIndex = 0;
            // 
            // btnAddUpdate
            // 
            btnAddUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUpdate.Location = new Point(590, 62);
            btnAddUpdate.Name = "btnAddUpdate";
            btnAddUpdate.Size = new Size(180, 40);
            btnAddUpdate.TabIndex = 2;
            btnAddUpdate.Text = "Add / Update";
            btnAddUpdate.Click += btnAddUpdate_Click;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNew.Location = new Point(590, 12);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(180, 40);
            btnNew.TabIndex = 1;
            btnNew.Text = "New";
            btnNew.Click += btnNew_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.BackColor = Color.Red;
            btnDelete.Location = new Point(590, 112);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(180, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnManageAuthors
            // 
            btnManageAuthors.BackColor = Color.Yellow;
            btnManageAuthors.Location = new Point(590, 167);
            btnManageAuthors.Name = "btnManageAuthors";
            btnManageAuthors.Size = new Size(180, 39);
            btnManageAuthors.TabIndex = 4;
            btnManageAuthors.Text = "Manage Authors";
            btnManageAuthors.UseVisualStyleBackColor = false;
            btnManageAuthors.Click += btnManageAuthors_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnManageAuthors);
            Controls.Add(lstBooks);
            Controls.Add(btnNew);
            Controls.Add(btnAddUpdate);
            Controls.Add(btnDelete);
            Name = "Form1";
            Text = "Bookstore";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageAuthors;
    }
}
