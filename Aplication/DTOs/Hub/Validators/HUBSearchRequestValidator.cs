using Domain.Entities.Hub;
using FluentValidation;
using System.Globalization;

namespace Aplication.DTOs.Hub.Validators
{
    public class HUBSearchRequestValidator : AbstractValidator<HUBSearchRequest>
    {
        public HUBSearchRequestValidator() {

            RuleFor(x => x.hotelId)
                .NotEmpty().WithMessage("hotelId it cant be empty");

            RuleFor(x => x.checkIn)
                .NotEmpty().WithMessage("checkIn it cant be empty")
                .Must(BeAValidMinDate).WithMessage("The checkIn date must be greater than or equal to today.")
                .Must(BeAValidDate).WithMessage("The checkIn date format is not valid.");

            RuleFor(x => x.checkOut)
                .NotEmpty().WithMessage("checkOut it cant be empty")
                .Must(BeAValidMinDate).WithMessage("The checkOut date must be greater than or equal to today.")
                .Must(BeAValidDate).WithMessage("The checkOut date format is not valid.");

            RuleFor(x => x.numberOfGuests)
                .NotEmpty().WithMessage("numberOfGuests it cant be empty")
                .InclusiveBetween(1, 10).WithMessage("The field numberOfGuests must be between 1 and 10.");

            RuleFor(x => x.numberOfRooms)
                .NotEmpty().WithMessage("numberOfRooms it cant be empty")
                .InclusiveBetween(1, 10).WithMessage("The field numberOfRooms must be between 1 and 10.");

        }
        private bool BeAValidMinDate(DateTime? date)
        {
            return date.HasValue && date.Value >= DateTime.Now;
        }

        private bool BeAValidDate(DateTime? date)
        {
            return date.HasValue && DateTime.TryParse(date.Value.ToString(), out _);
        }
    }
}
