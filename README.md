# QR Restaurant Ordering System with Chatbot

A modern QR-based restaurant ordering system integrated with a chatbot, built using **ASP.NET Core Web API**, **SQL Server**, and a **HTML/CSS/JavaScript frontend**.

---

## Features

### Customer (Mobile)

* Scan QR code to access menu
* Browse products and categories
* Add items to cart
* Place orders
* Track order status
* Chat with chatbot (AI support)
* Get product suggestions

### Kitchen Staff

* View incoming orders
* Update cooking status (Pending → Preparing → Ready)

### Cashier

* Manage payments (Cash / Bank Transfer)
* Confirm orders

### Manager

* Dashboard (revenue, orders)
* View reports (shift, sales)
* Monitor system activity

---

## Platform Behavior

| Device    | Features                        |
| --------- | ------------------------------- |
|  Mobile | Full features (Order + Chatbot) |
|  PC     | View menu only                  |

---

## Tech Stack

* **Backend:** ASP.NET Core Web API (.NET 8)
* **Database:** SQL Server
* **Frontend:** HTML, CSS, JavaScript
* **ORM:** Entity Framework Core
* **Environment Config:** .env

---

## Project Structure

### Backend

```text
/backend/QRRestaurant.API
├── Controllers
├── Services
├── DTOs
├── Entities
├── Data
├── Middleware
└── Program.cs
```

### Frontend

```text
/frontend
├── src
│   ├── core
│   ├── features
│   ├── services
│   └── shared
├── assets
└── index.html
```

### Database

```text
/database/database.sql
```

---

## Setup Instructions

### 1. Clone repository

```bash
git clone https://github.com/your-username/QRRestaurant.git
cd QRRestaurant
```

---

### 2. Setup environment

Create `.env` file:

```env
DB_CONNECTION=Server=.;Database=QRRestaurantDB;Trusted_Connection=True;TrustServerCertificate=True;
```

---

### 3. Run database

* Open SQL Server
* Run file: `/database/database.sql`

---

### 4. Run backend

```bash
cd backend/QRRestaurant.API
dotnet run
```

API will run at:

```text
https://localhost:xxxx
```

---

### 5. Run frontend

* Open `index.html` in browser
* Or use Live Server (VS Code)

---

##  Database Overview

Main tables:

* Users
* Tables
* Products
* Orders
* OrderItems
* Payments
* ChatSessions
* ChatMessages
* ChatContexts
* ShiftReports

---

##  Chatbot Features

* Keyword-based response (rule-based)
* Context tracking (last selected product)
* Order assistance
* Product recommendation

---

##  Security

* Environment variables via `.env`
* Sensitive data excluded via `.gitignore`

---

##  Future Improvements

* AI recommendation system
* Online payment gateway
* Admin dashboard UI
* Mobile optimization

---

##  Author

* Student Project – QR Restaurant System

---

##  Notes

This project is designed for educational purposes and demonstrates a full-stack system including backend API, frontend UI, database design, and chatbot integration.
