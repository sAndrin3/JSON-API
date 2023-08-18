using System.Collections.Generic;
using System.Threading.Tasks;
using Challenge.Models;

namespace Challenge.Services {
    public interface IUserService{
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId);
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}