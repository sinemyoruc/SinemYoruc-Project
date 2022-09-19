using FluentValidation;
using SinemYoruc_Project.Data;

namespace SinemYoruc_Project
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.FirstName).Length(3, 20).WithMessage("Please enter valid value between 3 and 20 characters");
            RuleFor(x => x.LastName).Length(3, 20).WithMessage("Please enter valid value between 3 and 20 characters");
            RuleFor(x => x.Email).EmailAddress().NotNull().WithMessage("Please enter valid Email");
            RuleFor(x => x.Password).Length(8, 20).WithMessage("Password must be between 8 and 20 characters"); 
        }
    }
}
