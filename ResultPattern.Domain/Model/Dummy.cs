namespace ResultPattern.Domain.Model;

public sealed record Dummy(DateOnly Date, int Value, int Id = 0)
{
    public int ValueOffset => 32 + (int)(Value / 0.5556);
}