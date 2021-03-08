namespace Tidwit.Libraries.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
