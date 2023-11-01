# SANOKAAM - A JobPortal

SANOKAAM is a comprehensive job portal that empowers employers to post jobs and review applicants while providing job seekers with a platform to view and apply for positions that match their preferences. The system includes individual dashboards for employees, employers, and administrators, offering a tailored experience for each user type. It is built using the .NET Framework with C#, MVC (Model-View-Controller) web application architecture, a SQL Server database, Entity Framework for data access, and incorporates HTML, CSS, Bootstrap, and jQuery for a modern and user-friendly interface.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [User Accounts](#user-accounts)
- [Screenshots](#screenshots)

## Features
- **Job Posting**: Employers can easily post job listings, providing detailed information about the position, qualifications, and application process.

- **Applicant Management**: Employers have the ability to review and manage job applicants, making the hiring process efficient and organized.

- **Job Search**: Job seekers can search for job listings based on various criteria, including job title, location, and industry.

- **Application Submission**: Job seekers can submit their applications online.

- **User Dashboards**: Every user type (employee, employer, and admin) has access to a personalized dashboard where they can manage their respective tasks and activities.

- **Secure Authentication**: The system uses a robust authentication system to protect user data and ensure that only authorized individuals can access their accounts.

## Installation

1. **Clone the Repository**: Clone the SANOKAAM repository to your local machine.

   ```bash
   git clone https://github.com/sushrit7/JobPortal.git
   ```

2. **Database Configuration**: Create a SQL Server database and update the connection string in the `appsettings.json` file.

3. **Build and Run**: Build the project and run it using Visual Studio or your preferred development environment.

## Usage

1. **User Registration**: Users can register for an account using the registration page. Different account types (employee, employer, admin) can be selected during registration.

2. **Login**: Users can log in using their credentials to access their personalized dashboards and perform actions based on their user type.

3. **Posting Jobs**: Employers can post job listings by providing job details, qualifications, and job-specific information.

4. **Applying for Jobs**: Job seekers can search for jobs and apply to positions that match their qualifications and preferences.

## User Accounts

The system has three main user account types:

- **Employee**: Job seekers who can search for jobs and apply.
- **Employer**: Employers who can post jobs and review applicants.
- **Admin**: Administrators who have overall control over the system, including managing users and system settings.

## Screenshots

![Homepage](screenshots/homepage.png)
*Sample screenshot of the homepage.*

<table>
    <tr>
        <td>
            <img src="screenshots/addjob.png" width="250" alt="Add Job">
            <br>
            <em>Add Job</em>
        </td>
        <td>
            <img src="screenshots/applicant.png" width="250" alt="Applicant">
            <br>
            <em>Applicant</em>
        </td>
        <td>
            <img src="screenshots/applicationreview.png" width="250" alt="Application Review">
            <br>
            <em>Application Review</em>
        </td>
    </tr>
    <tr>
        <td>
            <img src="screenshots/employeedashboard.png" width="250" alt="Employee Dashboard">
            <br>
            <em>Employee Dashboard</em>
        </td>
        <td>
            <img src="screenshots/employerdashboard.png" width="250" alt="Employer Dashboard">
            <br>
            <em>Employer Dashboard</em>
        </td>
        <td>
            <img src="screenshots/hire.png" width="250" alt="Hire">
            <br>
            <em>Hire</em>
        </td>
    </tr>
    <tr>
        <td>
            <img src="screenshots/homepage-carousel.png" width="250" alt="Homepage Carousel">
            <br>
            <em>Homepage Carousel</em>
        </td>
        <td>
            <img src="screenshots/jobdescription.png" width="250" alt="Job Description">
            <br>
            <em>Job Description</em>
        </td>
        <td>
            <img src="screenshots/joblistings.png" width="250" alt="Job Listings">
            <br>
            <em>Job Listings</em>
        </td>
    </tr>
    <tr>
        <td>
            <img src="screenshots/loginportal.png" width="250" alt="Login Portal">
            <br>
            <em>Login Portal</em>
        </td>
        <td>
            <img src="screenshots/myjobs.png" width="250" alt="My Jobs">
            <br>
            <em>My Jobs</em>
        </td>
        <td>
            <img src="screenshots/professionalprofile.png" width="250" alt="Professional Profile">
            <br>
            <em>Professional Profile</em>
        </td>
    </tr>
    <tr>
        <td>
            <img src="screenshots/professionalprofileupdate.png" width="250" alt="Professional Profile Update">
            <br>
            <em>Professional Profile Update</em>
        </td>
    </tr>
</table>

_For screenshots, please check the [Screenshots](/screenshots) directory._

---

Feel free to explore SANOKAAM - A JobPortal and contribute to its development. If you have any questions or encounter issues, please open a GitHub issue, and I'll be happy to assist you. Enjoy using SANOKAAM!
