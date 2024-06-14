using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModel
{
    public class Pager
    {
        public Pager(long totalItems, int? page, int? pageSize)
        {
            if (pageSize == null)
            {
                pageSize = 10;
            }
            var totalPages = (int)Math.Ceiling(totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 2;
            var endPage = currentPage + 2;
            if (startPage <= 0)
            {
                endPage -= startPage - 1;
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 5)
                {
                    startPage = endPage - 4;
                }
            }
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = Convert.ToInt32(pageSize);
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
        public long TotalItems { get; private set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}
