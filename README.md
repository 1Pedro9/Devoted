# Devoted
C# software that helps keep book of you finances.

This program is very simplistic at the moment. 
This README is created before the project has been started [19/08/2024 20:41:10]. There has already been a django-application developed for this Devoted App, but not yet software. 
This program will be created in C#. 
The following is a discription of how the program will work:

It will access the user's IP address. It will then go look whether a person has logged in with correct credentials in the last 10 day. If so it will automatically log you in. If this is not the case then it will route the user to a sign in or sign up page. 
The window will have the following default settings:
width: 800px; height: 400px; position: center of the screen; background: #eee; 
** Note: The program must check whether you are connected to the internet **

It will have the following pages with subsections included: 
---- Devoted
  |-- Dashboard                                                  [Unchecked]
    |---- Summary of all the pages combined                      [Unchecked]
    |---- Notifications                                          [Unchecked]
  |
  |-- Journal                                                    [Unchecked]
    |---- Cash Received Journal                                  [Unchecked]
    |---- Cash Paid Journal                                      [Unchecked]
    |---- General Ledger                                         [Unchecked]
  |
  |-- Asset Management                                           [Unchecked]
    |---- List of your stocks                                    [Unchecked]
    |---- Watchlist of stocks                                    [Unchecked]
  |
  |-- Budget                                                     [Unchecked]
    |---- Creating the budget                                    [Unchecked]
    |---- Reviewing budget with current progression              [Unchecked]
  |
  |-- Settings                                                   [Unchecked]
    |---- Dark mode / Light mode                                 [Unchecked]
    
The database will look as follows:
---- Devoted_Database
  |-- Members                                                    [Unchecked]
    |---- member_id (auto increment)
    |---- firstname (string)
    |---- lastname  (string)
    |---- email     (string) (unique)
    |---- username  (string) (unique)
    |---- password  (string) (encoded)
    |---- date_joined
    |---- is_admin  (small int) 
        {0: No Access; 1: Has Access; 2: Controlls theirs and other people; 3: Admin Access}
  |
  |-- Plans                                                      [Unchecked]
    |---- plan_id        (auto increment)
    |---- plan           (string)
    |---- date_created
    |---- created_by     (FOREIGN REFERENCE: Members)
  |
  |-- Categories                                                 [Unchecked]
    |---- category_id    (auto increment)
    |---- category       (string)
    |---- date_created
    |---- created_by     (FOREIGN REFERENCE: Members)
  |-- Journal                                                    [Unchecked]
    |---- journal_id (auto increment)
    |---- date
    |---- details      (string)
    |---- amount       (float)
    |---- diverse_details (string)
    |---- journal      (string) (?crj, ?cpj)
    |---- member_id    (FOREIGN REFERENCE: Members)
    |---- plan_id      (FOREIGN REFERENCE: Plans)
    |---- category_id  (FOREIGN REFERENCE: Categories)
  |
  |-- Login                                                      [Unchecked]
    |---- login_id    (auto increment)
    |---- ip          (string)
    |---- member_id   (FOREIGN REFERENCE: Members)
    |---- date_login  

Cyber Security: 
For the future the program will not have a direct link to the MySQL database. The program will send requests to the server and as the requests are sent to the server the server will decide whether the computer or rather logged in member has which type of admin access and thus which type of database retrieving access. 



