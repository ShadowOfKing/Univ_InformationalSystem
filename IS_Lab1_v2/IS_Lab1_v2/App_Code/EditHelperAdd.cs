using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using IS_Lab1_v2.Models.Helper;

namespace IS_Lab1_v2.AppCode
{
	public static class EditHelperAdd
	{
		public static MvcHtmlString TextBoxFor<TModel, TItem>(HtmlHelper<TModel> html, Expression<Func<TModel, TItem>> expr, dynamic attributes)
		{
			DynamicHelper.SetDynamicObject(ref attributes);
			var meta = ModelMetadata.FromLambdaExpression(expr, html.ViewData);
			var name = ExpressionHelper.GetExpressionText(expr);
			var id = name.Replace('.', '_').Replace("[", "_").Replace("]", "_");
			var val = meta.SimpleDisplayText;

			DynamicHelper.ChangeDynamicParam(attributes, "type", "text", true);
			DynamicHelper.ChangeDynamicParam(attributes, "value", val, true);
			DynamicHelper.ChangeDynamicParam(attributes, "name", name, true);
			DynamicHelper.ChangeDynamicParam(attributes, "id", id, true);
			var attrs = (IDictionary<string, object>)attributes;

			var box = new StringBuilder();
			box.Append("<input");
			foreach (var attr in attrs)
			{
				if (attr.Value != null)
				{
					box.Append(" " + attr.Key + "=\"" + attr.Value.ToString() + "\"");
				}
			}
			box.Append("/>");
			return new MvcHtmlString(box.ToString());
		}
		public static MvcHtmlString LabelFor<TModel, TItem>(HtmlHelper<TModel> html, Expression<Func<TModel, TItem>> expr, dynamic attributes)
		{
			DynamicHelper.SetDynamicObject(ref attributes);
			var meta = ModelMetadata.FromLambdaExpression(expr, html.ViewData);
			var name = ExpressionHelper.GetExpressionText(expr);
			var id = name.Replace('.', '_').Replace("[", "_").Replace("]", "_");
			var text = meta.DisplayName ?? meta.PropertyName ?? name.Split('.').Last();

			DynamicHelper.ChangeDynamicParam(attributes, "for", name);
			DynamicHelper.ChangeDynamicParam(attributes, "id", id + "__label");
			var attrs = (IDictionary<string, object>)attributes;

			var label = new StringBuilder();
			label.Append("<label");
			foreach (var attr in attrs)
			{
				label.Append(" " + attr.Key + "=\"" + attr.Value.ToString() + "\"");
			}
			label.Append(">" + text + "</label>");
			return new MvcHtmlString(label.ToString());
		}
		public static MvcHtmlString RadioButtonFor<TModel, TItem>(HtmlHelper<TModel> html, Expression<Func<TModel, TItem>> expr, dynamic attributes, bool active = false)
		{
			DynamicHelper.SetDynamicObject(ref attributes);
			var attrs = (IDictionary<string, object>)attributes;
			attributes.type = "radio";
			var text = "";
			if (attrs.ContainsKey("text"))
			{
				text = (string)attributes.text;
				attributes.text = null;
			}
			if (active && !attrs.ContainsKey("checked"))
			{
				attrs["checked"] = "checked";
			}
			var res = TextBoxFor(html, expr, attributes);
			return new MvcHtmlString(res + text.ToString());
		}
		public static string TextFor<Tmodel, TItem>(HtmlHelper<Tmodel> html, Expression<Func<Tmodel, TItem>> expr)
		{
			var meta = ModelMetadata.FromLambdaExpression(expr, html.ViewData);
			var name = ExpressionHelper.GetExpressionText(expr);
			return meta.DisplayName ?? meta.PropertyName ?? name.Split('.').Last();
		}
	}
}