# Fullstack project using React and .Net Core API 

HOW TO RUN THE APPLICATION:
1. Make sure nodejs is installed on your machine.
2. Set starup project to SPA.
3. Restore database bak file on your database.
4. Run the app via Visual Studio.

*note: Takes a while to run as it installs all needed packages for React (node_modules).
       API accessible via swagger just put '/swagger' in the URL (http://localhost:59161/swagger).

Temporary workaroud for getting an existing record:
1. Take an Id from the PersonUnit table.
2. Add an id querystring on the URL with the id from the database.
   (e.g. http://localhost:59161/?id=77DE72D4-B343-4602-85F7-8144309D5B62)
   
Relevant projects:
1. ABC.Core
2. ABC.Infrastructure
3. ABC.Services
4. ABC.SPA 

*ignore other projects


3rd party libraries used: React Material, Axios, AutoMapper, Dapper, Swashbuckle (Swagger)
