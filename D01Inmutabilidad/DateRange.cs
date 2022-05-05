namespace D01Inmutabilidad;

internal class DateRange
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public DateRange(DateTime start, DateTime end)
    {
        if (start.CompareTo(end) >= 0)
            throw new ArgumentException("La fecha final debe ser mayor a la fecha inicial");

        Start = start;
        End = end;
    }

    public bool DateIsInRange(DateTime checkDate)
    {
        return Start.CompareTo(checkDate) <= 0 && End.CompareTo(checkDate) >= 0;
    }

    public DateRange Slide(int days)
    {
        return new DateRange(Start.AddDays(days), End.AddDays(days));
    }
}
