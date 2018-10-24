using System.Data.Entity;
using IS_lab1_v2.Models;

namespace IS_Lab1_v2.Models
{
	public class DefaultContext : DbContext
	{
		public DefaultContext()
		: base("DefaultConnection")
		{
		}

		public DbSet<HardDisk> HardDisks { get; set; }

		public static DefaultContext Create()
		{
			return new DefaultContext();
		}
		static DefaultContext()
		{
			Database.SetInitializer<DefaultContext>(new DefaultInit());
		}


		public class DefaultInit : CreateDatabaseIfNotExists<DefaultContext>
		{
			protected override void Seed(DefaultContext context)
			{
				PerformInitialSetup(context);
				base.Seed(context);
			}
			public void PerformInitialSetup(DefaultContext context)
			{

			}
		}

	}
}