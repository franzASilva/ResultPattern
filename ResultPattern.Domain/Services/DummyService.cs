using ResultPattern.Domain.Model;
using ResultPattern.Domain.Services.Interfaces;

namespace ResultPattern.Domain.Services;

public class DummyService : IDummyService
{
    public Result GetDummiesValues()
    {
        var dummies = Enumerable
        .Range(1, 5)
        .Select(index =>
        new Dummy
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            Random.Shared.Next(1, 100)
        ))
        .ToList();

        if (dummies.Count > 0)
        {
            return new Result(dummies);
        }

        // Use this
        return new Result("Dummies not found!");

        // instead
        // throw new Exception("Dummies not found!");
        // to control business flow
    }

    public Result SaveDummy(DummyModel dummy)
    {
        return new Result("Couldn't save Dummy!");
    }
}
