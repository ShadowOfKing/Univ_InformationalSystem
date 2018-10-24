using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace IS_lab1_v2.Models
{
	public class HardDisk
	{
		[Key]
		public int Id { get; set; }
		public string Color { get; set; }
		public double? Cost { get; set; }
		public string Manufacturer { get; set; }

		public string Name { get; set; }
		public string Image { get; set; }

		public double? AccessTime { get; set; }
		public bool? Autonomous { get; set; }
		public double? AutonomousTime { get; set; }
		public double? BufferSize { get; set; }
		public double? FlashSize { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public DiskFormFactor? FormFactor { get; set; }
		public bool? HasSCSI { get; set; }
		public bool? IsM2 { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public DiskPurpose? Purpose { get; set; }
		public double? ReadSpeed { get; set; }
		public double? RotationSpeed { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public SataFormat? Sata { get; set; }
		public double? Size { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public DiskType? Type { get; set; }
		[JsonConverter(typeof(StringEnumConverter))]
		public UsbType? Usb { get; set; }
		public double? WorkTime { get; set; }
		public double? WriteSpeed { get; set; }

		public enum DiskType
		{
			HDD,
			SSD,
			Hybrid
		}
		public enum DiskPurpose
		{
			Outer = 0,
			Computer,
			Notebook,
			CompNote,
			Server
		}
		public enum DiskFormFactor
		{
			I18,
			I25,
			I35,
			M2242,
			M2260,
			M2280
		}
		public enum SataFormat
		{
			S15,
			S30,
			S60
		}
		public enum UsbType
		{
			U20,
			U30,
			U31,
			U31TC
		}
	}
}