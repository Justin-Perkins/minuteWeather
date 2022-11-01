start cmd /k mysql.exe -u root -p%MySql% -e "source %~dp0/minuteWeather Database/InitializeDatabase.sql"

start cmd /k "cd "minuteWeather FrontEnd" && ng serve"

start cmd /k "cd "minuteWeather BackEnd"/"ASP.NET Web API" && dotnet run"
