using eCourse.Models.Helpers;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Service
{
    public class ApiService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }
        private readonly string _route = null;

        public ApiService(string route)
        {
            _route = route;
        }
        public async Task<T> Get<T>(object search)
        {
            try
            {
                var url = $"{Properties.Settings.Default.APIUrl}/{_route}";
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw new ApiException(ex.Message, ex.Call.HttpStatus);
            }
        }
        public async Task<T> GetById<T>(object id)
        {
            try {
                return await $"{Properties.Settings.Default.APIUrl}/{_route}/{id}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                throw new ApiException(ex.Message, ex.Call.HttpStatus);
            }
        }
        public async Task<T> Insert<T>(object request)
        {
            try
            {
                return await $"{Properties.Settings.Default.APIUrl}/{_route}".WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if(ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized) {
                    throw new ApiException(ex.Message, ex.Call.HttpStatus);
                }
                else {
                    var errors = await ex.GetResponseJsonAsync<ApiException>();
                    //var stringBuilder = new StringBuilder();
                    //foreach (var error in errors)
                    //{
                    //    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                    //}

                    //MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //throw new ApiException(stringBuilder.ToString(), ex.Call.HttpStatus);
                    throw new ApiException(errors.Message, ex.Call.HttpStatus);
                }
            }
        }
        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                return await $"{Properties.Settings.Default.APIUrl}/{_route}/{id}".WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new ApiException(ex.Message, ex.Call.HttpStatus);
                }
                else
                {
                    var errors = await ex.GetResponseJsonAsync<ApiException>();
                    throw new ApiException(errors.Message, ex.Call.HttpStatus);
                }
            }
        }
    }
}
