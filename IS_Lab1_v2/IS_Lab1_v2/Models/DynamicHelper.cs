using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Lab1_v2.Models.Helper
{
	public static class DynamicHelper
	{

		public static dynamic ObjectToDynamic(this object value)
		{
			IDictionary<string, object> expando = new ExpandoObject();

			foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
			{
				try
				{
					expando.Add(property.Name, property.GetValue(value));
				}
				catch (InvalidOperationException ex)
				{
					//Игнорируем поля, доступ к которым получить на данный момент невозможно.
					Console.WriteLine(ex.Message); //Зачем-то
					continue;
				}
				catch
				{
					//TODO: Разобраться, почему не ловится InvalidOperationException
					continue;
				}
			}

			return expando as ExpandoObject;
		}
		public static void SetDynamicObject(ref dynamic obj)
		{
			obj = obj ?? new { };
			if (!(obj is ExpandoObject))
			{
				obj = ObjectToDynamic(obj);
			}
		}
		public static void ChangeDynamicParam(dynamic obj, string name, string value, bool replace = false, Type t = null)
		{
			var d = (IDictionary<string, object>)obj;
			if (!d.ContainsKey(name))
			{
				d[name] = "";
			}
			else if (replace)
			{
				value = null;
			}
			if (value != null)
			{
				d[name] = d[name].ToString() + value;
				if (t != null)
				{
					d[name] = Convert.ChangeType(d[name], t);
				}
			}
		}
		public static void ChangeDynamicParam(dynamic obj, string name, dynamic value)
		{
			var d = (IDictionary<string, object>)obj;
			if (!d.ContainsKey(name) || d[name] == null)
			{
				d[name] = value;
			}
			else
			{
				if (!(d[name] is ExpandoObject))
				{
					d[name] = ObjectToDynamic(d[name]);
				}
			}
		}
	}
}
