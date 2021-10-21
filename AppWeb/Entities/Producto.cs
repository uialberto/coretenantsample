using System.ComponentModel.DataAnnotations;

namespace AppWeb.Entities
{

    public class Producto 
    {
        [Key]
        public int ProductId { get; set; }
        public int TenantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }        
        public string Description { get; set; }
    }
}
