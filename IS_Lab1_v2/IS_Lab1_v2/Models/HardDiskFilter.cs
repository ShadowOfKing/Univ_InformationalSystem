using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static IS_lab1_v2.Models.HardDisk;

namespace IS_lab1_v2.Models
{
	public class HardDiskFilter
	{
		public List<string> Colors { get; set; }
		public double? CostMin { get; set; }
		public double? CostMax { get; set; }
		public List<string> Manufacturers { get; set; }
		public double? AccessTimeMin { get; set; }
		public double? AccessTimeMax { get; set; }
		public bool? Autonomous { get; set; }
		public double? AutonomousTimeMin { get; set; }
		public double? AutonomousTimeMax { get; set; }
		public double? BufferSizeMin { get; set; }
		public double? BufferSizeMax { get; set; }
		public double? FlashSizeMin { get; set; }
		public double? FlashSizeMax { get; set; }
		public List<DiskFormFactor> FormFactors { get; set; }
		public bool? HasSCSI { get; set; }
		public bool? IsM2 { get; set; }
		public List<DiskPurpose> Purposes { get; set; }
		public double? ReadSpeedMin { get; set; }
		public double? ReadSpeedMax { get; set; }
		public double? RotationSpeedMin { get; set; }
		public double? RotationSpeedMax { get; set; }
		public List<SataFormat> Satas { get; set; }
		public double? SizeMin { get; set; }
		public double? SizeMax { get; set; }
		public List<DiskType> Types { get; set; }
		public List<UsbType> UsbTypes { get; set; }
		public double? WorkTimeMin { get; set; }
		public double? WorkTimeMax { get; set; }
		public double? WriteSpeedMin { get; set; }
		public double? WriteSpeedMax { get; set; }

		public int? Page { get; set; }
		public int? PageSize { get; set; }
	}
}