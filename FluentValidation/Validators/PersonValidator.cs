using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidation.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(c => c.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)                // Follow step by step
                .NotEmpty().WithMessage("{PropertyName} Sould not be Empty")
                .Length(3, 50).WithMessage("Please provide a valid {PropertyName}")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(c => c.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)                // Follow step by step
                .NotEmpty().WithMessage("{PropertyName} Sould not be Empty")
                .Length(3, 50).WithMessage("Please provide a valid {PropertyName}")
                .Must(BeAValidName).WithMessage("{PropertyName} contains invalid characters");

            RuleFor(c => c.DateOfBirth)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} Sould not be Empty")
                .Must(BeAValidDateOfBirth).WithMessage("{PropertyName} not a valid Date");

        }

        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }

        protected bool BeAValidDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth.Year > DateTime.Now.Year)
            {
                return false;
            }
            return true;
        }
    }
}
