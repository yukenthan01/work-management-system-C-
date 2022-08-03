using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Software_Engeerning_2_Course_work.Models;
namespace Software_Engeerning_2_Course_work.validators
{
    class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Tittle).NotEmpty().WithMessage("Check the Tittle");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Check the Description");
            RuleFor(p => p.StartDate).Must(CheckDateValidDate).WithMessage("Check the StartDate");

            RuleFor(p => p.EndDate).NotEmpty().Must(CheckDateValidDate).WithMessage("Check the EndDate");
            RuleFor(p => p.Duration).NotEmpty().WithMessage("Check the Duration");
            RuleFor(p => p.Percentage).NotEmpty().WithMessage("Check the Percentage");
            RuleFor(p => p.Status).NotEmpty().WithMessage("Check the Status");


        }
        public ProjectValidator(string update)
        {
            RuleFor(p => p.Tittle).NotEmpty().WithMessage("Check the Tittle");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Check the Description");
            RuleFor(p => p.StartDate).NotEmpty().WithMessage("Check the StartDate");
            RuleFor(p => p.EndDate).NotEmpty().WithMessage("Check the EndDate");
            RuleFor(p => p.Duration).NotEmpty().WithMessage("Check the Duration");
            RuleFor(p => p.Percentage).NotEmpty().WithMessage("Check the Percentage");
            RuleFor(p => p.Status).NotEmpty().WithMessage("Check the Status");

        }
        private bool CheckDateValidDate(DateTime date)
        {
            bool valid = false;
            if ( date >= DateTime.Today)
            {
                valid = true;
            }
            return valid;
        }
    }
}
