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
	public class CompanyController : ApiController
	{
		private DefaultContext _db = new DefaultContext();

		// GET: api/Companies
		
		public IQueryable<Company> GetCompany()
		{
			return _db.Companies;
		}

		// GET: api/Companies/5
		[ResponseType(typeof(object))]
		public async Task<IHttpActionResult> GetCompany(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			Company Company = await _db.Companies.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (Company == null)
			{
				return NotFound();
			}
			return Ok(Company);
		}

		// PUT: api/Companies/5
		
		[ResponseType(typeof(void))]
		public async Task<IHttpActionResult> PutCompany(int? id, Company Company)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			if (Company == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != Company.Id)
			{
				return BadRequest();
			}

			_db.Entry(Company).State = EntityState.Modified;

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CompanyExists(id.Value))
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

		// POST: api/Companies
		//
		[ResponseType(typeof(Company))]
		public async Task<IHttpActionResult> PostCompany(Company Company)
		{
			if (Company == null)
			{
				return BadRequest("Отсутствует тело элемента");
			}
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_db.Companies.Add(Company);

			try
			{
				await _db.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (CompanyExists(Company.Id))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}
			return CreatedAtRoute("DefaultApi", new { id = Company.Id }, Company);
		}

		// DELETE: api/Companies/5
		//
		[ResponseType(typeof(Company))]
		public async Task<IHttpActionResult> DeleteCompany(int? id)
		{
			if (!id.HasValue)
			{
				return BadRequest("Не указан Id");
			}
			Company Company = await _db.Companies.Where(t => t.Id == id).SingleOrDefaultAsync();
			if (Company == null)
			{
				return NotFound();
			}

			_db.Companies.Remove(Company);
			await _db.SaveChangesAsync();

			return Ok(Company);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool CompanyExists(int id)
		{
			return _db.Companies.Count(e => e.Id== id) > 0;
		}
	}
}