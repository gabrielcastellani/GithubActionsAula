using GithubActionsAula.Api.Services;

namespace GithubActionsAula.Tests
{
    public class ShippingServiceTests
    {
        [Theory]
        [InlineData(0.3, 12.50)]
        [InlineData(0.5, 12.50)]
        [InlineData(0.7, 20.00)]
        [InlineData(1.0, 20.00)]
        [InlineData(1.1, 48.00)]
        [InlineData(1.2, 49.50)]
        public void Must_calculate_shipping_costs_correctly(decimal weight, decimal expectedValue)
        {
            var service = new ShippingService();
            var value = service.Calculate(weight);

            Assert.Equal(expectedValue, value);
        }

        [Fact]
        public void It_should_throw_an_error_if_the_weight_is_zero()
        {
            var service = new ShippingService();
            Assert.Throws<ArgumentNullException>(() => service.Calculate(0));
        }
    }
}
