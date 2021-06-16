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
    /// Запросы к API users
    /// </summary>
    public static class UsersQueries
    {
        /// <summary>
        /// Запросить описание пользователя (если не админ, то только самого себя).
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Объект пользователя "User".</returns>
        public static async Task<UserJson> ShowUserDetailsAsync(string userId)
        {
            // see https://canvas.instructure.com/doc/api/users.html#method.users.api_show

            string url = ApiController.GetV1Url("v1/users/" + userId);
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserJson>(data.Result);
        }
        /// <summary>
        /// Запросить профиль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <returns>Объект профиля пользователя "UserProfile".</returns>
        public static async Task<UserProfileJson> GetUserProfileAsync(string userId)
        {
            // see https://canvas.instructure.com/doc/api/users.html#method.profile.settings

            string url = ApiController.GetV1Url("v1/users/" + userId + "/profile");
            using var data = (await ApiController.HttpClient.GetAsync(url).ConfigureAwait(false)).Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserProfileJson>(data.Result);
        }
    }
}
