using System.Data.Entity;
using IS_lab1.Models.Products;
using IS_lab1.Models.Translations;

namespace IS_lab1.Models
{
	public class DefaultContext : DbContext
	{
		public DefaultContext()
		: base("DefaultConnection")
		{
		}
		
		public DbSet<Color> Colors { get; set; }
		public DbSet<ColorTranslation> ColorTranslations { get; set; }
		public DbSet<HardDisk> HardDisks { get; set; }
		public DbSet<Company> Companies { get; set; }

		public static DefaultContext Create()
		{
			return new DefaultContext();
		}
		static DefaultContext()
		{
			Database.SetInitializer<DefaultContext>(new DefaultInit());
		}


		public class DefaultInit : CreateDatabaseIfNotExists<DefaultContext>//DropCreateDatabaseIfModelChanges<DefaultContext>//DropCreateDatabaseAlways<DefaultContext>
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