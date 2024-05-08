namespace MechanicService.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogWithCategoryNameQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public int BlogTime { get; set; }
        public string CategoryName { get; set; }
    }
}
