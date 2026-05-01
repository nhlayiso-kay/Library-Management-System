# Library Management System (LMS)

## 📖 Project Overview
This is a fully functional management system developed in **C#** using **Windows Forms**[cite: 1, 2]. The application demonstrates core **Object-Oriented Programming (OOP)** principles through a role-based system for librarians and members.

## 🚀 Features
*   **Role-Based Login:** Separate interfaces for Librarians and Members[cite: 1, 2].
*   **Librarian Tools:** Add/search books, register members, and manage the database[cite: 1, 2].
*   **Member Tools:** View available books, borrow items, and return them[cite: 1, 2].
*   **Error Handling:** Uses a custom `BookNotAvailableException` to prevent borrowing unavailable books[cite: 1, 2].

## 🛠️ Technical Implementation (OOP)
*   **Abstraction:** Base `User` class for shared logic.
*   **Inheritance:** `Librarian` and `Member` classes inherit from the `User` base[cite: 2].
*   **Polymorphism:** Overridden `GetRole()` methods for specific user identification[cite: 2].
*   **Data Store:** Centralized in-memory repository using the `LibraryData` static class[cite: 2].

## 💻 How to Run
1.  Clone this repository to your local machine.
2.  Open the `LibraryManagementSystem.sln` file in **Visual Studio**[cite: 2].
3.  Press **F5** to build and run the application[cite: 1, 2].

### Default Admin Credentials
*   **Username:** `Admin`[cite: 1, 2]
*   **Password:** `lib123`[cite: 1, 2]