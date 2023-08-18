using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Challenge.Models;


namespace Challenge.Services{
    public class UserService: IUserService{
        private readonly HttpClient _httpClient;

        public UserService(){
            _httpClient = new HttpClient();
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync(){
            var response  = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
            return users;
        }
        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(int userId){
            var response  = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/posts?userId={userId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(json);
            return posts;
        }
        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
       {
            var response = await _httpClient.GetAsync($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(json);
            return comments;
        }

       
    }
}