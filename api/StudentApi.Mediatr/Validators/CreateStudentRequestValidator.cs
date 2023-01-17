using FluentValidation;
using StudentApi.Mediatr.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApi.Mediatr.Validators
{
    public class CreateStudentRequestValidator: AbstractValidator<CreateStudentRequest>
    {
        public CreateStudentRequestValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Major).NotEmpty();
            RuleFor(p => p.AverageGrade).NotNull();
        }
    }
}
