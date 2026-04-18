# Car Rental Management System

A full-stack **Car Rental Management System** built with **C# WinForms (.NET)** and **MySQL**, providing a complete desktop solution for managing car rentals, customers, payments, and discounts.

---

## Tech Stack

- **Frontend:** C# Windows Forms (WinForms)
- **Backend Logic:** C# (.NET)
- **Database:** MySQL
- **Data Access:** MySQL Connector/NET
- **Storage:** Relational database + file system (receipts)

---
<img width="1249" height="734" alt="b4" src="https://github.com/user-attachments/assets/cf1369e8-4b83-4a32-bc41-b2bd4adca0be" />

---


## Features

### Car Management
- Add, view, and delete cars
- Track car availability in real time
- Recall (restore/adjust) car rental status

### Customer Management
- Store and manage customer information
- Track active rentals per customer
- Ban/unban and status handling

### Rental System
- Rent cars with start/end dates
- Automatic price calculation based on duration
- Prevent double booking of cars
- Track active rentals between cars and customers

### Payments & Coupons
- Record payments per rental
- Support payment methods
- Apply discount coupons with expiry validation

### 🧾 Receipts
- Auto-generate rental receipt files (.txt)
- Includes customer, car, dates, and total cost

---

## UI Overview

Built with WinForms, the app includes:
- Car management screen (grid + add/delete/recall controls)
- Customer management screens
- Rental creation and tracking forms
- Payment handling interface

Example UI components:
- DataGridView for displaying cars
- Text inputs for car details (make, model, year, rate)
- Buttons for actions (Add, Delete, Recall)

---

## Architecture

The system follows a layered structure:
- **WinForms UI layer** – user interaction
- **Repository layer** – database operations
- **Service layer** – business logic (renting, pricing, coupons)
- **Database layer** – MySQL storage

---


## Summary

A desktop-based full-stack system for managing a car rental business, combining **WinForms UI**, **C# backend logic**, and **MySQL database integration** into a complete working application.
