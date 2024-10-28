using DeliveryService.Models;
using FluentValidation;

namespace DeliveryService.Service
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.Weight)
                .GreaterThan(0)
                .LessThanOrEqualTo(1000)
                .WithMessage("Weight must be between 0.1 and 1000 kg");

            RuleFor(o => o.District)
                .NotEmpty()
                .WithMessage("District is required");

            RuleFor(o => o.DeliveryTime)
                .NotEmpty()
                .WithMessage("Delivery Time is required")
                .Must(BeAValidDateTime)
                .WithMessage("Delivery Time must be a valid date and time");
        }

        private bool BeAValidDateTime(DateTime dateTime)
        {
            return dateTime >= DateTime.MinValue && dateTime <= DateTime.MaxValue;
        }
    }
}
