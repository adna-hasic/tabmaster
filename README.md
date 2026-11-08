# TabMaster

**TabMaster** is a web application designed to simplify digital ordering, payment processing, and order management in cafés and similar hospitality establishments.

The application allows guests to scan a unique QR code at their table to access a digital menu, browse available products, and place orders without creating an account or logging in. Guests can also track their order status, choose a payment method, and request waiter assistance directly through the application.

Employees can manage incoming orders, update order statuses, and control product availability through a dedicated dashboard. Administrators have additional access to product, category, table, and employee management, as well as business statistics and system settings.

The main goal of TabMaster is to streamline the ordering process, improve service efficiency, and simplify daily operations for hospitality staff.


## User Roles & Features

TabMaster supports three main user roles, each with different functionalities and access permissions.

### Guest
- Access the digital menu by scanning a table-specific QR code.
- Browse products by category and search for specific items.
- Add products to the cart, adjust quantities, and include special requests.
- Place orders without registration or login.
- Track order statuses and cancel orders before employee acceptance.
- Choose between cash and simulated card payments, with support for BAM and EUR.
- Request waiter assistance directly through the application.

### Employee
- View and manage incoming orders through a dedicated dashboard.
- Accept or reject orders and update their statuses.
- Receive notifications for new orders and waiter assistance requests.
- Manage product availability.
- Record cash payments and view order history.

### Administrator
- Access all employee functionalities.
- Manage products, categories, and tables.
- Generate and download unique QR codes for tables.
- Manage employee accounts and permissions.
- Monitor payments and process refund requests.
- View business statistics, including revenue and order activity.
- Configure basic system settings.


## How It Works

TabMaster simplifies the ordering process through the following steps:

1. **Scan QR Code** – The guest scans a unique QR code assigned to their table to access the digital menu.

2. **Browse Menu** – The guest explores available products, selects quantities, and adds optional notes or special requests.

3. **Place Order** – The guest reviews their cart, selects a payment method (cash or simulated card payment), and submits the order.

4. **Order Processing** – Employees receive the order, review its details, and accept or reject it.

5. **Order Tracking** – The guest can track the order status as it progresses through preparation and service.

6. **Payment** – Card payments are simulated within the application, while cash payments are recorded by employees.

7. **Order Completion** – Once the order is served and payment is completed, the order is finalized.

Guests can request waiter assistance directly through the application. They can also place multiple orders during their visit, with each order submitted through the digital menu, associated with the correct table, and tracked separately.


## Technologies Used

TabMaster uses the following technology stack:

### Backend
- **ASP.NET Core Web API (.NET 10)** – Backend development and REST API implementation.
- **Entity Framework Core 10** – Database access and management.
- **C#** – Backend programming language.

### Frontend
- **Angular 21** – Frontend application development.
- **TypeScript** – Frontend programming language.
- **Angular Material** – User interface components.
- **HTML & CSS** – Application structure and styling.

### Database
- **Microsoft SQL Server** – Relational database for storing application data.

### Development & Project Management
- **Git & GitHub** – Version control and source code management.
- **GitHub Projects** – Task organization and development progress tracking.
- **GitHub Issues** – Feature planning and task management.


## Project Structure

TabMaster is organized into separate backend and frontend applications, following the structure of the original starter project.

```text
TabMaster/
├── Market.Backend/       # ASP.NET Core Web API
├── Market.Frontend/      # Angular application
├── db-backups/           # Database backups
├── dokumenti/            # Project documentation
└── README.md             # Project overview and documentation
```

### Backend
The backend handles business logic, database operations, authentication, authorization, and API communication.

### Frontend
The frontend provides user interfaces for guests, employees, and administrators, allowing them to interact with the system according to their roles.

### Additional Directories
- **db-backups/** – Reserved for database backups.
- **dokumenti/** – Reserved for project-related documentation.

The project currently retains the original starter directory names. Its structure and components will be adapted as TabMaster development progresses.


## Development Roadmap

TabMaster is being developed in several phases, with tasks organized and tracked through GitHub Issues and GitHub Projects.

### Phase 1 – Project Setup
- Set up the GitHub repository and project board.
- Import and review the starter project.
- Define application requirements and create GitHub Issues.
- Prepare the development environment.
- Remove unused starter features and adapt the project structure.

### Phase 2 – Core Functionality
- Implement table management and QR code generation.
- Develop QR-based guest access and table identification.
- Adapt the digital menu, shopping cart, and ordering process.
- Implement order tracking, cancellation, and status management.

### Phase 3 – Payments and Employee Features
- Implement simulated card payments and cash payment recording.
- Support BAM and EUR transactions and refund processing.
- Develop the employee dashboard and waiter call functionality.
- Implement notifications and product availability management.

### Phase 4 – Administration and Statistics
- Implement employee account management and role-based access control.
- Adapt product and category administration.
- Develop business statistics and system settings.

### Phase 5 – Testing and Finalization
- Test the application's main functionalities.
- Fix identified issues and improve usability.
- Complete project documentation and prepare the final version.

Development progress can be followed through the [TabMaster GitHub Project](https://github.com/users/adna-hasic/projects/1).

### Note

TabMaster is currently in the early stages of development. The listed features represent planned functionality and will be implemented progressively.


## Author

**Adna Hasić**  
**Student ID:** IB230049

Student at the Faculty of Information Technologies, University "Džemal Bijedić" of Mostar.

**GitHub:** [adna-hasic](https://github.com/adna-hasic)

TabMaster is an individual student project developed as part of the Software Development I (RS1) course.



