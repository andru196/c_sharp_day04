using System;
using System.Reflection;
using System.Linq;

void ReadAssemblyInfo(Type type)
{
    var ass = type.Assembly;   
    Console.WriteLine($"Type: {type.FullName}\n" +
    $"Assembly: {ass.FullName}\n"+
    $"Based on: {type.BaseType.Name}\n");
    Console.WriteLine("Fields:");
    foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
        Console.WriteLine($"{field.FieldType.FullName}.{field.Name}");
    Console.WriteLine("Properties:\n");
    foreach (var prop in type.GetProperties())
        Console.WriteLine($"{prop.PropertyType.FullName}.{prop.Name}");
    Console.WriteLine("Methods:\n");
    foreach (var meth in type.GetMethods())
        Console.WriteLine($"{meth.ReturnType.Name} {meth.Name}"+
        $"({string.Join(", ", meth.GetParameters().Select(x=>x.ParameterType.Name + " " + x.Name))})");    

}


ReadAssemblyInfo(typeof(Microsoft.AspNetCore.Http.DefaultHttpContext)); 