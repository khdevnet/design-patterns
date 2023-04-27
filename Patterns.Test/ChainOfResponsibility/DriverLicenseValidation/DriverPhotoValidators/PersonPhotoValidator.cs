using Patterns.Test.ChainOfResponsibility.Core.ChainValidators;
using Patterns.Test.ChainOfResponsibility.ValidatorExample;

namespace Patterns.Test.ChainOfResponsibility.DriverLicenseValidation.DriverPhotoValidators;

class PersonPhotoValidator : AbstractValidator
{
    public override object Validate(string request)
    {
        if ((request as string) == "Banana")
        {
            return $"Monkey: I'll eat the {request.ToString()}.\n";
        }
        else
        {
            return base.Validate(request);
        }
    }
}
