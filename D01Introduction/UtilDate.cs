namespace D01Introduction;
/*
public class UtilDate
{
    // Función no pura (no devuelve siempre el mismo resultado) y no tiene efectos secundarios
    public static int Days(DateTime from) => (DateTime.Now - from).Days;

    // Función no pura
    private static string cadena = "Hola";
    public static string Concat(string msg) => cadena += msg;

    // Funcion no pura (StringBuilder se pasa por referencia)
    public static void Concat(StringBuilder sb, string msg)
        => sb.Append(msg);

    // Funciones puras
    public static int Days(DateTime from, DateTime now) => (now - from).Days;

    public static string Concat(string msg1, string msg2) => msg1 + msg2;

    public static IEnumerable<T> Where2<T>(this IEnumerable<T> lista,
        Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var item in lista)
        {
            if (predicate(item))
                result.Add(item);
        }

        return result;
    }

    // Funciones como valores de primera clase
    public static IEnumerable<int> TripicarDatos()
    {
        var triple = (int numero) => numero * 3;
        var datos = Enumerable.Range(1, 10);

        return datos.Select(triple);
    }
}
*/