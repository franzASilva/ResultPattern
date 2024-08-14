using ResultPattern.Domain.Model;

namespace ResultPattern.Domain.Services.Interfaces;

public interface IDummyService
{
    Result GetDummiesValues();
    Result SaveDummy(DummyModel dummy);
}
