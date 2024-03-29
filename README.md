# Entry-Management-System
Given the visitors that we have in office and outside, this is an entry management software to note these information.
The software is developed using .NET framework with C# in Microsoft Visual Studio.
The Home.aspx is the Home page that has simply 2 options: 1. Enter entry details 2. Enter check-out time

The entry.aspx and exit.aspx are the front-end codes of these 2 pages. The corresponding .cs file represent the backend codes.
The basic logic is that the user enters the entry details and a corresponding Unique ID is sent to his/her email. This ID is basically the auto-increment Primary Key of the database table 'entry'. These information are stored in the Database(MS SQL Server 2008) and they are also sent to the host along with the check-in time.  While leaving, he/she will enter this ID and the check-out time and will receive the details in his email. 

In entry.aspx page, the visitor name,email & phone number are entered and also those for the host. All these fields are marked mandatory and validation is also done. The checking for the proper syntax of an email address is also done. On entering these information properly, the email with the required information will be sent to the host along with the check-in time and the corresponding ID is sent to the visitor's email.

While leaving, the visitor goes to the exit.aspx page and enters the Unique ID provided in the email during check-in and also provides the check-out time. Here, some checks are provided in the exit.aspx.cs file. These fields must not be empty. If an already entered id is re-entered, then it will notify that 'Checkout time for this id has already been entered'. Check out time cannot be greater than the current time and also checkout time cannot be before the checkin time. All these checks are provided to prevent any erroneous data. Finally the checkout time is also stored in the database in the corresponding record and the user is redirected back to the Home page.

Note: The function for sending SMS is sendsms(to,message). The Twilio API is used here. The accountSid and authToken will be received after registering with the Twilio account at https://www.twilio.com/ and are to be replaced in the web.config file in appsettings in the fields 'TwilioAccountSid' and 'TwilioAuthToken'. The field 'TwilioPhoneNumber' has to be replaced by the phone number received after registering the Twilio Account. The 2 header files Twilio.TwiML & using Twilio.AspNet.MVC and the sendsms functions are commented out for this purpose. The same applies for both the Entry.aspx.cs and Exit.aspx.cs files.
The sender email address and the password is also not provided in the sendmail() function in these 2 pages. Enter your own email id and password to use it to send emails to the host and visitor. Open the Web.config file. In the appsettings, provide the email address and password in the required value fields.

Also, in the Web.config file, go to the connectionStrings section and change the DBCS connection string with the connection string of your server.

Here are the screenshots of the application:


<img src="Firefox_Screenshot_2019-11-23T21-41-57.536Z.png">
<img src='Firefox_Screenshot_2019-11-23T21-43-00.154Z.png'>
<img src='Firefox_Screenshot_2019-11-23T21-44-22.315Z.png'>
<img src='Firefox_Screenshot_2019-11-23T21-45-37.416Z.png'>
<img src='Firefox_Screenshot_2019-11-23T21-47-38.156Z.png'>
<img src='Firefox_Screenshot_2019-11-23T21-50-29.874Z.png'>

A screenshot of the database table and its design:

<img src='screenshot_20191124_140243.png'>
<img src='screenshot_20191124_140320.png'>
