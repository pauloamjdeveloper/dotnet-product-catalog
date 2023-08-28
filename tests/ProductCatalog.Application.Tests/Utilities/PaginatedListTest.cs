using ProductCatalog.Application.Utilities;

namespace ProductCatalog.Application.Tests.Utilities
{
    public class PaginatedListTest
    {
        [Fact(DisplayName = "Create - PaginatedList Should Be Validated")]
        public void PaginatedList_Create_ShouldBePaginateCorrectly()
        {
            var source = Enumerable.Range(1, 100);
            var pageIndex = 4;
            var pageSize = 10;

            var paginatedList = PaginatedList<int>.Create(source, pageIndex, pageSize);

            Assert.Equal(pageIndex, paginatedList.PageIndex);
            Assert.Equal(10, paginatedList.TotalPages);
            Assert.True(paginatedList.HasPreviousPage);
            Assert.True(paginatedList.HasNextPage);

            var pageItems = paginatedList.ToList();

            var expectedPageItems = Enumerable.Range(31, 10);
            Assert.Equal(expectedPageItems, pageItems);
        }

        [Fact(DisplayName = "Create - PaginatedList Should Be Invalidated")]
        public void PaginatedList_Create_ShouldNotBePaginateCorrectly()
        {
            var source = Enumerable.Range(1, 100);
            var pageIndex = 0;
            var pageSize = 10;

            Assert.Throws<ArgumentException>(() => PaginatedList<int>.Create(source, pageIndex, pageSize));
        }
    }
}
