# N-Tier-Architecture
N-Tier Architecture
# NorthwindAPI - N-Tier Architecture Boilerplate

This is a **boilerplate ASP.NET Core Web API** demonstrating an **N-tier architecture** with **Entity Framework Core**, **Unit of Work pattern**, **Generic Repository**, and **AutoMapper**, using the **Northwind database**.

---

## Project Structure
NorthwindAPI/
│
├── NorthwindAPI.Domain/ # Entities and Interfaces
├── NorthwindAPI.Infrastructure/ # EF Core DbContext, Repositories, Unit of Work
├── NorthwindAPI.Application/ # Services, DTOs, Interfaces, AutoMapper
├── NorthwindAPI.API/ # ASP.NET Core Web API layer
└── NorthwindAPI.sln
