using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Software_Engeerning_2_Course_work.Models;

namespace Software_Engeerning_2_Course_work.validators
{
    class TaskValidator : AbstractValidator<Tasks>
    {
        public TaskValidator()
        {
            RuleFor(p => p.ProjectId).NotEmpty().WithMessage("Check the Project ID");
            RuleFor(p => p.Tittle).NotEmpty().WithMessage("Check the Tittle");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Check the Description");
            RuleFor(p => p.StartDate).Must(CheckDateValidDate).NotEmpty().WithMessage("Check the StartDate");
            RuleFor(p => p.EndDate).Must(CheckDateValidDate).NotEmpty().WithMessage("Check the EndDate");
            RuleFor(p => p.Duration).NotEmpty().WithMessage("Check the Duration");
            RuleFor(p => p.Percentage).NotEmpty().WithMessage("Check the Percentage");
            RuleFor(p => p.Status).NotEmpty().WithMessage("Check the Status");
        }
        public TaskValidator(string update)
        {
            RuleFor(p => p.ProjectId).NotEmpty().WithMessage("Check the Project ID");
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
            if (date >= DateTime.Today)
            {
                valid = true;
            }
            return valid;
        }
    }
}
