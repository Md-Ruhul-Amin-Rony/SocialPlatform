# SocialPlatform
# Reactivities

Welcome to **Reactivities**, a modern and robust event management application built with ASP.NET Core and React. This application allows users to create, manage, and join events, while providing functionalities for live chat, photo uploads, and social interactions.

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Clean Architecture](#clean-architecture)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Fronted Repo Link](#fronted-repo-link)
- [Screenshots](#screenshots)
- [Contributing](#contributing)


## Features

- 🗓️ **Event Management:** Users can create, read, update, and delete (CRUD) events.
- 🔐 **User Authentication:** Secure authentication using JWT tokens.
- 💬 **Real-time Chat:** Live chat functionality using SignalR.
- 📸 **Photo Uploads:** Users can upload and manage photos using Cloudinary.
- 👥 **Follow Users:** Users can follow and unfollow each other.
- 📱 **Responsive Design:** Mobile-friendly UI for seamless user experience across devices.

## Tech Stack

**Frontend:**
- React
- TypeScript
- MobX (State Management)
- Formik (Form Management)
- Yup (Validation)
- React Toastify (Notifications)
- React Dropzone & React Cropper (Photo Upload)
- React Datepicker (Date Management)

**Backend:**
- ASP.NET Core
- Entity Framework Core
- SignalR (Real-time Communication)
- FluentValidation (Server-side Validation)
- Cloudinary API (Photo Storage)
- MediatR (CQRS and Mediator Pattern)

**Database:**
- SQL Server

# Clean Architecture

## Clean Architecture Overview

Clean Architecture, introduced by Robert Martin, emphasizes a structured approach to building applications, with a focus on separation of concerns and maintainability. The architecture is based on several key principles:

## Dependency Rule
- Dependencies are encapsulated within each ring of the architecture.
- Each layer depends only on the layers closer to the center, keeping important business rules isolated.

## Layers
### Entities (Domain Layer):
- Contains business logic common to all applications.
- Represents core business entities, such as activities in our case.

### Use Cases (Application Layer):
- Encapsulates all business logic and implements use cases.
- Each use case is represented by a class and handler.
- Completely isolated from the user interface, allowing flexibility in UI implementation.

### Interface Adapters (API Layer):
- Acts as a connector between business logic and framework-specific code.
- Includes API controllers, which retrieve information from the application layer.

### Frameworks and Drivers:
- Outer layer containing the user interface and database.
- Clean architecture principles ensure independence from specific frameworks and databases.

## Flow of Control
- Application layer responsible for processing business logic.
- Mediator pattern used for handling communication between API controllers and application layer.

## Recommendations
- Architecture should be independent from frameworks, interfaces, and databases.
- Business logic should be testable and independent from external elements.
- Flexibility to change UI or database implementations without modifying core business logic.


## Project Structure
**API:**
-Contains controllers and middleware.
Acts as the interface adapter, connecting business logic to framework-specific code.

**Application:**
-Houses CQRS handlers and Mediator implementations.
Implements business logic and use cases, independent of UI considerations.

**Domain:**
-Defines entities and encapsulates core business logic.
Contains essential business objects, such as activities.

**Infrastructure:**
-Handles data access and external services.
Includes implementations of data repositories and external integrations.

**Persistence:**
-Houses the EF Core Data Context.
Provides data persistence functionality using Entity Framework Core.

**client-app:**
-React application for the front end.
Contains components, features, layout, models, stores, and routing logic.
## Directory Explanation

- **/API**: Contains the controllers and middleware used for handling HTTP requests and responses.
- **/Application**: Houses CQRS handlers and the Mediator pattern implementation for processing business logic.
- **/Domain**: Defines the core business logic and entities.
- **/Infrastructure**: Manages data access and external service integrations.
- **/Persistence**: Contains the EF Core data context for database interactions.
- **/client-app**: The React application front-end.
  - **/app/common**: Common components used throughout the application.
  - **/app/features**: Components and pages for specific features.
  - **/app/layout**: Layout components like navigation, headers, and footers.
  - **/app/models**: TypeScript models for type definitions.
  - **/app/stores**: MobX stores for state management.
  - **/app/router**: Routing configuration and components.
  - **index.tsx**: The entry point of the React application.
- **/scripts**: Deployment and build scripts.
- **README.md**: Project documentation.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/en/download/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Usage

1. **Register and Login:**  
   - Register a new user and login to access the application features.

2. **Create Events:**  
   - Navigate to the "Create Event" page and fill in the event details.

3. **Manage Events:**  
   - View, edit, or delete events from your profile.

4. **Join Events:**  
   - Join any published event and engage with other attendees.

5. **Live Chat:**  
   - Use the live chat feature to communicate with other users in real-time.

6. **Upload Photos:**  
   - Upload and manage your photos using the photo upload feature.

7. **Follow Users:**  
   - Follow other users to stay updated with their activities.
  

## Fronted Repo Link:
   https://github.com/Md-Ruhul-Amin-Rony/SocialPlatformFronted.git

## Screenshots

### Home Page

<img src="https://github.com/Md-Ruhul-Amin-Rony/SocialPlatform/assets/112938703/a28ccc48-b859-428b-b617-e785c569a031" alt="HomePage" width="50%">

### Create Event

<img src="https://github.com/Md-Ruhul-Amin-Rony/SocialPlatform/assets/112938703/ec3446ae-8d07-4a06-a129-c121aced122f" alt="Create Event" width="50%">

### Event Details

<img src="https://github.com/Md-Ruhul-Amin-Rony/SocialPlatform/assets/112938703/3bcf89d9-def3-4b2d-a252-764ef332b460" alt="Event Details" width="50%">

### Live Chat

<img src="https://github.com/Md-Ruhul-Amin-Rony/SocialPlatform/assets/112938703/18299007-b504-4ce3-9190-bbc4cfd0bb15" alt="Live Chat" width="50%">


## Contributing

Contributions are welcome! Please follow the [contribution guidelines](/path/to/contribution-guidelines.md).




