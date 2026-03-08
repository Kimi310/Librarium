To run this application you need to run:
1. docker compose up -d 
2. dotnet run

The migrations were made using flyway so to be able to migrate the files you should
download flyway to your machine. After the installation is completed flyway migrate runs
all migrations that has still not been setup for the database.