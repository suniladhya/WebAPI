# WebAPI

![Project DB](https://i.ibb.co/9hH64jb/Data.jpg)

![path](D:\XVIIL\Tech\Projects\WebAPI\CountingKs\counting-ks-master)

steps:
Microsoft ASP.Net WEBAPI
Comment out 
//config.EnableQuerySupport();// For OData


var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
    jsonFormatter.SerializerSettings.ContractResolver = new *CamelCase*PropertyNamesContractResolver();
  
 Dependency Injection thorugh IOC, in Web API is not Allowed. To make it work use Ninject.MVC3
 public FoodsController(ICountingKsRepository repo)
 
 Changes for Ninject.MVC3 Nuget package:
 1. A class NinjectWebcommon.cs is added in the app.start
 2. Register the Class for Inter faces
            kernel.Bind<ICountingKsRepository>().To<CountingKsRepository>();
            kernel.Bind<CountingKsContext>().To<CountingKsContext>();

            kernel.Bind<ICountingKsIdentityService>().To<CountingKsIdentityService>()
 3. Support Inject in Web API, Install-Package WebApiContrib.IoC.Ninject -Version 0.9.3
      GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

 Note: NinjectWebcommon is a start up bootstrap. when the web server get started, it do its own registration.
 
 ## Model vs Entities
 1. creation of Model Factory
 ### Circular reference for Seriallization NOT ALLOWED
 Food has Measure,  So Food's reference is in Measure class. Resulting in Circular reference.
 
 ### Routing vs. parameter
 
 
 
  
