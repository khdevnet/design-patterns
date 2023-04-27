using Patterns.Test.ChainOfResponsibility.Core.ChainValidators;
using Patterns.Test.ChainOfResponsibility.DriverLicenseValidation.DriverPhotoValidators;
using Patterns.Test.ChainOfResponsibility.ValidatorExample.DriverInformationValidators;
using Patterns.Test.ChainOfResponsibility.ValidatorExample.DriverLicenseValidation;

namespace Patterns.Test.ChainOfResponsibility.ValidatorExample;

using System;
using System.Collections.Generic;

// Drive license validator
// DriverPhotoValidator
// -- BackgroundPhotoValidator
// -- PersonPhotoValidator
// --- DoesntHideEyesPersonValidator
// --- DoesntHasHatPersonValidator
// DriverInformationValidator
// -- HaveAgeMoreThen16YearsValidator
// -- FullNameSpecifiedValidator
// -- AddressValidator
// --- HasCountryAddressValidator
// --- HasCityAddressValidator
// --- HasAddressNumberAddressValidator

class Client
{
    // The client code is usually suited to work with a single handler. In
    // most cases, it is not even aware that the handler is part of a chain.
    public static void ClientCode(IValidator handler, IEnumerable<string> driverLicenseElements)
    {
        foreach (var food in driverLicenseElements)
        {
            Console.WriteLine($"Client: Who wants a {food}?");

            var result = handler.Validate(food);

            if (result != null)
            {
                Console.Write($"   {result}");
            }
            else
            {
                Console.WriteLine($"   {food} was left untouched.");
            }
        }
    }
}

public class ChainOfResponsibilityExamplesRunner
{
    [Fact]
    public void Base()
    {
        var driverLicenceValidator = new DriveLicenseValidator()
            .SetNext(new DriverPhotoValidator()
                .SetNext(new PersonPhotoValidator()
                    .SetNext(new DoesntHideEyesPersonValidator())
                    .SetNext(new DoesntHasHatPersonValidator())))
            .SetNext(new DriverInformationValidator());


        // The client should be able to send a request to any handler, not
        // just the first one in the chain.
        Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
        Client.ClientCode(
            driverLicenceValidator,
            new List<string> { "Nut", "Banana", "Cup of coffee" });
        Console.WriteLine();
    }
}