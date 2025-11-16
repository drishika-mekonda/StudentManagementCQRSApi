using FluentValidation;

namespace StudentManagementCQRSApi.Application.CreateStudent
{
    public class CreateStudentValidator:AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentValidator()
        {
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
