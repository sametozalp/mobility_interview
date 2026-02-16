# Mobility Projects


## Project Overview

### 🖥️ Project_One - Windows Forms Application
A desktop application built with C# and Windows Forms (.NET 9.0).

**Technology Stack:**
- C# .NET 9.0
- Windows Forms
- Visual Studio Solution

**Key Features:**
- Windows desktop application with GUI
- Form-based user interface
- Standard Windows application architecture

**Location:** `Project_One/`

---

### 🌐 Project_Two - Vue.js Web Application with ASP.NET Core Backend
A full-stack web application with Vue.js frontend and ASP.NET Core backend services.

**Frontend Technology Stack:**
- Vue 3.5.27
- TypeScript 5.9.3
- Vite 7.3.1
- Pinia (State Management)
- Vue Router 5.0.1
- Axios (HTTP Client)

**Backend Technology Stack:**
- ASP.NET Core Web API
- C# .NET
- Entity Framework Architecture
- Multi-layer Architecture (Controllers, Business, DataAccess, Entity)
- OpenAPI/Swagger Documentation

**Key Features:**
- **Frontend:** Single Page Application (SPA), Component-based architecture, TypeScript support, Hot module replacement
- **Backend:** RESTful APIs, Entity management system, Person record management, Logging system
- **Architecture:** Clean architecture with separation of concerns, Multiple API endpoints
- **Development:** ESLint and OxLint for code quality, Modern development tooling

**Backend Services:**
- **Entity Management:** CRUD operations for Person entities
- **Data Operations:** Add, delete, list, and search functionality

**Location:** `Project_Two/` (contains both `vue-pro/` frontend and `EntityManagementAspNet/` backend)

---

### 🌐 Project_Three - Vue.js Web Application with External API Integration
A Vue.js web application that connects to external backend services for data management.

**Frontend Technology Stack:**
- Vue 3.5.27
- TypeScript 5.9.3
- Vite 7.3.1
- Pinia (State Management)
- Vue Router 5.0.1
- Axios (HTTP Client)

**Backend Integration:**
- **External Entity API:** Connects to `http://localhost:8080/api` for entity operations
- **External Web Service API:** Connects to `http://localhost:8082/api` for web operations
- **RESTful Communication:** JSON-based API interactions
- **Dual Service Architecture:** Separate services for entity and web operations

**Key Features:**
- **Frontend:** Complete Vue 3 + TypeScript setup, Component-based architecture, Hot module replacement
- **API Integration:** External service communication, Person record management via APIs
- **Data Operations:** Add, delete, list, and search functionality through external services
- **Development:** Comprehensive README, Browser devtools integration, ESLint support

**API Endpoints Used:**
- **Entity Service (Port 8080):** `/entity/add`, `/entity/delete`, `/entity/list`, `/entity/search`
- **Web Service (Port 8082):** `/entity/add`, `/entity/delete`, `/entity/list`, `/entity/search`

**Location:** `Project_Three/vue-pro/` (frontend only - connects to external backend services)

---

### ⚙️ Project_Four - C++ DLL & Console Applications
A collection of native applications including a C++ DLL and a .NET console application.

**Technology Stack:**
- C++ (Dynamic Library)
- C# .NET 9.0 (Console Application)
- Visual Studio C++ and .NET projects

**Components:**
- **Dll_Project:** C++ Dynamic Link Library (Win32/x64)
- **ConsoleApp1:** .NET 9.0 Console Application

**Key Features:**
- Native C++ library development
- Cross-platform .NET console application
- Windows-specific DLL implementation
- Multiple build configurations (Debug/Release)

**Location:** `Project_Four/`
