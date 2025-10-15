# 🪪 DVLD – Driving and Vehicle Licensing Department Management System

## 🧭 Overview
The **DVLD Project** is a complete **Driving and Vehicle Licensing Department Management System** developed using **C# Windows Forms** and **SQL Server**.  
This system automates and manages the core processes of a licensing department such as:
- Managing drivers and their personal data
- Issuing and renewing driving licenses
- Managing driving tests
- Handling international licenses
- Securing data through a proper login system

This project was built as part of a practical learning journey to strengthen programming, database, and system design skills.

---

## 🛠️ Tools & Technologies

| Category                | Tool / Technology                                  | Purpose                                                   |
|--------------------------|----------------------------------------------------|------------------------------------------------------------|
| 🖥️ Programming Language   | C# (.NET Framework – Windows Forms)                | Building the desktop application                           |
| 🧰 Database               | SQL Server                                        | Storing and managing application data                      |
| 💾 File Handling          | JSON / CSV                                        | Handling and saving some data locally                      |
| 🔗 Data Access            | ADO.NET                                           | Connecting the application to the database                 |
| 🧑‍💻 IDEs                  | Microsoft Visual Studio, SQL Server Management Studio (SSMS) | Development and database management           |
| 🐙 Version Control        | Git & GitHub                                      | Source code hosting and version control                    |

---

## 📂 Project Structure
DVLD/
│
├── 📁 Forms/ # Windows Forms UI files (Login, Licenses, Tests, etc.)
├── 📁 Classes/ # Business logic and data models
├── 📁 Data/ # JSON and CSV files (if used)
├── 📁 SQL/ # SQL database scripts and backups
├── 📁 Assets/ # Icons and images
├── Program.cs
└── README.md

---

## 🧰 Main Classes and Their Roles

| Class Name                  | Description                                                                 |
|-----------------------------|------------------------------------------------------------------------------|
| `clsClient`                 | Manages client account information                                          |
| `clsClientsData`            | Handles list operations for clients (Add, Update, Delete, Search)            |
| `clsLicense`                | Manages driver license information and status                                |
| `clsInternationalLicense`   | Manages international license records                                        |
| `clsTest`                   | Handles driving test results and appointments                                |
| `clsApplication`            | Manages license applications                                                |
| `clsUser`                   | Manages user login and authentication                                       |
| `clsDatabase`               | Handles database connection, SQL queries, and stored procedures              |
| `clsUtilities` *(optional)* | Helper functions for date formatting, validation, and other general actions  |

---

## 🧪 Database Information

- 📦 **Database Engine:** Microsoft SQL Server  
- 🧭 **Management Tool:** SQL Server Management Studio (SSMS)  
- 🧰 **Main Tables:**  
  - `Clients`  
  - `LocalDrivingLicenseApplications`  
  - `InternationalLicenses`  
  - `Tests`  
  - `TestAppointments`  
  - `Users`  
  - `Licenses`  
  - `Applications`  

The database contains relationships between clients, licenses, applications, and tests to ensure data consistency and support business rules.

---

## ⚙️ Core Functionalities

- 👤 **Client Management**
  - Add, update, delete, and view client profiles
  - Store personal and contact information
- 🪪 **License Management**
  - Issue new licenses
  - Renew and revoke licenses
  - Track license status and expiration dates
- 🌍 **International Licenses**
  - Issue and track international driving licenses
  - Check license validity
- 🧪 **Driving Tests**
  - Schedule test appointments
  - Record test results
  - Prevent license issuing if test not passed
- 📝 **Applications**
  - Manage new applications
  - Approve or reject requests
- 🔐 **User Login System**
  - Basic authentication
  - Access control
- 🗄️ **Database Integration**
  - All records stored in SQL Server
  - Database managed through SSMS
- 📊 **Reports & Queries**
  - Display and search clients, applications, and licenses
  - View active and expired licenses

---

## 🧭 How to Run the Project

### Step 1 – Clone the Repository
```bash
git clone https://github.com/YourUsername/DVLD.git
Step 2 – Open the Project

Open the solution in Microsoft Visual Studio.

Step 3 – Configure the Database

Open SQL Server Management Studio (SSMS).

Create a new database named DVLD_DB.

Run the SQL script from the SQL/ folder to create tables and stored procedures.

Check that all tables are created successfully.

Step 4 – Update Connection String

Open App.config or the relevant database connection file.

Update your SQL Server name, username, and password if needed.

Step 5 – Build and Run

Press F5 or Start Debugging.

Login using your admin account (or default credentials if provided).

🖼️ Future Improvements (Optional)

📱 Modern UI Design with better themes

🌐 Add online synchronization

🔒 Advanced role-based authentication

📨 Email/SMS notifications

📈 Analytics and dashboards

🧑‍💻 Author

Name: Alnoor Mahmoud

GitHub: @ AlnoorMahmoud
 

📜 License

This project is licensed under the MIT License — feel free to use, modify, and share.

✨ Thank you for checking out this project. Feedback and contributions are welcome! 🚀


---

✅ **Final steps:**  
1. Go to your GitHub repo root folder.  
2. Create a file named **`README.md`**.  
3. Paste everything above in one go.  
4. Replace `YourUsername` with your actual GitHub username.  
5. Save, commit, and push ✅

Would you like me to also prepare a **short version** (for your GitHub repo description line at the top)? (e.g. “A Windows Forms system for managing driving licenses and applications”) 📝✨

