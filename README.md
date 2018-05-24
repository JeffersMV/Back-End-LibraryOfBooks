# Back-End-LibraryOfBooks

## Back-End | ASP.NET | Library Of Books App

### To start the project automatically, you need a MySQL server, when the program starts, the `lobdb` database will automatically be created, the tables will fill it in by default, and the server will be fully started.


### If you do not have a `MySQL server`, then the settings for connecting another server in the `Startup.ss` file

     30|       services.AddDbContext<AppDatabaseContext>(options =>
     31|           options.UseMySQL("server=localhost;port=3306;UserId=root;Password=;database=lobdb;SslMode=none"));
 
 ### CORS define a set of rules for the interaction between the server and the client.
     24|       services.AddCors(options =>
     25|          {
     26|             options.AddPolicy("CorsPolicy",
     27|                 builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod()
     28|                     .AllowAnyHeader().AllowCredentials());
     29|       });
 
 ### Folder Structure
 
 ![Image alt](https://github.com/JeffersMV/Back-End-LibraryOfBooks/raw/master/FolderStructureLibraryOfBookServer.png)
 
