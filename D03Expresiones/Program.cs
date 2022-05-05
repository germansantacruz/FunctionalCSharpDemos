using D03Expresiones;

Console.Write("Write a Country or city: ");
var country = Console.ReadLine();
country = country.Trim().Replace(' ', '+');

Console.Write(await Time3.Get(country));
Console.ReadLine();