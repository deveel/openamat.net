using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

using DryIoc;

namespace Deveel.OpenAmat.Client.TransitLand.v1 {
	static class PagingUtil {
		public static object GetPaging(object args, Paging paging) {
			dynamic expando = new ExpandoObject();

			if (paging != null) {
				if (!String.IsNullOrEmpty(paging.SortKey))
					expando.sort_key = paging.SortKey;
				if (paging.SortOrder != SortOrder.Default) {
					if (paging.SortOrder == SortOrder.Ascending) {
						expando.sort_order = "asc";
					} else if (paging.SortOrder == SortOrder.Descending) {
						expando.sort_order = "desc";
					}
				}
				if (paging.Offset >= 0)
					expando.offset = paging.Offset;
				if (paging.Count > 0)
					expando.per_page = paging.Count;
			}

			var pairs = (IDictionary<string, object>) expando;

			if (args != null) {
				IDictionary<string, object> argsDict;
				if (args is IDictionary<string, object>) {
					argsDict = (IDictionary<string, object>) args;
				} else {
					argsDict = args.GetType().GetRuntimeProperties()
						.Where(prop => prop.GetGetMethodOrNull() != null)
						.ToDictionary(key => key.Name, value => value.GetValue(args));
				}

				foreach (var pair in argsDict) {
					pairs.Add(pair.Key, pair.Value);
				}
			}

			return pairs;
		}
	}
}
