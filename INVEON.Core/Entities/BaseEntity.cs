using System.ComponentModel.DataAnnotations;

namespace INVEON.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
