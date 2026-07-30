using BookstoreApp.Models;
using System;
using System.Windows.Forms;

namespace BookstoreApp.Forms;

public class AuthorEditForm : Form
{
    private TextBox txtName = null!;
    private Button btnSave = null!;
    private Button btnCancel = null!;

    private Author? editing;

    public AuthorEditForm(Author? author = null)
    {
        editing = author;
        InitializeComponent();

        if (editing != null)
        {
            txtName.Text = editing.Name;
            Text = "Edit Author";
        }
        else
        {
            Text = "Add Author";
        }
    }

    private void InitializeComponent()
    {
        txtName = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();

        txtName.Location = new System.Drawing.Point(12, 12);
        txtName.Size = new System.Drawing.Size(320, 23);
        txtName.PlaceholderText = "Author name";

        btnSave.Text = "Save";
        btnSave.Location = new System.Drawing.Point(12, 50);
        btnSave.Click += btnSave_Click;

        btnCancel.Text = "Cancel";
        btnCancel.Location = new System.Drawing.Point(100, 50);
        btnCancel.DialogResult = DialogResult.Cancel;

        ClientSize = new System.Drawing.Size(350, 95);
        Controls.Add(txtName);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        AcceptButton = btnSave;
        CancelButton = btnCancel;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
    }

    private async void btnSave_Click(object? sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(this, "Author name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (editing == null)
        {
            await Database.BookDb.AddAuthorAsync(new Author { Name = name });
        }
        else
        {
            editing.Name = name;
            await Database.BookDb.UpdateAuthorAsync(editing);
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}