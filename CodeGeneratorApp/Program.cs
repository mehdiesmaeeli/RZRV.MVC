using CodeGeneratorApp;
using RZRV.APP.Models;

// Set the base path to your project root
string basePath = @"D:\Project\RZRV.MVC.SRC\RZRV.APP\RZRV.APP";

// Create an instance of the CodeGenerator
var generator = new CodeGenerator(basePath);

// Generate code for each of your model classes
generator.GenerateCode(typeof(Customer));
generator.GenerateCode(typeof(Order));
generator.GenerateCode(typeof(Product));
generator.GenerateCode(typeof(Reservation));
generator.GenerateCode(typeof(Service));
generator.GenerateCode(typeof(ServiceProvider));
generator.GenerateCode(typeof(Store));

// Add more models as needed

Console.WriteLine("Code generation completed.");