# C# WinForms Secure Login System (SQL Server & PBKDF2 Hashing)

This project is a simple demonstration of how to implement secure user registration (Sign-Up) and login (Sign-In) processes in a C# Windows Forms application using SQL Server.

The core objective is to ensure that passwords are **NEVER stored in plain text** in the database, adhering to modern security best practices.

## 🔒 Security Features

* **PBKDF2 Hashing:** Passwords are hashed using the **PBKDF2** (Password-Based Key Derivation Function 2) algorithm, which is designed to be slow and resistant to brute-force attacks.
* **Salting:** Each password is combined with a unique, randomly generated 'salt' before hashing. This ensures that users with the same password will have different hash values in the database.
* **Built-in .NET Solution:** The hashing logic uses the .NET Framework's built-in `Rfc2898DeriveBytes` class (found in `PasswordHasher.cs`), eliminating the need for external libraries.

## 🛠️ Setup and Execution

To run the project on your local machine, please follow these steps:

### 1. Prepare the SQL Database

1.  In SQL Server Management Studio, create a database named `Users`.
2.  Within this database, create a table named `User_Table` with the following columns:
    * `Username` (e.g., `NVARCHAR(50)`)
    * `Password` (Use **`NVARCHAR(100)`** or larger to store the full PBKDF2 hash string.)

### 2. Update Connection Strings

For security reasons, the server name is set as a placeholder in the code.

1.  Open the **`Form1.cs`** and **`Form2.cs`** files in the project.
2.  Locate the `SqlConnection` definition near the top of both files and update it with your actual local SQL Server details:

```csharp
// REPLACE WITH YOUR ACTUAL SERVER NAME AND DB NAME
SqlConnection connection = new SqlConnection(@"Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Integrated Security=True");
