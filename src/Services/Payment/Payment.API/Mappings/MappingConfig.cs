using AutoMapper;

namespace Inveon.eCommerceExample.Payment.API.Mappings;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ReplaceMemberName("Cart", "Basket");
            cfg.ReplaceMemberName("Details", "Description");
            cfg.ReplaceMemberName("Category", "Category1");

            cfg.CreateMap<Models.PaymentCard, Iyzipay.Model.PaymentCard>();
            cfg.CreateMap<Models.Buyer, Iyzipay.Model.Buyer>();
            cfg.CreateMap<Models.Address, Iyzipay.Model.Address>();
            cfg.CreateMap<Models.Item, Iyzipay.Model.BasketItem>().ForMember(dest => dest.ItemType, opt => opt.MapFrom<UppercaseEnumResolver>());
            cfg.CreateMap<Models.PaymentDetails, Iyzipay.Request.CreatePaymentRequest>();
        });

        return config;
    }
}
