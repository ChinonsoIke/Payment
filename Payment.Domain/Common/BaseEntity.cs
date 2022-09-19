using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment.Domain.Common
{
    public abstract class BaseEntity
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        [Required]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
