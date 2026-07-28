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
            components = new System.ComponentModel.Container();
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Text = "Bookstore";

            lstBooks = new System.Windows.Forms.ListBox();
            btnAddUpdate = new System.Windows.Forms.Button();
            btnNew = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();

            // lstBooks
            lstBooks.Location = new Point(12, 12);
            lstBooks.Size = new Size(560, 420);
            lstBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // btnNew
            btnNew.Text = "New";
            btnNew.Location = new Point(590, 12);
            btnNew.Size = new Size(180, 40);
            btnNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNew.Click += btnNew_Click;

            // btnAddUpdate
            btnAddUpdate.Text = "Add / Update";
            btnAddUpdate.Location = new Point(590, 62);
            btnAddUpdate.Size = new Size(180, 40);
            btnAddUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUpdate.Click += btnAddUpdate_Click;

            // btnDelete
            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(590, 112);
            btnDelete.Size = new Size(180, 40);
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Click += btnDelete_Click;

            Controls.Add(lstBooks);
            Controls.Add(btnNew);
            Controls.Add(btnAddUpdate);
            Controls.Add(btnDelete);

            Load += Form1_Load;
        }

        #endregion
    }
}
