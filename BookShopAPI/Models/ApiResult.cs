using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Models
{
    public class ApiResult<TEntity>
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string Url { get; set; }
        public string PrevUrl { get; set; }
        public string NextUrl { get; set; }

        public IEnumerable<TEntity> Result { get; set; }
    }
}