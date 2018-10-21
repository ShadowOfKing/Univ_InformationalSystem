using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IS_lab1.Models;
using IS_lab1.Models.Translations;

namespace IS_lab1.Controllers.Api
{
	public class ColorTranslationController : ApiController
	{
		private DefaultContext _db = new DefaultContext();

		// GET: api/ColorTranslations
		
		public IQueryable<ColorTranslation> GetColorTranslation()
		{
			return _db.ColorTranslations;
		}

		// GET: api/ColorTranslations/5
		[ResponseType(typeof(object))]
		public async Task<IHttpActionResult> GetColorTranslation(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			ColorTranslation ColorTranslation = await _db.ColorTranslations.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (ColorTranslation == null)
			{
				return NotFound();
			}
			return Ok(ColorTranslation);
		}

		// PUT: api/ColorTranslations/5
		
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutColorTranslation(int? id, ColorTranslation ColorTranslation)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			if (ColorTranslation == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != ColorTranslation.Id)
			{
				return BadRequest();
			}

			_db.Entry(ColorTranslation).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ColorTranslationExists(id.Value))
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

		// POST: api/ColorTranslations
		//
		[ResponseType(typeof(ColorTranslation))]
		public async Task<IHttpActionResult> PostColorTranslation(ColorTranslation ColorTranslation)
		{
			if (ColorTranslation == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_db.ColorTranslations.Add(ColorTranslation);

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (ColorTranslationExists(ColorTranslation.Id))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}
			return CreatedAtRoute("DefaultApi", new { id = ColorTranslation.Id }, ColorTranslation);
		}

		// DELETE: api/ColorTranslations/5
		//
		[ResponseType(typeof(ColorTranslation))]
		public async Task<IHttpActionResult> DeleteColorTranslation(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			ColorTranslation ColorTranslation = await _db.ColorTranslations.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (ColorTranslation == null)
			{
				return NotFound();
			}

			_db.ColorTranslations.Remove(ColorTranslation);
			await _db.SaveChangesAsync();

			return Ok(ColorTranslation);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool ColorTranslationExists(int id)
		{
			return _db.ColorTranslations.Count(e => e.Id== id) > 0;
		}
	}
}