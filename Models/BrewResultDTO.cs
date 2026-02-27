using CoffeeShop.Application.BrewCoffee;

namespace CoffeeShop.Api.Models
{
    public class BrewResultDTO
    {
        public string Message { get; set; } = null!;
        public string Prepared { get; set; } = null!;

        public BrewResultDTO()
        {
                
        }
        public BrewResultDTO(BrewCoffeeResponse result)
        {
            Message = result.Message;
            Prepared = result.Prepared;
        }

    }
}
