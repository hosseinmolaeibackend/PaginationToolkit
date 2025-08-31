using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaginationToolkit
{
    public class PaginationResult<T>
    {
        public List<T> Data { get; set; }
        public PaginationMetadata Metadata { get; set; }

        public PaginationResult(List<T> data, int count, int pageNumber, int pageSize)
        {
            Data = data;
            Metadata = new PaginationMetadata
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
        }
    }

    public class PaginationMetadata
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        [JsonIgnore]
        public bool HasPrevious => CurrentPage > 1;

        [JsonIgnore]
        public bool HasNext => CurrentPage < TotalPages;
    }
}
