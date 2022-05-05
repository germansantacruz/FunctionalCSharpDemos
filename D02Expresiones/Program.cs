// See https://aka.ms/new-console-template for more information
using D02Expresiones;

Console.WriteLine("Hello, World!");

var instance1 = MyClassicSingleton.Instance;
var instance2 = MyClassicSingleton.Instance;
Console.WriteLine($" Same Object? {Object.ReferenceEquals(instance1, instance2)}");

var instance3 = MySingleton.Instance;
var instance4 = MySingleton.Instance;
Console.WriteLine($" Same Object? {Object.ReferenceEquals(instance3, instance4)}");

Console.WriteLine(instance4.ToString());

Console.ReadLine();
