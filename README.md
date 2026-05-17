# 📝 Notes Management System

A web application built with **ASP.NET Core 9 MVC** for the Advanced Computer Programming course (SENG494).

---

## 📌 Project Overview

A browser-based notes app where users can create, read, update, and delete personal notes. Built to demonstrate the **Model-View-Controller (MVC)** architectural pattern using ASP.NET Core.

Each note has a title, content, category, and timestamps for creation and last modification. Notes are stored in-memory during the session.

---

## ✨ Features

- ✅ Full CRUD — Create, Read, Update, Delete
- 🔍 Search notes by title or content
- 🏷️ Filter by category (General, Personal, Work, Study, Ideas)
- ⚠️ Server-side validation with inline error messages
- 🔔 Success feedback after every operation (TempData)
- 🛡️ Anti-forgery token protection on all POST forms

---

## 🗂️ Project Structure

```
NotesApp/
├── Models/
│   ├── Note.cs                  # Data model (Id, Title, Content, Category, timestamps)
│   └── NoteRepository.cs        # In-memory data access layer
├── Controllers/
│   └── NotesController.cs       # 8 action methods covering all CRUD operations
└── Views/Notes/
    ├── Index.cshtml              # Home — all notes with search & filter
    ├── Details.cshtml            # View a single note
    ├── Create.cshtml             # Add a new note
    ├── Edit.cshtml               # Edit an existing note
    └── Delete.cshtml             # Confirm deletion
```

---

## 🚀 How to Run

**Requirements:** [.NET 9 SDK](https://dotnet.microsoft.com/download)

```bash
# 1. Clone the repo
git clone https://github.com/your-username/NotesApp.git
cd NotesApp

# 2. Run the app
dotnet run -p:StaticWebAssetsEnabled=false

# 3. Open in browser
http://localhost:5119
```

> **Note:** If you get a timestamp error after cloning, run:
> ```bash
> find . -type f | xargs touch
> ```

---

## 🛠️ Tech Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core 9 MVC | Web framework |
| C# | Controllers & Models |
| Razor (.cshtml) | View templating |
| HTML & CSS | UI — custom dark theme |
| In-Memory List | Data storage (no database) |

---

## Course

SENG494 — Advanced Computer Programming / uoh
