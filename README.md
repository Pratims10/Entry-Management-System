# Entry-Management-System
Given the visitors that we have in office and outside, this is an entry management software to note these information.
The software is developed using .net framework with C# in Microsoft Visual Studio.
The Home.aspx is the Home page that has simply 2 options: 1. Enter entry details 2. Enter check-out time
The entry.aspx and exit.aspx the the front-end code of these 2 pages. The corresponding .cs file represent the backend codes.
The basic logic is that the user enters the entry details and a corresponding Unique ID is sent to his/her email. This ID is basically the auto-increment Primary Key of the database table 'entry'. These information are stored in the Database(MS SQL Server 2008) and they are also sent to the host along with the check-in time.  While leaving, he/she will enter this ID and the check-out time and will receive the details in his email. 

In entry.aspx page, the visitor name,email & phone number are entered and also those for the host. All these fields are marked mandatory and validation is also done. The checking for the proper syntax of an email address is also done. On entering these information properly, the email with the required information will be sent to the host along with the check-in time and the corresponding ID is sent to the visitor's email.

While leaving, the visitor goes to the exit.aspx page and enters the Unique ID provided in the email during check-in and also provides the check-out time. Here, some checks are provided in the exit.aspx.cs file. These fields must not be empty. If an already entered id is re-entered, then it will notify that 'Checkout time for this id has already been entered'. Cgeck out time cannot be greater than the current time and also checkout time cannot be before the checkin time. All these checks are provided to prevent any erroneous data. Finally the checkout time is also stored in the database in the corresponding record and the user is redirected back to the Home page.

Note: The function for sending SMS is sendsms(to,message). The Twilio API is used here. The accountSid and authToken will be received after registering with the Twilio account at https://www.twilio.com/ and are to be replaced in the web.config file in appsettings in the fields 'TwilioAccountSid' and 'TwilioAuthToken'. The field 'TwilioPhoneNumber' has to be replaced by the phone number received after registering the Twilio Account. The 2 header files Twilio.TwiML & using Twilio.AspNet.MVC and the sendsms functions are commented out for this purpose. The same applies for both the Entry.aspx.cs and Exit.aspx.cs files.
The sender email address and the password is also not provided in the sendmail() function in these 2 pages. Enter your own email id and password to use it to send emails to the host and visitor.

<img src="https://drive.google.com/open?id=19aRjX0avqww7ju8lhLpeVtb04av929BJ">
<img src='https://drive.google.com/open?id=1vBrkhfFumWmTAIP1tMCuKxvWnwo5lWmN'>
<img src='https://drive.google.com/open?id=1bK8yCKvCk9sk8m00l0ulviLuioADLERR'>
<img src='https://drive.google.com/open?id=1g8y1EuGcpw_lwoRL9LlXlBg8OMcgyh9A'>
<img src='https://drive.google.com/open?id=17kPTC_02xSgx_uW4WeFz3I-uV37oYhuL'>
<img src='https://drive.google.com/open?id=1IBn6duWn8sJ4z1l-NC01d_9w2pT6DKLh'>
