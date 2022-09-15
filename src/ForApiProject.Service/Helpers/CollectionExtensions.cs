using ForApiProjectDomain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProject.Service.Helpers
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams @params)
             => @params.PageIndex > 0 && @params.PageSize >= 0 
                ? source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)    
                : source;
    }
}
