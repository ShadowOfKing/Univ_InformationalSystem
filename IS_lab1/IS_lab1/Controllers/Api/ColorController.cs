using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using IS_lab1.Models;

namespace IS_lab1.Controllers.Api
{
	public class ColorController : ApiController
	{
		private DefaultContext _db = new DefaultContext();

		// GET: api/Colors
		
		public IQueryable<Color> GetColor()
		{
			return _db.Colors;
		}

		// GET: api/Colors/5
		[ResponseType(typeof(object))]
		public async Task<IHttpActionResult> GetColor(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			Color Color = await _db.Colors.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (Color == null)
			{
				return NotFound();
			}
			return Ok(Color);
		}

		// PUT: api/Colors/5
		
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutColor(int? id, Color Color)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			if (Color == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Color.Id)
			{
				return BadRequest();
			}

			_db.Entry(Color).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ColorExists(id.Value))
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

		// POST: api/Colors
		//
		[ResponseType(typeof(Color))]
		public async Task<IHttpActionResult> PostColor(Color Color)
		{
			if (Color == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_db.Colors.Add(Color);

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (ColorExists(Color.Id))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}
			return CreatedAtRoute("DefaultApi", new { id = Color.Id }, Color);
		}

		// DELETE: api/Colors/5
		//
		[ResponseType(typeof(Color))]
		public async Task<IHttpActionResult> DeleteColor(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			Color Color = await _db.Colors.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (Color == null)
			{
				return NotFound();
			}

			_db.Colors.Remove(Color);
			await _db.SaveChangesAsync();

			return Ok(Color);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool ColorExists(int id)
		{
			return _db.Colors.Count(e => e.Id== id) > 0;
		}
	}
}