using Patterns.Test.ChainOfResponsibility.Core.ChainValidators;

namespace Patterns.Test.ChainOfResponsibility.ValidatorExample;

class DriveLicenseValidator : AbstractValidator
{
    public override object Validate(string request)
    {
        return base.Validate(request);
    }
}