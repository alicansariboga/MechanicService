namespace MechanicService.Application.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class GetByIdTestimonialQueryHandler : IRequestHandler<GetByIdTestimonialQuery, GetByIdTestimonialQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetByIdTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdTestimonialQueryResult> Handle(GetByIdTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetByIdTestimonialQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                Title = values.Title,
                Comment = values.Comment,
                ImageUrl = values.ImageUrl,
                IsAppear = values.IsAppear,
            };
        }
    }
}
