namespace Eecomerce.DTO
{
    public class SearchResult<T>
    {
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T> Data { get; set; }

    }
}
