Option 1
1. Run docker-compose up csharp
2. check launch.json file and config it
3. Run debuger with current project

options 2
1. winpty docker run -it --name acb-app -v /D:/git/acb-app:/home -p 4141:4141 170a
2. Set launch.json
	  {
			"name": ".NET Core Attach",
			"type": "coreclr",
			"request": "attach",
			"processId": "${command:pickProcess}"
		},      
3. Debug is nomarly
Can web use extionsion for vsCode C#... too

We have to install Remote Development in vscode first (very important)!!!

dotnet ef migration export
export PATH="$PATH:$HOME/.dotnet/tools/"

1. dotnet ef migrations add InitialIdentity --context AuthDbContext
2. dotnet ef database update -context AuthDbContext

create class with scaffod 
=> dotnet ef dbcontext scaffold "Server=172.17.0.4;Database=ACB-System;user=root;pwd=123;" "Pomelo.EntityFrameworkCore.MySql" -o Models -f