# CE141_CE149_.NetCore_HouseRentalSys
This House Rental Management System is a .NET Core MVC application designed to streamline the management of rental property, tenants, rent landlord .It offers a user-friendly interface for property owners, landlords, and property management to efficiently handle their rental business. Database is used to store data using EntityFrame Core

# Introduction to Layout.cshtml
Introduction to Layout.cshtml
It is the common master page of the application which contains
Header code
Footer code
and the User.Identity validation using User.Identity.Name
We also provide the bootstrap,css, javascript link here.
ViewStart.cshtml
We are rendering the main index body except header and footer using different pages and
every page contains the header and footer provided by ViewStart.cshtml

# Introduction to Admin And User Controller
Here, we are providing role based identification Login. There are two main role played here 1. Admin, 2. User
- It has 3 methods Login ,register and Logout
    - Login : It will check the user Identity & validate them using username and password.
              It will also check the model state and if there exists any server issue or
              incorrect credentials.
              [httpPost] : it will pass the query string using httpPost
    - Logout: It will use asynchronous method And it will redirect to Login Page.
    - Register: Admin will Regiter The USer with their username and password using this method.
    - Same, At User Side.

# Models As Table in Database
    1. AdminModel
    2. UserModel
    3. HouseBookingModel
    4. HouseDetailModel

# Controller 
    1. AdminController
    2. UserController
    3. HouseBookinController :- Here, User can Booked houses based on House Type and also All CRUD operation. 
    4. HouseDetailController :- Here, Admin can enter Details For specific house to giv it on Rent,further User which booked the house will be showed to admin.

# Views 
    1. Admin
    2. User
    3. HouseBooking :- Display View related to all CRUD Operation and show All Booked details
    4. HouseDetail :- Display View related to all CRUD Operation and show All Entered details
    
# For Running Purpose 
Firstly, Add the Database into your system like we are using Microsoft sql server. Provide admin_name and password manual into database 
and then enter it into form and click on login it will redirect to admin dashboard in which admin or landlord can enter house detail for rent and further
we can also login as USER by registering the user and then login it will redirect to user dashboard where user can book the house for rent. 

Database Server Name: (localdb)\MSSQLLocalDB
Database Name: RentalSystem

 "ConnectionStrings": {
   "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=RentalSystem;Trusted_Connection=True"
 }
ConnectionString will be in the appsettings.json



