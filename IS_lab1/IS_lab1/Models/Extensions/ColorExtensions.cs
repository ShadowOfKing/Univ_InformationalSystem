using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace IS_lab1.Models.Extensions
{
	public static class ColorExtensions
	{
		public static Color ToColor(this object color, DefaultContext context = null)
		{
			Color c = null;
			if (color is Color)
			{
				c = (Color)((Color)color).Clone();
				if (c == null)
				{
					c = new Color();
				}
			} else if (color is string)
			{
				var s = ((string)color).ToLower();
				if (s[0] == '#')
				{
					var t = ColorTranslator.FromHtml((string)color);
					c = new Color(t.R, t.G, t.B, t.A);
				} else if (s[0] == 'r' && s[1] == 'g' && s[2] == 'b' && s[s.Length - 1] == ')')
				{
					string[] vals = null;
					if (s[3] == '(')
					{
						vals = (s.Substring(4).Substring(0, s.Length - 5) + ", 1").Split(',');
					} else if (s[3] == 'a' && s[4] == '(')
					{
						vals = s.Substring(5).Substring(0, s.Length - 6).Split(',');
					}
					if (vals != null)
					{
						try
						{
							c = new Color(
								int.Parse(vals[0]),
								int.Parse(vals[1]),
								int.Parse(vals[2]),
								double.Parse(vals[3])
							);
						} catch {}
					}
				}
				if (c == null)
				{
					throw new Exception("Невозможно преобразовать строку " + s + " в тип Color");
				}
			} else if (color is System.Drawing.Color)
			{
				var t = (System.Drawing.Color)color;
				c = new Color(t.R, t.G, t.B, t.A);
			}

			if (c == null)
			{
				throw new Exception("Невозможно преобразовать в тип Color тип " + color.GetType().FullName);
			}

			if (context != null && c.Id < 0)
			{
				var newC = context.Colors.Where(i => i.R == c.R && i.G == c.G && i.B == c.B && i.A == c.A).FirstOrDefault();
				if (newC != null)
				{
					c.Id = newC.Id;
				}
			}
			return c;
		}
	}
}