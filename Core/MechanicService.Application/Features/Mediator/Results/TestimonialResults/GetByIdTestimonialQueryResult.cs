﻿namespace MechanicService.Application.Features.Mediator.Results.TestimonialResults
{
    public class GetByIdTestimonialQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAppear { get; set; }
    }
}
