# GameApi

���M�׶ȴ��Ѵ���


## �w�ˮM��
```shell=
Install-Package Microsoft.EntityFrameworkCore -Version 5.0.17
Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.17	
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 5.0.4
```

## �ϥΤ覡
### �w�˸�Ʈw
### �ק�s�u�r��
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
�W�z�ɮ� ��31��
### ��s��Ʈw
```shell=
dotnet ef database update 
```
### �ҰʱM��
### �ϥ�POSTMAN ����

