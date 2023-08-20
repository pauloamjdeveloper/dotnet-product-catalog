using ProductCatalog.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProductCatalog.Application.DTOs
{
    public class ProductDTO
    {
        [Range(0, int.MaxValue, ErrorMessage = "Invalid Id value")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Stock is Required")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Stock { get; set; }

        [MaxLength(250)]
        [DisplayName("Imagem")]
        public string Image { get; set; }

        [DisplayName("Categoria")]
        public Category Category { get; set; }

        [DisplayName("Categoria Id")]
        public int CategoryId { get; set; }

        [DisplayName("Nome da Categoria")]
        public string CategoryName { get; set; }
    }
}
