using System;
using System.Threading.Tasks;
using Challenge.Services;

namespace Challenge.Controller{
    public class UserController{
        private readonly IUserService _userService;

        public UserController(IUserService userService){
            _userService = userService;
        }

        public async Task RunAsync(){
            System.Console.WriteLine("Fetching users...");
            var users = await _userService.GetAllUsersAsync();

            System.Console.WriteLine("Users:");
            foreach(var user in users){
                System.Console.WriteLine($"User ID: {user.Id}, username: {user.Username}");
            }
            System.Console.WriteLine("Enter user ID to view posts:");
            if(int.TryParse(Console.ReadLine(), out int userId))
            {
                var posts = await _userService.GetPostsByUserIdAsync(userId);
                System.Console.WriteLine($"Posts for User ID {userId}:");
                foreach (var post in posts)
                {
                    System.Console.WriteLine($"Post ID: {post.Id}, Title: {post.Title}"); 
                }
                
                System.Console.WriteLine("Enter post ID to view comments:");
                if(int.TryParse(Console.ReadLine(), out int postId))
                {
                    var comments = await _userService.GetCommentsByPostIdAsync(userId);
                    System.Console.WriteLine($"Comments for Post ID {postId}:");
                    foreach (var comment in comments)
                    {
                        System.Console.WriteLine($"Comment ID: {comment.Id}, Name: {comment.Name}");
                    }
                }
                else{
                    System.Console.WriteLine("Invalid post ID.");
                }
            }
            else{
                System.Console.WriteLine("Invalid user ID.");
            }
            }
        }
    }
