using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IS_Lab1_v2.Models.Helper
{
	public static class EnumHelper
	{
		public static string GetEnumDisplayAttribute(this Enum value, string name)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			var attribs = field.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.DisplayAttribute), true);
			if (attribs.Length > 0)
			{
				object o = attribs[0];
				DynamicHelper.SetDynamicObject(ref o);
				var attr = (IDictionary<string, object>)(o);
				if (attr.ContainsKey(name))
				{
					var message = attr[name].ToString();
					return message;// resourceMgr.GetString(message, CultureInfo.CurrentCulture);
				}
			}
			return string.Empty;
		}

		public static string GetEnumDisplayName(this Enum value)
		{
			return GetEnumDisplayAttribute(value, "Name");
		}
	}
}
