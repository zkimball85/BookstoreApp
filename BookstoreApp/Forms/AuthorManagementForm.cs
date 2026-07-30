using BookstoreApp.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreApp.Forms;

public class AuthorManagementForm : Form
{
    private ListBox lstAuthors = null!;
    private Button btnAddUpdate = null!;
    private Button btnDelete = null!;
    private Button btnClose = null!;

    public AuthorManagementForm()
    {
        InitializeComponent();
        Load += AuthorManagementForm_Load;
    }

    private void InitializeComponent()
    {
        lstAuthors = new ListBox();
        btnAddUpdate = new Button();
        btnDelete = new Button();
        btnClose = new Button();

        lstAuthors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstAuthors.Location = new System.Drawing.Point(12, 12);
        lstAuthors.Size = new System.Drawing.Size(360, 300);

        btnAddUpdate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAddUpdate.Location = new System.Drawing.Point(390, 12);
        btnAddUpdate.Size = new System.Drawing.Size(150, 40);
        btnAddUpdate.Text = "Add / Update";
        btnAddUpdate.Click += btnAddUpdate_Click;

        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDelete.Location = new System.Drawing.Point(390, 62);
        btnDelete.Size = new System.Drawing.Size(150, 40);
        btnDelete.Text = "Delete Selected";
        btnDelete.BackColor = System.Drawing.Color.LightCoral;
        btnDelete.UseVisualStyleBackColor = false;
        btnDelete.Click += btnDelete_Click;

        btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnClose.Location = new System.Drawing.Point(390, 112);
        btnClose.Size = new System.Drawing.Size(150, 40);
        btnClose.Text = "Close";
        btnClose.DialogResult = DialogResult.Cancel;

        ClientSize = new System.Drawing.Size(560, 330);
        Controls.Add(lstAuthors);
        Controls.Add(btnAddUpdate);
        Controls.Add(btnDelete);
        Controls.Add(btnClose);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Manage Authors";
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        CancelButton = btnClose;
    }

    private async void AuthorManagementForm_Load(object? sender, EventArgs e)
    {
        await LoadAuthorsAsync();
    }

    private async Task LoadAuthorsAsync()
    {
        var authors = await Database.BookDb.GetAuthorsAsync();
        lstAuthors.DataSource = authors;
        lstAuthors.DisplayMember = "Name";
    }

    private async void btnAddUpdate_Click(object? sender, EventArgs e)
    {
        Author? selected = lstAuthors.SelectedItem as Author;

        using var form = new AuthorEditForm(selected);
        var result = form.ShowDialog(this);
        if (result == DialogResult.OK)
        {
            await LoadAuthorsAsync();
        }
    }

    private async void btnDelete_Click(object? sender, EventArgs e)
    {
        Author? selected = lstAuthors.SelectedItem as Author;
        if (selected == null)
        {
            MessageBox.Show(this, "Please select an author to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirm = MessageBox.Show(this, $"Delete '{selected.Name}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (confirm != DialogResult.Yes)
        {
            return;
        }

        await Database.BookDb.DeleteAuthorAsync(selected.Id);
        await LoadAuthorsAsync();
    }
}