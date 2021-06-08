using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanvasApiCore.Models.Users;
using Newtonsoft.Json;

namespace CanvasApiCore.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersQueries
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<User> ShowUserDetailsAsync(string userId = "23392")
        {
            // see https://canvas.instructure.com/doc/api/users.html#method.users.api_show

            string url = ApiController.GetV1Url("v1/users/" + userId);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(data.Result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static async Task<UserProfile> GetUserProfileAsync(string userId = "23392")
        {
            // see https://canvas.instructure.com/doc/api/users.html#method.profile.settings

            string url = ApiController.GetV1Url("v1/users/" + userId + "/profile");
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserProfile>(data.Result);
        }
    }
}
