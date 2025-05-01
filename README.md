<div align="center">

### **PONTIFICAL CATHOLIC UNIVERSITY OF MINAS GERAIS**

### **PUC Minas Virtual**

### **Postgraduate Program (Lato Sensu) in Software Engineering**

<br/><br/>

### Integrated Project

### Technical Report

### Tech Barbershop

<br/><br/>

### **Gustavo Cesar Mariano**

<br/>

### Belo Horizonte

03/2023

</div>

---

# 🪒 Tech Barbershop - Barbershop Management System

This project was developed as a Capstone Project (TCC) for the Postgraduate Program in Software Engineering at PUC Minas Virtual. **Tech Barbershop** is a web application designed to connect barbers and clients, streamlining the process of scheduling appointments, managing client records, and enhancing the visibility of barbershop services through a user-friendly platform.

## 🚀 Technologies Used

- **Front-End**: HTML, CSS, JavaScript (ASP.NET MVC)
- **Back-End**: C# (ASP.NET Core)
- **Database**: Microsoft SQL Server (hosted on Azure)
- **ORM**: Entity Framework (for database interaction)
- **Hosting**: Microsoft Azure (for production deployment)

## 🎯 Purpose

The primary goal of Tech Barbershop is to automate manual processes in barbershops by providing:

- Online appointment scheduling for clients.
- Efficient management of client records and barber schedules.
- Increased visibility for barbers through a dedicated profile page.

### Specific Objectives
- Facilitate connections between barbers and nearby clients.
- Expand barbers' online presence to attract new clients.
- Provide barbers with a platform to showcase their services.

## 🌟 Key Features

- **Appointment Scheduling**: Clients can book, edit, or cancel appointments through a barber's agenda.
- **Client and Barber Profiles**: Users can create and manage profiles, with barbers able to specify accepted payment methods and availability.
- **Responsive Design**: Interface adaptable for mobile devices, ensuring accessibility.
- **Agenda Management**: Barbers can manage their schedules, marking available and unavailable time slots.
- **Operational Insights**: Both clients and barbers can view past and upcoming appointments.

## 🛠️ How to Run the Project

1. Clone the repository: `git clone https://github.com/GustavoMariano/TCC-PUC-Tech-Barbershop.git`
2. Set up the .NET environment and a local MS SQL Server database.
3. Configure the connection string in the application to point to your database.
4. Run the application using the command `dotnet run` in the project directory.
5. Access the application in your browser at `http://localhost:5000`.

### Deployment Note
The application was deployed to production on Microsoft Azure directly from GitHub for evaluation purposes. It was previously accessible at `https://gustavomarianotechbarbershop.azurewebsites.net` during the project assessment phase but is no longer live.

## 📽️ Additional Resources

- **System Presentation Video**: [YouTube](https://www.youtube.com/watch?v=LBTaLx2onaY)
- **Navigable Prototype Video**: [YouTube](https://www.youtube.com/watch?v=yzLgXxpL92E)

## 🏗️ Architecture

Tech Barbershop adopts the **MVC (Model-View-Controller)** architectural pattern to ensure efficient interaction between the user interface and the database. The application was hosted on **Microsoft Azure**, with the front-end built using ASP.NET MVC, the back-end developed in C# with ASP.NET Core, and data persistence handled by MS SQL Server via Entity Framework.

### C4 Model - Context Diagram
The system consists of a web application that interacts with users (clients and barbers) through an MVC interface, connecting to a cloud-hosted database on Azure for data management.

## ⏱️ Development Timeline

The project was developed between March and October 2023, with a total of 129 hours invested. Key milestones included defining requirements, creating a navigable prototype, developing the application, and deploying it on Azure for production evaluation.

## 📝 Author

- **Gustavo Cesar Mariano**
- Postgraduate Program in Software Engineering, PUC Minas Virtual
- Completed in: March 2023

## 📜 License

This project is for academic purposes and does not have a public license.
