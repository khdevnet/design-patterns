namespace Patterns.Test.ChainOfResponsibility.Core.ChainValidators;

// The Handler interface declares a method for building the chain of
// handlers. It also declares a method for executing a request.
public interface IValidator
{
    IValidator SetNext(IValidator validator);

    object Validate(string driverLicense);
}