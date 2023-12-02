using AutoMapper;
using Inveon.eCommerceExample.Payment.API.Models;
using Iyzipay.Model;

namespace Inveon.eCommerceExample.Payment.API.Mappings;

public class UppercaseEnumResolver : IValueResolver<Models.Item, Iyzipay.Model.BasketItem, string>
{
    public string Resolve(Item source, BasketItem destination, string destMember, ResolutionContext context)
    {
        return source.ItemType.ToString().ToUpperInvariant();
    }
}
