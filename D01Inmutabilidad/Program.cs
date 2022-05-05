// See https://aka.ms/new-console-template for more information
using D01Inmutabilidad;

Console.WriteLine("Inmutabilidad");
Console.WriteLine("*************************");

var testDates =
        new List<DateTime> {
            DateTime.Parse("2015-11-03"),
            DateTime.Parse("2015-11-01"),
            DateTime.Parse("2015-10-01"),
            DateTime.Parse("2015-12-01")
        };

var range = new DateRange(DateTime.Parse("2015-11-01"), DateTime.Parse("2015-11-06"));
testDates.ForEach(d => Console.WriteLine($"{d:yyyy-MM-dd} - {(range.DateIsInRange(d))}"));

Console.WriteLine();

var range2 = new DateRange(range.Start, DateTime.MaxValue);
testDates.ForEach(d => Console.WriteLine($"{d:yyyy-MM-dd} - {(range2.DateIsInRange(d))}"));

Console.WriteLine();

var range3 = range.Slide(7);
testDates.ForEach(d => Console.WriteLine($"{d:yyyy-MM-dd} - {(range3.DateIsInRange(d))}"));

Console.ReadLine();

//var range4 = new DateRange { Start = range.Start };
//range3.Start = range.Start;
