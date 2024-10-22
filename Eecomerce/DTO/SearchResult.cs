namespace Eecomerce.DTO
{
    public class SearchResult<T>
    {
        public int RowCount { get; set; }
        public List<T> Data { get; set; }

    }
}
