using FluentValidation.Results;
using FluentValidation.Validators;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidation
{
    /// <summary>
    /// Added to Git for quick reference
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                ID = 0,
                DateOfBirth = new DateTime(2099, 1, 1),
                FirstName = "",
                LastName = "Doo",
                Salary = 987
            };

            // Validate via Fluent Validator
            PersonValidator validator = new PersonValidator();
            ValidationResult validationResults = validator.Validate(person);

            if (!validationResults.IsValid)
            {
                foreach (var item in validationResults.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }

            // Insert into DB

            Console.ReadKey();
        }
    }
}
