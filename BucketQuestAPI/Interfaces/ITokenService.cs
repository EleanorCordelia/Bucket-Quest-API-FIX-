using BucketQuestAPI.Entities;

namespace BucketQuestAPI.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Account account);
    }
}