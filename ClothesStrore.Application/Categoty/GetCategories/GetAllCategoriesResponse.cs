

namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class Data
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class GetAllCategoriesResponse
    {
        public List<Data> Data { get; set; } = new List<Data>();
        public int TotalRecords { get; set; }
    }
}
