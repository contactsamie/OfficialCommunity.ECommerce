using System.Runtime.Serialization;

namespace OfficialCommunity.ECommerce.Nuvango.Domains.Business
{
    public enum ShippingState
    {
        [EnumMember(Value = "ready")]
        Ready,
        [EnumMember(Value = "in_progress")]
        InProgress,
        [EnumMember(Value = "fulfilled")]
        Fulfilled
    }
}