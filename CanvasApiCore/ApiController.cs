using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CanvasApiCore
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApiController
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string server_url = "https://lms.misis.ru:443/api/";
        private static readonly string token;
        private static readonly string test_user_id;           
        private static readonly string test_course_id;         
        private static readonly string test_assignment_id;    
        private static readonly string test_student_id;        

        public static HttpClient HttpClient => httpClient;
        public static string ServerUrl => server_url;
        public static string Token => token;
        public static string TestUserID => test_user_id;
        public static string TestCourseID => test_course_id;
        public static string TestAssignmentID => test_assignment_id;
        public static string TestStudentID => test_student_id;

        public static string GetV1Url(string api_url) => server_url + api_url + $"?access_token={token}";
        public static string GetV1Url(string api_url, string addParams) => server_url + api_url + $"?{addParams}" + $"access_token={token}";
    }
}
