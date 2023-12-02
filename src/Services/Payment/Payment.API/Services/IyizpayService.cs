using System.Diagnostics;
using Iyzipay.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Inveon.eCommerceExample.Payment.API.Services;

public class IyzipayService : IIyzipayService
{
    public Iyzipay.Model.Payment CreatePayment(CreatePaymentRequest request)
    {
        Iyzipay.Options options = new Iyzipay.Options();
        options.BaseUrl = "https://sandbox-api.iyzipay.com";
        options.ApiKey = "sandbox-EMR8QtA48qcWXRmi7GHNs8kqBH592MKM";
        options.SecretKey = "sandbox-xrSWHla7UWzFOYAC9npYkd8W0FpSV3uT";


        Iyzipay.Model.Payment payment =
            Iyzipay.Model.Payment.Create(request, options);

        return payment;

    }
}
