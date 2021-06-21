using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CanvasApiCore.Models;
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
        /// <param name ="cancel">Токен завершения асинхронной задачи</param>
        /// <returns>Объект пользователя "User".</returns>
        /// <exception cref="Newtonsoft.Json.JsonException">Ошибка десериализации</exception>
        /// <exception cref="Exception">Ошибка HTTP запроса</exception>
        public static async Task<UserJson> ShowUserDetailsAsync(string userId, CancellationToken cancel = default)
        {
            // see https://canvas.instructure.com/doc/api/users.html#method.users.api_show

            string url = ApiController.GetV1Url("v1/users/" + userId);
            var data = (await ApiController.HttpClient.GetAsync(url, cancel).ConfigureAwait(false)).Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<UserJson>(data.Result);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(JsonException))
                    throw new JsonException($"URL: {url}\nError JSON: {data.Result}\nMessage: {e.Message}\n", e.InnerException);
                throw new Exception($"URL: {url}\nMessage: {e.Message}\n", e.InnerException);
            }
        }
        /// <summary>
        /// Запросить профиль пользователя
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name ="cancel">Токен завершения асинхронной задачи</param>
        /// <returns>Объект профиля пользователя "UserProfile".</returns>
        /// <exception cref="Newtonsoft.Json.JsonException">Ошибка десериализации</exception>
        /// <exception cref="Exception">Ошибка HTTP запроса</exception>
        public static async Task<UserProfileJson> GetUserProfileAsync(string userId, CancellationToken cancel = default)
        {
            // see https://canvas.instructure.com/doc/api/users.html#method.profile.settings

            string url = ApiController.GetV1Url("v1/users/" + userId + "/profile");
            var data = (await ApiController.HttpClient.GetAsync(url, cancel).ConfigureAwait(false)).Content.ReadAsStringAsync();
            try
            {
                return JsonConvert.DeserializeObject<UserProfileJson>(data.Result);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(JsonException))
                    throw new JsonException($"URL: {url}\nError JSON: {data.Result}\nMessage: {e.Message}\n", e.InnerException);
                throw new Exception($"URL: {url}\nMessage: {e.Message}\n", e.InnerException);
            }
        }
    }
}
