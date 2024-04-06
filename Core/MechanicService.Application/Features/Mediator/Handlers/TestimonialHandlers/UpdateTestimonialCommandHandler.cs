namespace MechanicService.Application.Testimonials.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            values.Name = request.Name;
            values.Title = request.Title;
            values.Comment = request.Comment;
            values.ImageUrl = request.ImageUrl;
            values.IsAppear = request.IsAppear;
            await _repository.UpdateAsync(values);
        }
    }
}
