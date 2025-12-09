# To-Do List (ASP.NET Core)

A simple To-Do web app built with ASP.NET Core (Controllers + Razor Views) build source code with Clean architecture.  
Project uses .NET 8 and an in-memory repository for demo / learning purposes.

## Features
- List tasks (home page)
- Add new task
- Update task (text + completed flag)
- Mark task complete (quick checkbox)
- Delete task
- In-memory storage (no external DB) — good for local development and demos

## Project structure (important files)
- ToDoList/Program.cs — app bootstrap (uses .NET minimal host)
- ToDoList/Controllers/HomeController.cs — main controller and routes
- ToDoList/Views/Home/*.cshtml — UI (Index, Add, Update)
- Entities/TodoItem.cs — domain model
- UseCases/TodoListManager.cs — application logic (uses repository)
- Infratructure/InMemoryToDoItemRepository.cs — in-memory repository implementation
- ToDoList/Models/Item.cs, TodoListViewModel.cs — view models

## Requirements
- .NET 8 SDK
- (optional) Visual Studio 2022/2023 or VS Code

## Run locally (CLI)
1. Clone the repo:
   git clone https://github.com/LiemDT2005/To-Do-List.git
2. Change to the web project folder and run:
   cd "To-Do-List/ToDoList"
   dotnet run
3. Open browser at the URL shown (by default https://localhost:5001 or https://localhost:7043 depending on launch settings).

## Run in Visual Studio
1. Open the solution or the `ToDoList` project.
2. Build: __Build > Build Solution__
3. Start: __Debug > Start Debugging__ (or __Debug > Start Without Debugging__)

## Routes / Endpoints
- GET / or /Home/Index — list tasks
- GET /Home/Add — form to add
- POST /Home/Add — create new task
- GET /Home/Update/{id} — edit form
- POST /Home/Update — update task
- GET /Home/Delete/{id} — delete (controller redirects after)
- POST /Home/Complete — mark task completed (form + checkbox)

## Data persistence
This project uses an in-memory repository (Infratructure/InMemoryToDoItemRepository). Data will be lost when the app restarts. Replace ITodoItemRepository registration in Program.cs to hook a real database.

## Notes / Gotchas
- In-memory implementation assigns incremental Ids; beware of concurrency for production.
- Views post simple form fields; model binding uses the view model `TodoList.Models.Item`.
- No authentication or validation beyond HTML `required` attributes — add server-side validation for production.

## Contributing
- Open an issue or submit a PR.
- For feature work, prefer small, focused changes and update README with any new setup steps.

## License
Add a LICENSE file as needed (e.g., MIT).
