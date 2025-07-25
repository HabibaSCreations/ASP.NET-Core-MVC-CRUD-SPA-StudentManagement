
# ASP.NET Core MVC CRUD SPA (Master-Details)

A simple ASP.NET Core MVC application with CRUD functionality implemented in Single-Page Application (SPA) style, following the Master-Details pattern.  
This project demonstrates how to manage related data (Student with associated information) using Entity Framework Core and SQL Server.

🔗 GitHub: [HabibaSCreations](https://github.com/HabibaSCreations)

---

## 📚 Table of Contents

- Features  
- Tech Stack  
- Project Structure  
- Setup Instructions  
- Special Notes  
- License  

---

## 🧩 Features

- CRUD Operations: Create, Read, Update, Delete **Students**
- Master-Details: Manage associated data like addresses, courses, or academic records
- SPA behavior using Razor Views for smooth UI experience
- Responsive UI with Bootstrap, jQuery, and custom CSS
- SQL Server integration using Entity Framework Core
- Scaffolded Controllers & Views with ASP.NET Core conventions

---

## 🏗️ Tech Stack

| Component       | Technology                                     |
|-----------------|------------------------------------------------|
| Framework       | ASP.NET Core MVC                               |
| Database        | SQL Server                                     |
| ORM             | Entity Framework Core 8.0.5                     |
| View Engine     | Razor                                          |
| Client-side     | Bootstrap, jQuery, CSS                         |
| Code Generation | Microsoft.VisualStudio.Web.CodeGeneration.Design 8.0.7 |

---

## 📁 Project Structure

The solution is organized with a clean separation of concerns:

```
StudentManagement/
├── wwwroot/
│   ├── bootstrap/
│   ├── images/
│   └── jquery/
├── Controllers/
│   ├── HomeController.cs
│   └── StudentsController.cs
├── Migrations/
│   ├── 2025XXXXXX_init.cs
│   └── AppDbContextModelSnapshot.cs
├── Models/
│   ├── Student.cs
│   ├── Address.cs
│   └── Course.cs
├── ViewModels/
│   └── StudentViewModel.cs
├── Views/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── _AddCourse.cshtml
│   ├── Home/
│   │   └── Index.cshtml
│   └── Students/
│       ├── Index.cshtml
│       ├── CreateStudent.cshtml
│       ├── _EditStudent.cshtml
│       └── StudentList.rpt
├── images/
│   └── noimage.jpg  # Placeholder for students without a photo
├── appsettings.json
├── appsettings.Development.json
├── libman.json
└── Program.cs
```

---

## ⚙️ Setup Instructions

1. Clone the repo:  
   `git clone https://github.com/HabibaSCreations/StudentManagement.git`

2. Navigate to the project folder:  
   `cd StudentManagement`

3. Restore dependencies:  
   `dotnet restore`

4. Apply EF migrations:  
   `dotnet ef database update`

5. Run the application:  
   `dotnet run`

6. Visit: `https://localhost:5001` in your browser

---

## 📝 Special Notes

- Update `appsettings.json` with your SQL Server connection string
- Make sure EF Core CLI is installed for migrations and updates

---

## 📄 License

Licensed under the MIT License.

---

© 2025 • Developed by [HabibaSCreations](https://github.com/HabibaSCreations)
