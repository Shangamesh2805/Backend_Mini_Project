# Video Store Management Web Application

## Objective
The primary objective of this project is to develop a comprehensive web application using ASP.NET Core for managing a video store. The application will facilitate renting videos, managing publisher content, and providing various user-specific functionalities, including membership discounts.

## Functional Features

### 1. User Login and Authentication
- Users can log in using their credentials.
- Authentication is implemented using JWT tokens.
- Two types of users: Normal users and Golden membership users.

### 2. User Types
- **Normal User:**
  - Can rent videos with a single device logged in.
- **Golden Membership User:**
  - Receives discounts on rentals.
  - Can log in from two devices simultaneously.

### 3. Publisher
- Publishers can modify video categories, set prices, and manage their published videos.
- Publishers can also have Golden membership privileges.

### 4. Payment Methods
- Implemented to apply discounts based on user types.
- Golden members receive specific discounts on rentals.

### 5. Video Catalog
- Videos are categorized by genre.
- Video attributes include video_id, genre, video_format, price, availability_status, title, description, and publisher_id.

### 6. Entities and Relationships
- **User Entity:**
  - Attributes: user_id, name, age, membership type, device limit, discount factor.
  - Relationships: One user can have many orders.
- **Order Entity:**
  - Attributes: order_id, user_id, total_amount, order_date, rental_expire_date.
  - Relationships: One order can have many order details.
- **OrderDetail Entity:**
  - Attributes: order_detail_id, order_id, video_id.
  - Relationships: Many-to-many relationship between orders and videos.
- **Video Entity:**
  - Attributes: video_id, genre, video_format, price, availability_status, title, description, publisher_id.
  - Relationships: One video can have many feedbacks and order details.
- **Publisher Entity:**
  - Attributes: publisher_id, publisher_name.
  - Relationships: One publisher can publish many videos.
- **Cart and CartItem Entities:**
  - Users can add videos to a cart before renting.
  - CartItems represent individual videos within a cart.
- **Feedback Entity:**
  - Users can leave feedback for videos.
  - Attributes: feedback_id, user_id, video_id, comment, rating.

## Project Structure
- **Controllers:** Handle API requests and business logic.
- **Services:** Implement business logic and interact with data.
- **Models:** Define data entities and DTOs.
- **Contexts:** Manage database connections and configurations.
- **DTOs:** Data Transfer Objects for transferring data between layers.

## Technologies Used
- **ASP.NET Core:** Framework for building web applications and APIs.
- **Entity Framework Core:** Object-Relational Mapping (ORM) for database interactions.
- **JWT Authentication:** Token-based authentication mechanism.
- **SQL Server:** Relational database management system.

## Getting Started
To run the project locally:
1. Clone this repository.
2. Set up your SQL Server database and update connection strings in `appsettings.json`.
3. Open the solution in Visual Studio or your preferred IDE.
4. Build and run the application.

## Contributors
- SHANGAMESHWAR K

