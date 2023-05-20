using entities;

namespace Service
{
    public interface IRatingService
    {
        Task<Rating> addRatingAsync(Rating rating);
    }
}
