using Challenge.Controller;
using Challenge.Services;

namespace Challenge{
    class Program{
        static void Main(string[] args){
            var userService = new UserService();
            var userController = new UserController(userService);

            userController.RunAsync().Wait();
        }
    }
}