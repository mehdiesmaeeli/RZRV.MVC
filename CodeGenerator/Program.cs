using System;
using System.IO;
using RZRV.APP.Models; // Make sure to reference your models namespace

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the base path to your project root
            string basePath = @"D:\Project\RZRV.MVC.SRC\RZRV.APP\RZRV.APP";

            // Create an instance of the CodeGenerator
            var generator = new CodeGenerator(basePath);

            // Generate code for each of your model classes
            generator.GenerateCode(typeof(YourModel1));
            generator.GenerateCode(typeof(YourModel2));
            // Add more models as needed

            Console.WriteLine("Code generation completed.");
        }
    }
}