namespace ECommerce.Api.Orders.Profiles
{
    public class OrderItemProfile : AutoMapper.Profile
    {
        public OrderItemProfile()
        {
            CreateMap<Database.OrderItem, Models.OrderItem>();
        }
    }
}
