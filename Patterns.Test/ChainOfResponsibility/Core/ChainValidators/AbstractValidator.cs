namespace Patterns.Test.ChainOfResponsibility.Core.ChainValidators;


// The default chaining behavior can be implemented inside a base handler
// class.
abstract class AbstractValidator : IValidator
{
    private IValidator _nextValidator;

    public IValidator SetNext(IValidator validator)
    {
        this._nextValidator = validator;

        // Returning a handler from here will let us link handlers in a
        // convenient way like this:
        // monkey.SetNext(squirrel).SetNext(dog);
        return validator;
    }

    public virtual object Validate(string driverLicense)
    {
        if (this._nextValidator != null)
        {
            return this._nextValidator.Validate(driverLicense);
        }
        else
        {
            return null;
        }
    }
}