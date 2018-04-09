This Keepass Plugin use a POST call to get the Master Key for the Database from a webserver.

This is a good Interface to write our own KeyProvider. My Idea was to use a smart card with a local python Flask webserver to Unlock the Datebase.

A other usecase is to block the access to the Database when User Date are Currupt or the User leave the Company. In this case it is more Secure to change all Passwords and use a central config management.

* The implementation had this ToDo list  
**+** Get Masterkey from Webserver  
**-** Config Server Ip and Port, Static Parameter  
**-** Transfer App Parameter( Databasename, ...) to server  
**-** Load HTML formular to get Parameter( Username, Passwort, ...), **don't work** because WebBrowser problens in Win,Linux  
**-** Manage more Server by select one or use Database name  

The webserver Return a Json
{
"key": // the master key for Datebase, do try while null  
"policy": otionale set the AppPolicy(KeePass.App.AppPolicyFlags) as json  
"parameter": parameter must be sent to Server use Variablen. **!!! not implement**  
"returnUrl": url to send Parameter. **!!! not ipmlement**  
"html": htm formular display, should work offlin an will be use in offline tool that make the same. **!!! not implement, crash** 
"formUrl", send Request to get html, like html. **!!! not implement**  
}
