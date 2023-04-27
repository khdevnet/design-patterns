using Patterns.Test.ChainOfResponsibility.Core.ChainValidators;

namespace Patterns.Test.ChainOfResponsibility.ValidatorExample.DriverLicenseValidation;

class DriverPhotoValidator : AbstractValidator
{
    private readonly IEnumerable<IValidator> _validators;

    public DriverPhotoValidator(IEnumerable<IValidator> validators = null)
    {
        _validators = validators ?? Enumerable.Empty<IValidator>();
    }

    public override object Validate(string driverLicense)
    {
        _validators.ToList().ForEach(v => v.Validate(driverLicense));
        return base.Validate(driverLicense);
    }
}

class DoesntHideEyesPersonValidator : AbstractValidator
{
    public override object Validate(string request)
    {
        if (request.ToString() == "Nut")
        {
            return $"Squirrel: I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Validate(request);
        }
    }
}

class DoesntHasHatPersonValidator : AbstractValidator
{
    public override object Validate(string request)
    {
        if (request.ToString() == "MeatBall")
        {
            return $"Dog: I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Validate(request);
        }
    }
}