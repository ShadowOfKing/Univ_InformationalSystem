using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IS_lab1.Models;
using IS_lab1.Models.Products;
using System.Collections.Generic;
using System;

namespace IS_lab1.Controllers.Api
{
	public class ProductHardDiskController : ApiController
	{
		private DefaultContext _db = new DefaultContext();

		[HttpPatch]
		public IQueryable<HardDisk> GetHardDisks(HardDiskFilter selector)
		{
			var hd = _db.HardDisks.Where(h =>
				(!selector.AccessTimeMin.HasValue || selector.AccessTimeMin.Value <= h.AccessTime)
				&& (!selector.AccessTimeMax.HasValue || selector.AccessTimeMax.Value <= h.AccessTime)
				&& (!selector.Autonomous.HasValue || selector.Autonomous.Value == h.Autonomous)
				&& (!selector.AutonomousTimeMax.HasValue || selector.AutonomousTimeMax.Value >= h.AutonomousTime)
				&& (!selector.AutonomousTimeMin.HasValue || selector.AutonomousTimeMin.Value <= h.AutonomousTime)
				&& (!selector.BufferSizeMax.HasValue || selector.BufferSizeMax.Value >= h.BufferSize)
				&& (!selector.BufferSizeMin.HasValue || selector.BufferSizeMin.Value <= h.BufferSize)
				&& (!selector.CostMax.HasValue || selector.CostMax.Value >= h.Cost)
				&& (!selector.CostMax.HasValue || selector.CostMax.Value >= h.Cost)
				&& (!selector.FlashSizeMax.HasValue || selector.FlashSizeMax.Value >= h.FlashSize.Value)
				&& (!selector.FlashSizeMin.HasValue || selector.FlashSizeMin.Value <= h.FlashSize.Value)
				&& (!selector.HasSCSI.HasValue || selector.HasSCSI.Value == h.HasSCSI.Value)
				&& (!selector.IsM2.HasValue || selector.IsM2.Value == h.IsM2)
				&& (!selector.ReadSpeedMax.HasValue || selector.ReadSpeedMax.Value >= h.ReadSpeed.Value)
				&& (!selector.ReadSpeedMin.HasValue || selector.ReadSpeedMin.Value <= h.ReadSpeed.Value)
				&& (!selector.RotationSpeedMin.HasValue || selector.RotationSpeedMin.Value <= h.RotationSpeed.Value)
				&& (!selector.RotationSpeedMax.HasValue || selector.RotationSpeedMax.Value >= h.RotationSpeed.Value)
				&& (!selector.SizeMax.HasValue || selector.SizeMax.Value >= h.Size)
				&& (!selector.SizeMin.HasValue || selector.SizeMin.Value <= h.Size)
				&& (!selector.WorkTimeMax.HasValue || selector.WorkTimeMax.Value >= h.WorkTime.Value)
				&& (!selector.WorkTimeMin.HasValue || selector.WorkTimeMin.Value <= h.WorkTime.Value)
				&& (!selector.WriteSpeedMax.HasValue || selector.WriteSpeedMax.Value >= h.WriteSpeed.Value)
				&& (!selector.WriteSpeedMin.HasValue || selector.WriteSpeedMin.Value <= h.WriteSpeed.Value)
				&& (selector.Colors == null|| selector.Colors.Count == 0 || selector.Colors.Contains(h.Color))
				&& (selector.FormFactors == null || selector.FormFactors.Count == 0 || selector.FormFactors.Contains(h.FormFactor))
				&& (selector.Manufacturers == null || selector.Manufacturers.Count == 0 || selector.Manufacturers.Contains(h.Manufacturer))
				&& (selector.Purposes == null || selector.Purposes.Count == 0 || selector.Purposes.Contains(h.Purpose.Value))
				&& (selector.Satas == null || selector.Satas.Count == 0 || selector.Satas.Contains(h.Sata.Value))
				&& (selector.Types == null || selector.Types.Count == 0 || selector.Types.Contains(h.Type))
				&& (selector.UsbTypes == null || selector.UsbTypes.Count == 0 || selector.UsbTypes.Contains(h.Usb.Value))
			);

			if (selector.PageSize.HasValue)
			{
				if (selector.Page.HasValue)
				{
					hd = hd.Skip(selector.Page.Value * selector.PageSize.Value);
				}
				hd = hd.Take(selector.PageSize.Value);
			}
			return hd;
		}

		// GET: api/HardDisks
		
		public IQueryable<HardDisk> GetHardDisk()
		{
			return _db.HardDisks;
		}

		// GET: api/HardDisks/5
		[ResponseType(typeof(object))]
		public async Task<IHttpActionResult> GetHardDisk(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			HardDisk HardDisk = await _db.HardDisks.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (HardDisk == null)
			{
				return NotFound();
			}
			return Ok(HardDisk);
		}

		// PUT: api/HardDisks/5
		
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutHardDisk(int? id, HardDisk HardDisk)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			if (HardDisk == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != HardDisk.Id)
			{
				return BadRequest();
			}

			_db.Entry(HardDisk).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!HardDiskExists(id.Value))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return StatusCode(HttpStatusCode.NoContent);
		}

		// POST: api/HardDisks
		//
		[ResponseType(typeof(HardDisk))]
		public async Task<IHttpActionResult> PostHardDisk(HardDisk HardDisk)
		{
			if (HardDisk == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_db.HardDisks.Add(HardDisk);

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (HardDiskExists(HardDisk.Id))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}
			return CreatedAtRoute("DefaultApi", new { id = HardDisk.Id }, HardDisk);
		}

		// DELETE: api/HardDisks/5
		//
		[ResponseType(typeof(HardDisk))]
		public async Task<IHttpActionResult> DeleteHardDisk(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			HardDisk HardDisk = await _db.HardDisks.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (HardDisk == null)
			{
				return NotFound();
			}

			_db.HardDisks.Remove(HardDisk);
			await _db.SaveChangesAsync();

			return Ok(HardDisk);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool HardDiskExists(int id)
		{
			return _db.HardDisks.Count(e => e.Id== id) > 0;
		}
	}
}