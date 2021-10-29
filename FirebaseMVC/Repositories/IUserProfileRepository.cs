using BusinessVenture.Models;

namespace BusinessVenture.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetUserProfileById(int id);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        UserProfile GetById(int id);
        void UpdateUserProfile(UserProfile userProfile);
    }
}