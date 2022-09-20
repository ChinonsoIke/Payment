using Newtonsoft.Json;

namespace Payment.Core.DTOs.VirtualAccountDtos
{
    public class VirtualAccountRequestDto
    {
        [JsonProperty("customer")]
        public string PaystackCustomerId { get; set; } = null!;
        public string WalletId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        [JsonProperty("preferred_bank")]
        public string PreferredBank { get; set; } = "test-bank";
    }
}
