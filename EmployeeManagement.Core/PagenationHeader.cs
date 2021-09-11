using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Core
{
    public class PagenationHeader
    {
        public PagenationHeader(int currentPage, int itemsPerpage, int totalItems, int totalPages)
        {
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerpage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
