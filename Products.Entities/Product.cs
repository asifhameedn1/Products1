using System.ComponentModel.DataAnnotations;

namespace Products.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] File { get; set; }
        public string ColorName { get; set; }
        public int Size { get; set; }
        public int Stock { get; set; }
    }
}