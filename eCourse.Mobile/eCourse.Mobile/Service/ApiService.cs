using eCourse.Models.Helpers;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eCourse.Mobile.Service
{
    public class ApiService
    {
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;


#if __ANDROID__
    private string _apiUrl = "http://10.0.2.2:62312/api";
#else
        private string _apiUrl = "http://localhost:62312/api";
#endif

        public ApiService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste authentificirani.", "OK");
                }
                else if (ex.Call.HttpStatus == System.Net.HttpStatusCode.RequestTimeout)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Problem sa konekcijom.", "OK");
                }
                else
                {
                    var err = await ex.GetResponseJsonAsync<ApiException>();
                    await Application.Current.MainPage.DisplayAlert("Greška", err.Message, "OK");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseJsonAsync<ApiException>();
                await Application.Current.MainPage.DisplayAlert("Greška", err.Message, "OK");
                throw;
            }

        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseJsonAsync<ApiException>();
                //var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                //var stringBuilder = new StringBuilder();
                //foreach (var error in errors)
                //{
                //    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                //}

                await Application.Current.MainPage.DisplayAlert("Greška", /*stringBuilder.ToString()*/err.Message, "OK");
                //return default(T);
                throw;
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var err = await ex.GetResponseJsonAsync<ApiException>();
                await Application.Current.MainPage.DisplayAlert("Greška", err.Message, "OK");
                throw;
            }
        }
    }
}
