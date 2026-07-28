using BookstoreApp.Models;
using System;
using System.Windows.Forms;

namespace BookstoreApp.Forms
{
    public class BookEditForm : Form
    {
        private TextBox txtTitle;
        private NumericUpDown nudPrice;
        private Button btnSave;
        private Button btnCancel;

        private Book? editing;

        public BookEditForm(Book? book = null)
        {
            editing = book;
            InitializeComponent();

            if (editing != null)
            {
                txtTitle.Text = editing.Title;
                nudPrice.Value = editing.Price;
                Text = "Edit Book";
            }
            else
            {
                Text = "Add Book";
            }
        }

        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            nudPrice = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();

            txtTitle.Location = new System.Drawing.Point(12, 12);
            txtTitle.Size = new System.Drawing.Size(360, 23);
            txtTitle.PlaceholderText = "Title";

            nudPrice.Location = new System.Drawing.Point(12, 44);
            nudPrice.Size = new System.Drawing.Size(120, 23);
            nudPrice.DecimalPlaces = 2;
            nudPrice.Maximum = 100000;

            btnSave.Text = "Save";
            btnSave.Location = new System.Drawing.Point(12, 80);
            btnSave.Click += btnSave_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(100, 80);
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

            ClientSize = new System.Drawing.Size(400, 120);
            Controls.Add(txtTitle);
            Controls.Add(nudPrice);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private async void btnSave_Click(object? sender, EventArgs e)
        {
            string title = txtTitle.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show(this, "Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price = nudPrice.Value;

            if (editing == null)
            {
                var book = new Book { Title = title, Price = price };
                await Database.BookDb.AddAsync(book);
            }
            else
            {
                editing.Title = title;
                editing.Price = price;
                await Database.BookDb.UpdateAsync(editing);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
