
# 🎓 Student Management System (ASP.NET Core MVC • CRUD • SPA • Master-Details)

An intuitive web-based Student Management System built with ASP.NET Core MVC.  
The app supports complete CRUD operations in a Single-Page Application (SPA) experience using Razor Views and follows the Master-Details pattern for managing related student data seamlessly.

🔗 GitHub Profile: [HabibaSCreations](https://github.com/HabibaSCreations)

---

## ✨ Key Features

- 🎯 Full CRUD functionality for managing **Students**
- 🔍 Master-Detail interface to handle related data like **Courses**, **Addresses**, and **Guardian Info**
- ⚡ SPA-style interactivity using partial views and AJAX
- 🖼️ Clean and responsive design with Bootstrap & jQuery
- 💾 Data persistence using Entity Framework Core and SQL Server
- ⚙️ Auto-generated scaffolding for quick development

---

## 🛠️ Tech Stack

| Layer        | Technology                             |
|--------------|-----------------------------------------|
| Framework    | ASP.NET Core MVC                        |
| ORM          | Entity Framework Core 8.0.5             |
| Database     | SQL Server                              |
| UI           | Razor View Engine + Bootstrap + jQuery |
| Tools        | Code Generator (v8.0.7), LibMan         |

---

## 🗂️ Project Folder Overview

```
StudentManagement/
├── wwwroot/
│   ├── css/
│   ├── bootstrap/
│   └── jquery/
├── Controllers/
│   ├── HomeController.cs
│   └── StudentsController.cs
├── Models/
│   ├── Student.cs
│   ├── Address.cs
│   └── Course.cs
├── ViewModels/
│   └── StudentViewModel.cs
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Students/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _StudentCourses.cshtml
├── Migrations/
│   ├── [timestamp]_init.cs
│   └── AppDbContextModelSnapshot.cs
├── appsettings.json
├── Program.cs
└── libman.json
```

🖼️ `wwwroot/images/noimage.jpg` → Used as fallback for students without a photo.

---

## 🚀 Getting Started

1. **Clone the Repo**
   ```bash
   git clone https://github.com/HabibaSCreations/StudentManagement.git
   ```

2. **Open the Solution in Visual Studio** or run:
   ```bash
   cd StudentManagement
   dotnet restore
   ```

3. **Apply Migrations**
   ```bash
   dotnet ef database update
   ```

4. **Run the App**
   ```bash
   dotnet run
   ```

5. **Browse the App**
   Visit: `https://localhost:5001`

---

## 📝 Notes

- Update your `appsettings.json` with a valid SQL Server connection string.
- Ensure `Entity Framework Core CLI` is installed for running migrations.

---

## 📃 License

This project is open-source under the [MIT License](LICENSE).

---

© 2025 • Developed by [HabibaSCreations](https://github.com/HabibaSCreations)
