### Required for app to work
Installed [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-5.0.408-windows-x64-installer)  
Installed [ASP.NET Core 5.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-aspnetcore-5.0.17-windows-x64-installer)

### How to download and run the app
Write these 3 commands in a directory convenient for you:
```
git clone https://github.com/kotenko2002/Back-end-labs--Heroku-deploy.git
cd Back-end-labs--Heroku-deploy\Lab 1
dotnet run
```

### Endpoints
Video review on the API: https://youtu.be/6q__RZ7W3eU

You can use 2 domains:
* local: `https://localhost:5001`
* deployed: `https://lab1-dotnet.herokuapp.com`
<br/>
     
* UserController
    * Add new user: `{domain}/api/user`
* CategoryController
    * Add new category: `{domain}/api/category`
    * Get list of all categories: `{domain}/api/category/items`
* RecordController
    * Add new record: `{domain}/api/record`
    * Get list of records by userId: `{domain}/api/record/items/{id}`
    * Get list of records by userId and categoryId: `{domain}/api/record/items/?userId={userId}&categoryId={categoryId}`

Example of GET request (you can try typing it in your browser right now):
`https://lab1-dotnet.herokuapp.com/api/category/items`
