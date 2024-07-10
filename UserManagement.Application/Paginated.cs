namespace UserManagement.Application;

public class Paginated<T>
{
    public List<T> Data { get; set; }
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
