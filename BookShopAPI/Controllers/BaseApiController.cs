using BookShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShopAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        internal const int DefaultPage = 1;
        internal const int DefaultPageSize = 10;
        const string Page = "page";
        const string PageSize = "pageSize";

        [NonAction]
        public ApiResult<TEntity> WrapResult<TEntity>(IEnumerable<TEntity> results, int page, int pageSize, int totalRecords,
                                                      string routeName, IDictionary<string, object> routeValues = null)
        {
            page = page <= 0 ? DefaultPage : page;
            pageSize = pageSize <= 0 ? DefaultPageSize : pageSize;


            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            routeValues = routeValues == null ? new Dictionary<string, object>() : routeValues;
            dynamic routeValuesObj = new ExpandoObject();
            routeValuesObj = routeValues;
            routeValues.Add(Page, page);
            routeValues.Add(PageSize, pageSize);

            var url = Url.Link(routeName, routeValuesObj);

            routeValues[Page] = page - 1;
            var prevUrl = page > DefaultPage ? Url.Link(routeName, routeValuesObj) : String.Empty;

            routeValues[Page] = page + 1;
            var NextUrl = page < totalPages ? Url.Link(routeName, routeValuesObj) : String.Empty;

            return new ApiResult<TEntity>()
            {
                TotalRecords = totalRecords,
                PageSize = pageSize,
                TotalPages = totalPages,
                Page = page,
                Url = url,
                PrevUrl = prevUrl,
                NextUrl = NextUrl,
                Result = results
            };

        }
    }
}
