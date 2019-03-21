using System.Collections.Generic;

namespace BorrowIt.Common.Infrastructure.Abstraction.DTOs
{
    public abstract class PaginatedDto<TDto> : IDto where TDto : IDto 
    {
        protected PaginatedDto(int pageNumber, int pageSize, int count, IEnumerable<TDto> items)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Count = count;
            Items = items;
        }

        public int Count { get; private set; }
        public int PageSize { get; private set; }
        public int PageNumber { get; private set; }
        public IEnumerable<TDto> Items { get;  private set; }
    }
}