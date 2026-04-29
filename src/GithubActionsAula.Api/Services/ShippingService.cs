namespace GithubActionsAula.Api.Services
{
    public sealed class ShippingService : IShippingService
    {
        public decimal Calculate(decimal weight)
        {
            if (weight <= 0)
                throw new ArgumentNullException("The weight must be greater than zero.");

            if (weight <= 0.5m)
                return 12.50m;

            if (weight <= 1.0m)
                return 20.00m;

            return 46.50m + Math.Ceiling((weight - 1.0m) / 0.1m) * 1.50m;
        }
    }
}
