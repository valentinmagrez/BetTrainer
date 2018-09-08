
#DATABASE#

##On Visual Studio 2017##
 In order to connect to database through "Server explorer" you should select specify as ServerName: "127.0.0.1,1433", the port should be separate by a comma

### Make migration
EntityFrameworkCore\Add-Migration datamig_name

### Migrate 
EntityFrameworkCore\Update-Database