using BookstoreApp.Database;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using var db = new BookStoreDb();
        db.Database.Migrate();

        Application.Run(new Form1());
    }
}
