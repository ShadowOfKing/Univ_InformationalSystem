using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static IS_lab1_v2.Models.HardDisk;

namespace IS_lab1_v2.Models
{
	public class HardDiskFilter
	{
		public List<HColor?> Colors { get; set; }
		[Display(Name ="Минимальная цена")]
		public double? CostMin { get; set; }
		[Display(Name = "Максимальная цена")]
		public double? CostMax { get; set; }
		public List<string> Manufacturers { get; set; }
		[Display(Name = "Минимальное время доступа")]
		public double? AccessTimeMin { get; set; }
		[Display(Name = "Максимальное время доступа")]
		public double? AccessTimeMax { get; set; }
		[Display(Name = "Автономный")]
		public bool? Autonomous { get; set; }
		[Display(Name = "Минмальное время автономной работы")]
		public double? AutonomousTimeMin { get; set; }
		[Display(Name = "Максимальное время автономной работы")]
		public double? AutonomousTimeMax { get; set; }
		[Display(Name = "Минимальный размер буфера")]
		public double? BufferSizeMin { get; set; }
		[Display(Name = "Максимальный размер буфера")]
		public double? BufferSizeMax { get; set; }
		[Display(Name = "Минмальная ёмкость флэш-памяти")]
		public double? FlashSizeMin { get; set; }
		[Display(Name = "Максимальная ёмкость флэш-памяти")]
		public double? FlashSizeMax { get; set; }
		[Display(Name = "")]
		public List<DiskFormFactor?> FormFactors { get; set; }
		[Display(Name = "Есть SCSI")]
		public bool? HasSCSI { get; set; }
		[Display(Name = "Тип M2")]
		public bool? IsM2 { get; set; }
		[Display(Name = "")]
		public List<DiskPurpose?> Purposes { get; set; }
		[Display(Name = "Минимальная скорость чтения")]
		public double? ReadSpeedMin { get; set; }
		[Display(Name = "Максимальная скорость чтения")]
		public double? ReadSpeedMax { get; set; }
		[Display(Name = "Минмальная скорость вращения")]
		public double? RotationSpeedMin { get; set; }
		[Display(Name = "Максимальная скорось вращения")]
		public double? RotationSpeedMax { get; set; }
		[Display(Name = "")]
		public List<SataFormat?> Satas { get; set; }
		[Display(Name = "Минимальная ёмкость")]
		public double? SizeMin { get; set; }
		[Display(Name = "Максимальная ёмкость")]
		public double? SizeMax { get; set; }
		[Display(Name = "")]
		public List<DiskType?> Types { get; set; }
		[Display(Name = "")]
		public List<UsbType?> UsbTypes { get; set; }
		[Display(Name = "Минимальное время наработки на отказ")]
		public double? WorkTimeMin { get; set; }
		[Display(Name = "Максимальное время наработки на отказ")]
		public double? WorkTimeMax { get; set; }
		[Display(Name = "Минимальная скорость записи")]
		public double? WriteSpeedMin { get; set; }
		[Display(Name = "Максимальная скорость записи")]
		public double? WriteSpeedMax { get; set; }

		public int? Page { get; set; }
		public int? PageSize { get; set; }
	}
}