using entities;

namespace Repository
{
    public interface IRatingRepository
    {
        Task<Rating> addRatingAsync(Rating rating);

    }
}