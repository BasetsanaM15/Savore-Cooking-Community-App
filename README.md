Savore – Cooking Community App 

Module: Advanced C# Programming

Institution: Eduvos (Pty) Ltd

Developer: Basetsana Mabusela

Lecturer: Charles Mukwevho 

Overview:

Savore is a distributed ASP.NET web application built as part of the Advanced C# Programming module at Eduvos. It is designed for an online cooking community where registered users can share, view, and rate recipes.
The system supports user authentication, secure password management, personal recipe dashboards, and recipe rating functionality. It includes a Web Service layer for database interaction and logs each rating submitted.

Features:

User Registration & Login-
Secure registration using email, password, and personal details. Login and password recovery via security question included.

Personal Profile Management-
Users can update their personal information and change their passwords at any time.

Recipe Management-
Submit new recipes with name, ingredients, and method, 
View detailed recipe information including average rating, 
View a personal dashboard with submitted recipes and their rating summaries.

Rating System-
Logged-in users can rate other users’ recipes (1 to 5).
Ratings cannot be changed once submitted.

Access Control-
Unauthenticated users are redirected to the login page if trying to access protected areas.

Log Out Functionality-
Users can securely end their session via the logout feature.

Technologies Used:

Front-End & Back-End: ASP.NET Web Forms (C#)

Web Service: ASP.NET Web Service (ASMX)

Database: SQL Server (alternatively compatible with MS Access)

Logging: Text file log for rating submissions

Database Structure:


Users Table – Stores user information including email, password, and security question/answer.

Recipes Table – Stores recipe details: name, ingredients, method, owner ID.

Ratings Table – Stores rating records: recipe ID, user ID, rating value.

How It Works:


User registers → email and password are stored securely.

User logs in → gains access to view, post, and rate recipes.

Recipe ratings → submitted through the Web Service and stored in the database.

Ratings are logged in a .txt file with user email, recipe name, and rating value.

Recipe owners can view all their recipes with average and total ratings.

File Structure (Main Folders):


/Savore-Cooking-Community-App
├── /App_Code
├── /App_Data
├── /WebService
│   └── RecipeService.asmx
├── /Pages
│   ├── Register.aspx
│   ├── Login.aspx
│   ├── ViewRecipes.aspx
│   ├── SubmitRecipe.aspx
│   ├── RateRecipe.aspx
│   └── Profile.aspx
├── /Logs
│   └── ratings.txt
├── Web.config
└── README.md

Academic Integrity Notice


This project was developed as an academic submission for Eduvos and follows all plagiarism and referencing policies. All work is original and complies with academic honesty standards.

Contact


For questions or feedback regarding this project, please contact me on GitHub or via email.

