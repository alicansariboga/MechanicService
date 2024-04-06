namespace MechanicService.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetByIdTestimonialQuery : IRequest<GetByIdTestimonialQueryResult>
    {
        public GetByIdTestimonialQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
