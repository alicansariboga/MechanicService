using MechanicService.Dto.TagDtos;

namespace MechanicService.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailTagComponentPartial : ViewComponent
    {
        private readonly ITagRepository _tagService;

        public _BlogDetailTagComponentPartial(ITagRepository tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var tagDtos = new List<ResultTagDto>();

            var tags = _tagService.GetTagByBlogID(id);
            foreach (var item in tags)
            {
                var tagDto = new ResultTagDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    BlogID = item.BlogID
                };
                tagDtos.Add(tagDto);
            }
            return View(tagDtos);
        }
    }
}
