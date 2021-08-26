Add migration for database
run from command line
~~~
dotnet ef migrations add InitialDbCreation
dotnet ef database update
dotnet ef database drop
~~~
dotnet aspnet-codegenerator controller -name StudentsController -actions -m Student -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name HomeworksController -actions -m Homework -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name GradesController -actions -m Grade -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name CesareVigeneresController -actions -m CesareVigenere -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name DiffieHellmansController -actions -m DiffieHellmanPoco -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f

dotnet aspnet-codegenerator controller -name RsaEncryptsController -actions -m RsaEncryptPoco -dc ApplicationDbContext -outDir Controllers --useDefaultLayout --useAsyncActions --referenceScriptLibraries -f