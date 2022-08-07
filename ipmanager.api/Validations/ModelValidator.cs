using FluentValidation;
using ipmanager.aplication.DTOs;
using System.Text.RegularExpressions;
using IpModel = System.String;

namespace ipmanager.api.Validations
{
    public class ModelValidator : AbstractValidator<IpModel>
    {
        public ModelValidator()
        {
            RuleFor(m => m).NotEmpty().Matches(new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"));
        }
    }
}
