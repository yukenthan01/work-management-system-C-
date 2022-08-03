using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software_Engeerning_2_Course_work.Models;

namespace Software_Engeerning_2_Course_work.validators
{
    class UserValidator : AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(u => u.Tittle).NotEmpty().WithMessage("Select the Tittle");
            RuleFor(u => u.Firstname).NotEmpty().Matches("[a-zA-z]+").WithMessage("Check the Firstname");
            RuleFor(u => u.Lastname).NotEmpty().Matches("[a-zA-z]+").WithMessage("Check the Lastname");
            RuleFor(u => u.Phoneno).NotEmpty().WithMessage("Check the Phone Number");
            RuleFor(u => u.Email).NotEmpty().EmailAddress().WithMessage("Check the Email");
            RuleFor(u => u.Status).NotEmpty().WithMessage("Select the Status");
            //RuleFor(u => u.Password).NotEmpty().MinimumLength(4).WithMessage("Check the Password");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Check the Password");
            RuleFor(u => u.UserRole).NotEmpty().WithMessage("Select the User Role");
        }
    }
}
