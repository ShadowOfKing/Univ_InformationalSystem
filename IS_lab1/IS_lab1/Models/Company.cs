using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IS_lab1.Models
{
	public class Company
	{
		[Key]
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public bool ProduceHardDisks { get; set; }
	}
}