# webapi_template
A dotnet core 5 webapi template.

# done
1. CRUD
2. Logging
3. Swagger
4. Authentication: https://www.c-sharpcorner.com/article/authentication-and-authorization-in-asp-net-core-web-api-with-json-web-tokens/
	1) In MSSQL Server Management Studio
	'''
	-- Create database:
	CREATE DATABASE [WebApiTemplate1]
	GO
	'''
	2) In Package Management Console
	'''
	update-database
	'''
5. Authorization 
9. Docker support
	```
	# docker build -t webapitemplate --progress plain --no-cache .
	# docker run -d -p 8080:80--name mywebapi webapitemplate 
	# docker image url: https://hub.docker.com/r/yuxuac/webapitemplate/tags
	```

# todo
6. Background task 
7. Queue subscription
8. DB access
