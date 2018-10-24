using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IS_lab1.Models.Products
{
	public abstract class Product
	{
		[Key]
		[Required]
		public int Id;
		public int? ColorId { get; set; }
		[ForeignKey("ColorId")]
		public Color Color;
		public double? Cost;
		public int ManufacturerId { get; set; }
		[ForeignKey("ManufacturerId")]
		public Company Manufacturer { get; set; }

		[Required]
		public string Name;
	}
}