# GameApi

本專案僅提供測試


## 安裝套件
```shell=
Install-Package Microsoft.EntityFrameworkCore -Version 5.0.17
Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.17	
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 5.0.4
```

## 使用方式
### 安裝資料庫
### 修改連線字串
filename:Startup.cs
```csharp= 25
   public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MyContext>(options =>
            {
                var connetionString = "Server=localhost; Port=3306;User Id=gamer;Password=123456;Database=gamer;persistsecurityinfo=True";

                options.UseMySql(connetionString, new MariaDbServerVersion(new Version(10, 7)));
            });
        }
```
上述檔案 第31行
### 更新資料庫
```shell=
dotnet ef database update 
```
### 啟動專案
### 使用POSTMAN 測試

