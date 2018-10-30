using IS_lab1_v2.Models;
using IS_Lab1_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IS_Lab1_v2.Controllers
{
	public class HomeController : Controller
	{
		private DefaultContext _db = new DefaultContext();

		public ActionResult Index()
		{
			var disks = _db.HardDisks.ToList();
			var filter = new HardDiskFilter();
			return View(new List<object>
			{
				disks,
				filter
			});
		}

		[HttpPost]
		public ActionResult Index([Bind(Include = "CostMin,CostMax,AccessTimeMin,AccessTimeMax,Autonomous,AutonomousTimeMin,AutonomousTimeMax,BufferSizeMin,BufferSizeMax,FlashSizeMin,FlashSizeMax,HasSCSI,IsM2,ReadSpeedMin,ReadSpeedMax,RotationSpeedMin,RotationSpeedMax,SizeMin,SizeMax,WorkTimeMin,WorkTimeMax,WriteSpeedMin,WriteSpeedMax,Page,PageSize")] HardDiskFilter hardDiskFilter)
		{
			var disks = _db.HardDisks.Where(h =>
				(
					!hardDiskFilter.AccessTimeMin.HasValue
					|| h.AccessTime.HasValue == false 
					|| hardDiskFilter.AccessTimeMin.Value <= h.AccessTime.Value
				)
				&& (
					!hardDiskFilter.AccessTimeMax.HasValue 
					|| h.AccessTime.HasValue == false 
					|| hardDiskFilter.AccessTimeMax.Value <= h.AccessTime.Value
				)
				&& (
					!hardDiskFilter.Autonomous.HasValue 
					|| h.Autonomous.HasValue == false 
					|| hardDiskFilter.Autonomous.Value == h.Autonomous.Value
				)
				&& (
					!hardDiskFilter.AutonomousTimeMax.HasValue 
					|| h.Autonomous.HasValue == false 
					|| hardDiskFilter.AutonomousTimeMax.Value >= h.AutonomousTime.Value
				)
				&& (
					!hardDiskFilter.AutonomousTimeMin.HasValue 
					|| h.AutonomousTime.HasValue == false 
					|| hardDiskFilter.AutonomousTimeMin.Value <= h.AutonomousTime.Value
				)
				&& (
					!hardDiskFilter.BufferSizeMax.HasValue 
					|| h.BufferSize.HasValue == false 
					|| hardDiskFilter.BufferSizeMax.Value >= h.BufferSize.Value
				)
				&& (
					!hardDiskFilter.BufferSizeMin.HasValue 
					|| h.BufferSize.HasValue == false 
					|| hardDiskFilter.BufferSizeMin.Value <= h.BufferSize.Value
				)
				&& (
					!hardDiskFilter.CostMax.HasValue 
					|| h.Cost.HasValue == false 
					|| hardDiskFilter.CostMax.Value >= h.Cost.Value
				)
				&& (
					!hardDiskFilter.CostMin.HasValue 
					|| h.Cost.HasValue == false 
					|| hardDiskFilter.CostMin.Value <= h.Cost.Value
				)
				&& (
					!hardDiskFilter.FlashSizeMax.HasValue 
					|| h.FlashSize.HasValue == false || 
					hardDiskFilter.FlashSizeMax.Value >= h.FlashSize.Value
				)
				&& (
					!hardDiskFilter.FlashSizeMin.HasValue 
					|| h.FlashSize.HasValue == false 
					|| hardDiskFilter.FlashSizeMin.Value <= h.FlashSize.Value
				)
				&& (
					!hardDiskFilter.HasSCSI.HasValue 
					|| h.HasSCSI.HasValue == false ||
					hardDiskFilter.HasSCSI.Value == h.HasSCSI.Value
				)
				&& (
					!hardDiskFilter.IsM2.HasValue 
					|| h.IsM2.HasValue == false 
					|| hardDiskFilter.IsM2.Value == h.IsM2.Value
				)
				&& (
					!hardDiskFilter.ReadSpeedMax.HasValue 
					|| h.ReadSpeed.HasValue == false 
					|| hardDiskFilter.ReadSpeedMax.Value >= h.ReadSpeed.Value
				)
				&& (
					!hardDiskFilter.ReadSpeedMin.HasValue 
					|| h.ReadSpeed.HasValue == false
					|| hardDiskFilter.ReadSpeedMin.Value <= h.ReadSpeed.Value
				)
				&& (
					!hardDiskFilter.RotationSpeedMin.HasValue 
					|| h.RotationSpeed.HasValue == false
					|| hardDiskFilter.RotationSpeedMin.Value <= h.RotationSpeed.Value
				)
				&& (
					!hardDiskFilter.RotationSpeedMax.HasValue
					|| h.RotationSpeed.HasValue == false 
					|| hardDiskFilter.RotationSpeedMax.Value >= h.RotationSpeed.Value
				)
				&& (
					!hardDiskFilter.SizeMax.HasValue
					|| h.Size.HasValue == false
					|| hardDiskFilter.SizeMax.Value >= h.Size.Value
				)
				&& (
					!hardDiskFilter.SizeMin.HasValue
					|| h.Size.HasValue == false
					|| hardDiskFilter.SizeMin.Value <= h.Size.Value
				)
				&& (
					!hardDiskFilter.WorkTimeMax.HasValue 
					|| h.WorkTime.HasValue == false
					|| hardDiskFilter.WorkTimeMax.Value >= h.WorkTime.Value
				)
				&& (
					!hardDiskFilter.WorkTimeMin.HasValue 
					|| h.WorkTime.HasValue == false
					|| hardDiskFilter.WorkTimeMin.Value <= h.WorkTime.Value
				)
				&& (
					!hardDiskFilter.WriteSpeedMax.HasValue
					|| h.WriteSpeed.HasValue == false
					|| hardDiskFilter.WriteSpeedMax.Value >= h.WriteSpeed.Value
				)
				&& (
					!hardDiskFilter.WriteSpeedMin.HasValue 
					|| h.WriteSpeed.HasValue == false 
					|| hardDiskFilter.WriteSpeedMin.Value <= h.WriteSpeed.Value
				)
			);

			var dt = new List<HardDisk>();
			foreach (var h in disks)
			{
				if (
					(
						hardDiskFilter.Colors == null 
						|| hardDiskFilter.Colors.Count == 0 
						|| hardDiskFilter.Colors.Contains(h.Color)
					)
					&& (
						hardDiskFilter.FormFactors == null 
						|| hardDiskFilter.FormFactors.Count == 0 
						|| h.FormFactor.HasValue == false 
						|| hardDiskFilter.FormFactors.Contains(h.FormFactor.Value)
					)
					&& (
						hardDiskFilter.Manufacturers == null 
						|| hardDiskFilter.Manufacturers.Count == 0 
						|| hardDiskFilter.Manufacturers.Contains(h.Manufacturer)
					)
					&& (
						hardDiskFilter.Purposes == null 
						|| hardDiskFilter.Purposes.Count == 0 
						|| h.Purpose.HasValue == false 
						|| hardDiskFilter.Purposes.Contains(h.Purpose.Value)
					)
					&& (
						hardDiskFilter.Satas == null 
						|| hardDiskFilter.Satas.Count == 0 
						|| h.Sata.HasValue == false 
						|| hardDiskFilter.Satas.Contains(h.Sata.Value)
					)
					&& (
						hardDiskFilter.Types == null 
						|| hardDiskFilter.Types.Count == 0 
						|| h.Type.HasValue == false 
						|| hardDiskFilter.Types.Contains(h.Type.Value)
					)
					&& (
						hardDiskFilter.UsbTypes == null 
						|| hardDiskFilter.UsbTypes.Count == 0 
						|| h.Usb.HasValue == false 
						|| hardDiskFilter.UsbTypes.Contains(h.Usb.Value)
					)
				)
				{
					dt.Add(h);
				}
			}

			var dk = dt.Where(h => h != null);

			if (hardDiskFilter.PageSize.HasValue)
			{
				if (hardDiskFilter.Page.HasValue)
				{
					dk = dk.Skip(hardDiskFilter.Page.Value * hardDiskFilter.PageSize.Value);
				}
				dk = dk.Take(hardDiskFilter.PageSize.Value);
			}

			var d = dk.ToList();
			return View(new List<object>
			{
				d,
				hardDiskFilter
			});
		}
	}
}