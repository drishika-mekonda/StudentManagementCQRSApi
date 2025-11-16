using FluentValidation;

namespace StudentManagementCQRSApi.Application.UpdateStudent
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Student name is required!")
                 .MinimumLength(5).WithMessage("Student name must be atleast 5 characters long.");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(16).WithMessage("Student age must be greater than or equal to 16.");

            RuleFor(x => x.Branch)
                .NotEmpty().WithMessage("Student Branch is required.");
        }
    }
}
