﻿namespace MechanicService.Application.Features.Mediator.Results.BlogResults
{
    public class GetBlogQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public int CategoryID { get; set; }
        public string Description { get; set; }
    }
}