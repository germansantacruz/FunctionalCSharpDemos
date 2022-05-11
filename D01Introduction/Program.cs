using D01Introduction;
using D01Introduction.FPCSharp;

Console.WriteLine("\nProgramación imperativa vs funcional:");
Console.WriteLine("------------------------------------\n");
Console.WriteLine(Ex01_ImperativaVsFunc.GetMarriedPeople());
Console.WriteLine(Ex01_ImperativaVsFunc.GetMarriedPeople2());

// Inmutabilidad
Console.WriteLine("\nEvitar mutación de estado:");
Console.WriteLine("------------------------------------\n");
var data = Ex02_Immutability.GetData();
Console.WriteLine(data.ToStringCustom());
Console.WriteLine(Ex02_Immutability.EvitarMutacionDeEstado(data)
    .ToStringCustom());
Console.WriteLine(data.ToStringCustom());

// Concurrencia
Console.WriteLine("\nEvitar mutación de estado en procesos concurrentes:");
Console.WriteLine("-----------------------------------------------------\n");
Ex03_Concurrency.MutarEstadoOcasionaProblemas();
Ex03_Concurrency.SinMutarEstado();

// C Sharp Funcional
Console.Write("******************************************************************\n");
Console.WriteLine("¿Cuán funcional es C Sharp?");
Console.Write("******************************************************************\n");

F01_LINQ.Example();
F02_ExpressionBodiedMembers.Example();
F03_FunctionsWithinFunctions.Example();
F04_Tuples.Example();

/*
Ex04_FunctionalCSharp.Circle c1 = new Ex04_FunctionalCSharp.Circle(10.2);
Console.WriteLine(c1.Circumference);

// *********************************
// Init only setters
// *********************************
Console.WriteLine("\nPrueba de Init only setters:");
Ex04_FunctionalCSharp.PruebaInitOnlySetters c2 = new();
Console.WriteLine($"Valor de Id: {c2.Id}");
//c2.Id = 10;
Ex04_FunctionalCSharp.PruebaInitOnlySetters c3 = new(3);
Console.WriteLine($"Valor de Id: {c3.Id}");
Ex04_FunctionalCSharp.PruebaInitOnlySetters c4 = new() { Id = 10 };
Console.WriteLine($"Valor de Id: {c4.Id}");
*/

Console.ReadLine();

