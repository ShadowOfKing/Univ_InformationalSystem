using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IS_lab1.Models.Translations
{
	public class ColorTranslation
	{
		[Key]
		[Required]
		public int Id { get; set; }
		[Required]
		public int ColorId { get; set; }
		[ForeignKey("ColorId")]
		public Color Color { get; set; }
		public string Eng { get; set; }
		public string Rus { get; set; }

		public enum Languages
		{
			Rus,
			Eng
		}
	}
}