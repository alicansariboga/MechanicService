using System.ComponentModel.DataAnnotations;

namespace MechanicService.Domain.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
