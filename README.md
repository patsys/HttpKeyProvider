This Keepass Plugin use a POST call to get the Master Key for the Database from a webserver.

This is a good Interface to write our own KeyProvider. My Idea was to use a smart card with a local python Flask webserver to Unlock the Datebase.

A other usecase is to block the access to the Database when User Date are Currupt or the User leave the Company. In this case it is more Secure to change all Passwords and use a central config management.

The implementation had this ToDo list
+Get Masterkey from Webserver
-Config Server Ip and Port, Static Parameter
-Transfer App Parameter( Databasename, ...) to server
-Load HTML formular to get Parameter( Username, Passwort, ...), don't work because WebBrowser problens i
n Win,Linux
-Manage more Server by select one or use Database name

