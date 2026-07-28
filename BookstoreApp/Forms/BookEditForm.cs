using BookstoreApp.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreApp.Forms
{
    public class BookEditForm : Form
    {
        private TextBox txtTitle;
        private TextBox txtISBN;
        private NumericUpDown nudPrice;
        private TextBox txtDescription;
        private ComboBox cmbGenre;
        private Button btnSave;
        private Button btnCancel;

        private Book? editing;

        public BookEditForm(Book? book = null)
        {
            editing = book;
            InitializeComponent();

            // Populate fields if editing
            if (editing != null)
            {
                txtTitle.Text = editing.Title;
                nudPrice.Value = editing.Price;
                txtDescription.Text = editing.description;
                Text = "Edit Book";
            }
            else
            {
                Text = "Add Book";
            }

            _ = LoadGenresAsync();
        }

        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            nudPrice = new NumericUpDown();
            txtDescription = new TextBox();
            cmbGenre = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();

            txtTitle.Location = new System.Drawing.Point(12, 12);
            txtTitle.Size = new System.Drawing.Size(360, 23);
            txtTitle.PlaceholderText = "Title";

            txtISBN = new TextBox();
            txtISBN.Location = new System.Drawing.Point(12, 44);
            txtISBN.Size = new System.Drawing.Size(200, 23);
            txtISBN.PlaceholderText = "ISBN (13 digits)";
            txtISBN.MaxLength = 13;

            nudPrice.Location = new System.Drawing.Point(12, 76);
            nudPrice.Size = new System.Drawing.Size(120, 23);
            nudPrice.DecimalPlaces = 2;
            nudPrice.Maximum = 100000;

            txtDescription.Location = new System.Drawing.Point(12, 108);
            txtDescription.Size = new System.Drawing.Size(360, 80);
            txtDescription.Multiline = true;
            txtDescription.PlaceholderText = "Description";

            cmbGenre.Location = new System.Drawing.Point(12, 196);
            cmbGenre.Size = new System.Drawing.Size(360, 23);
            cmbGenre.DropDownStyle = ComboBoxStyle.DropDownList;

            btnSave.Text = "Save";
            btnSave.Location = new System.Drawing.Point(12, 236);
            btnSave.Click += btnSave_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Location = new System.Drawing.Point(100, 236);
            btnCancel.Click += (s, e) => DialogResult = DialogResult.Cancel;

            ClientSize = new System.Drawing.Size(400, 300);
            Controls.Add(txtTitle);
            Controls.Add(txtISBN);
            Controls.Add(nudPrice);
            Controls.Add(txtDescription);
            Controls.Add(cmbGenre);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private async Task LoadGenresAsync()
        {
            var genres = await Database.BookDb.GetGenresAsync();
            cmbGenre.DataSource = genres;
            cmbGenre.DisplayMember = "Name";

            if (editing != null && editing.Genres != null && editing.Genres.Any())
            {
                var first = editing.Genres.First();
                var match = genres.FirstOrDefault(g => g.GenreId == first.GenreId);
                if (match != null) cmbGenre.SelectedItem = match;
            }
        }

        private async void btnSave_Click(object? sender, EventArgs e)
        {
            string title = txtTitle.Text?.Trim() ?? string.Empty;
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show(this, "Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string isbnRaw = txtISBN.Text?.Trim() ?? string.Empty;
            // Enforce digits only, 13 characters
            if (!Regex.IsMatch(isbnRaw, "^\\d{13}$"))
            {
                MessageBox.Show(this, "ISBN is required and must be exactly 13 digits (numbers only).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price = nudPrice.Value;
            string? desc = txtDescription.Text?.Trim();

            if (editing == null)
            {
                var book = new Book { Title = title, Price = price, description = desc, ISBN = isbnRaw };
                if (cmbGenre.SelectedItem is Genre sel)
                {
                    book.Genres = new List<Genre> { sel };
                    book.PrimaryGenreId = sel.GenreId;
                }
                await Database.BookDb.AddAsync(book);
            }
            else
            {
                editing.Title = title;
                editing.Price = price;
                editing.description = desc;
                editing.ISBN = isbnRaw;
                if (cmbGenre.SelectedItem is Genre sel)
                {
                    editing.Genres = new List<Genre> { sel };
                    editing.PrimaryGenreId = sel.GenreId;
                }
                else
                {
                    editing.Genres = new List<Genre>();
                    editing.PrimaryGenreId = null;
                }

                await Database.BookDb.UpdateAsync(editing);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
