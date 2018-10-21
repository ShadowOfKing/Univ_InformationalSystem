using System;
using System.Drawing;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using IS_lab1.Models.Extensions;
using IS_lab1.Models.Translations;

namespace IS_lab1.Models
{
	public class Color : ICloneable
	{
		public Color()
		{
			Id = -1;
			a = 1;
		}
		public Color(int r, int g, int b, double a = 1, DefaultContext context = null)
		{
			Id = -1;
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
			if (context != null)
			{
				var newC = context.Colors.Where(i => i.R == r && i.G == g && i.B == b && i.A == a).FirstOrDefault();
				if (newC != null)
				{
					Id = newC.Id;
				}
			}
		}
		public Color(Color color)
		{
			Id = color.Id;
			r = color.r;
			g = color.g;
			b = color.b;
			a = color.a;
		}
		public Color(string name, DefaultContext context, ColorTranslation.Languages lang = ColorTranslation.Languages.Eng)
		{
			if (context == null)
			{
				throw new Exception("DefaultContext is null");
			}
			ColorTranslation translation = null;
			switch (lang)
			{
				case ColorTranslation.Languages.Rus:
					translation = context.ColorTranslations.Where(c => c.Rus.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
					break;
				default:
					translation = context.ColorTranslations.Where(c => c.Eng.Trim().ToLower() == name.Trim().ToLower()).FirstOrDefault();
					break;
			}
			if (translation != null)
			{
				var color = context.Colors.Where(c => c.Id == translation.ColorId).First();
				r = color.r;
				g = color.g;
				b = color.b;
				a = color.a;
				Id = color.Id;
			} else
			{
				Id = -1;
				a = 1;
			}
		}

		private int r;
		private int g;
		private int b;
		private double a;

		[Key]
		[Required]
		public int Id;
		[Required]
		public int R {
			get
			{
				return r;
			}
			set {
				if (r != value) Id = -1;
				r = value;
			}
		}
		[Required]
		public int G
		{
			get
			{
				return g;
			}
			set
			{
				if (g != value) Id = -1;
				g = value;
			}
		}
		[Required]
		public int B
		{
			get
			{
				return b;
			}
			set
			{
				if (b != value) Id = -1;
				b = value;
			}
		}
		[Required]
		public double A
		{
			get
			{
				return a;
			}
			set
			{
				if (a != value) Id = -1;
				a = value;
			}
		}

		public object Clone()
		{
			return new Color(r, g, b, a);
		}
		
		public bool Equal(object color)
		{
			var c = color.ToColor();
			if (c.Id < 0 || Id < 0)
			{
				return c.r == r && c.g == g && c.b == b && c.a == a;
			}
			else
			{
				return c.Id == Id;
			}
		}
	}
}