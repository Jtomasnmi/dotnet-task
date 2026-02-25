# My steps for the development of assessment
1. the solution is missing so I create a new sln
2. missing packages so I install swashbuckle, brcypt
3. adjust the structure of models for TASKS/USER
4. I create interfaces then implement those to Data/ taskrepository and userRepository
5. create repository which contain all of my implementation of method
6. on controller i call all the return value from my repository/services
7. add funtionality for user (CRUD)
8. configure cors for api integration to front end from program.cs
9. register services I created or dependency injection into program.cs so that i can use services vice versa.
10. lastly i configured the postgresql it depends on credentials please change if neccessary.
# .NET Task Evaluator API – Technical Exam

⏰ **Estimated Time**: 2–3 hours  
🔧 **Tech Stack**:
- .NET 9 Web API  
- PostgreSQL  
- Entity Framework Core (EF Core)  
- Swagger for API documentation  

---

## 🧪 Technical Exam Instructions

### 1. Clone the repository

```bash
git clone https://github.com/phia-digiteer/dotnet-task-evaluator.git
cd dotnet-task-evaluator
```

---

2. Set up the environment
Make sure you have the .NET 9 SDK and PostgreSQL installed. Configure your local database connection string as needed.
3. Apply database migrations
Run the following command to create the database schema:

```bash
dotnet ef database update
```

### 🎯 Objectives

- Interact with a .NET 9 Web API in a realistic development environment  
- Notice gaps or inconsistencies within basic operations  
- Consider improvements around structure, access control, and maintainability  
- Apply practical architectural concepts to guide decisions  
- Enhance functionality where needed or where something feels off  
- Work with EF Core to interact with data cleanly  
- Optionally introduce supporting tests or clarifying documentation

### 📦 Commit Guidelines

Please commit frequently as you work. Avoid one big fat commit at the end.
Each commit should:

- Have a clear, descriptive message (e.g., Add TaskService)-Explain your reasoning if you're making assumptions or design choices
- Show incremental progress (yes, even small ones!)
- Your commit history helps us understand your thinking — don’t hide the struggle 💪
