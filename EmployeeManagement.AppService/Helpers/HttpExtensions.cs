using EmployeeManagement.Core;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace EmployeeManagement.AppService.Helpers
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerpage, int totalItems, int totalPages)
        {
            var paginationHeader = new PagenationHeader(currentPage, itemsPerpage, totalItems, totalPages);

            //not compulsory
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");

        }
    }
}
