using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            await LoadBooksAsync();
        }

        private async Task LoadBooksAsync()
        {
            var books = await Database.BookDb.GetBooksAsync();
            lstBooks.DataSource = books;
            lstBooks.DisplayMember = "Title";
        }

        private async void btnAddUpdate_Click(object? sender, EventArgs e)
        {
            Book? selected = lstBooks.SelectedItem as Book;

            using var form = new BookEditForm(selected);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                await LoadBooksAsync();
                MessageBox.Show(this, "Book saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnNew_Click(object? sender, EventArgs e)
        {
            using var form = new BookEditForm(null);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                await LoadBooksAsync();
                MessageBox.Show(this, "Book added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnDelete_Click(object? sender, EventArgs e)
        {
            Book? selected = lstBooks.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show(this, "Please select a book to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(this, $"Delete '{selected.Title}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            await Database.BookDb.DeleteAsync(selected.BookId);
            await LoadBooksAsync();
            MessageBox.Show(this, $"'{selected.Title}' deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
