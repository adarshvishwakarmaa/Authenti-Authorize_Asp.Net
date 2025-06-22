# 🔐 ASP.NET Core MVC – Login & Registration System

This is a simple but complete **Authentication and Authorization system** built with **ASP.NET Core MVC**. It includes:

- User **Registration**
- Secure **Login** with Cookie Authentication
- **Authorization** using Roles
- Integration with **Entity Framework Core**
- Secure **Password Storage** (optional: Hashing can be added)

---

## 🚀 Features

- User registration with first name, last name, email, and username
- User login using either **username or email**
- Cookie-based authentication
- Role-based access to protected pages
- Logout functionality
- Friendly UI for login and registration
- Login status displayed with greeting

---

## 🛠️ Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (LocalDB or SQL Express)
- Razor Views
- Cookie Authentication
- Visual Studio or Visual Studio Code

---


## 📂 Project Structure

Authentication
│
├── Controllers
│ └── AccountController.cs
│
├── Models
│ ├── UserAccount.cs
│ ├── LoginViewModel.cs
│ └── RegistrationViewModel.cs
│
├── Views
│ └── Account
│ ├── Login.cshtml
│ ├── Registration.cshtml
│ └── SecurePage.cshtml
│
├── Data
│ └── AuthenticationDbContext.cs
│
├── appsettings.json
└── Program.cs / Startup.cs


---

## 📦 How to Run the Project

1. **Clone this repository**
   ```bash
   git clone https://github.com/your-username/AuthSystem-AspNetCore.git
   cd AuthSystem-AspNetCore

2. Set up the database connection
Update appsettings.json with your SQL Server connection string:
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=AuthDemoDb;Trusted_Connection=True;"
}

3.Apply Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

4.Open in browser: https://localhost:5001

🔐 Authentication Setup
➕ Register
Go to /Account/Registration

Fill in required fields

After registration, a success message will appear

🔑 Login
Go to /Account/Login

Login with username or email

On success, you’re redirected to the secure page

🔓 Logout
When logged in, the navbar shows a Hello [name] and a Log off button.

🛡️ Authorization
The method [Authorize] on the SecurePage() action ensures only logged-in users can access it.

Roles can be extended by adding ClaimTypes.Role and checking in Razor or Controllers.

✍️ Custom Claim Example
var claims = new List<Claim>
{
    new Claim(ClaimTypes.Name, user.Email),
    new Claim("Name", user.FirstName),
    new Claim(ClaimTypes.Role, "User"),
};

📌 To Do
🔒 Add password hashing with PasswordHasher<T>

📧 Add email verification

🔁 Add user profile update

👮 Add role-based admin panel

📃 License
This project is open-source and free to use under the MIT License.
