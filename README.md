# 📚 BookstoreApp

A Windows desktop bookstore management app built with **C#**, **WinForms**, and **.NET**.

![Platform](https://img.shields.io/badge/platform-Windows-blue)
![Language](https://img.shields.io/badge/language-C%23-purple)
![UI](https://img.shields.io/badge/UI-WinForms-green)
![Framework](https://img.shields.io/badge/.NET-Windows-informational)

---

## ✨ Highlights

- Desktop UI built with Windows Forms
- .NET-based application architecture
- Entity Framework Core-style project setup with migrations
- Foundation for managing bookstore inventory and related data

---

## 🧱 Tech Stack

- **C#**
- **.NET (Windows target)**
- **Windows Forms**
- **Entity Framework Core** (project includes `Database/` and `Migrations/` folders)

---

## 📂 Repository Structure

```text
BookstoreApp/
├── BookstoreApp.slnx
├── README.md
└── BookstoreApp/
    ├── BookstoreApp.csproj
    ├── Program.cs
    ├── Form1.cs
    ├── Form1.Designer.cs
    ├── Form1.resx
    ├── Book.cs
    ├── Database/
    └── Migrations/
```

---

## 🚀 Getting Started

### Prerequisites

- **Windows OS** (WinForms requirement)
- **.NET SDK** compatible with the project target framework
- Optional: EF tooling
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Run Locally

```bash
git clone https://github.com/zkimball85/BookstoreApp.git
cd BookstoreApp
dotnet restore
dotnet build
dotnet run --project BookstoreApp/BookstoreApp.csproj
```

---

## 🗄️ Database & Migrations

Apply migrations:

```bash
dotnet ef database update --project BookstoreApp/BookstoreApp.csproj
```

Create a new migration:

```bash
dotnet ef migrations add <MigrationName> --project BookstoreApp/BookstoreApp.csproj
```

---

## 🖥️ App Entry Point

The app starts in:

- `BookstoreApp/Program.cs`
- Launches main form: `Form1`

---

## 🛣️ Roadmap

- [ ] Add full CRUD for books
- [ ] Add validation and user-friendly error messages
- [ ] Improve form layout and UX
- [ ] Add search/filter functionality
- [ ] Add unit/integration tests
- [ ] Add CI workflow

---

## 🤝 Contributing

Contributions are welcome.

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push and open a Pull Request

---

## 📄 License

This project is currently unlicensed.  
Consider adding an MIT License if you want open-source reuse.

---

## 🙌 Acknowledgments

Built as a bookstore desktop app project using the .NET ecosystem.
