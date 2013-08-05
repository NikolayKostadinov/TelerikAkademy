using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Musicstore.Data
{
    public static class SessionState
    {
        private static MusicstoreContext _db = new MusicstoreContext();
        public static MusicstoreContext db
        {
            get
            {
                return _db;
            }
        }

        public static HttpClient Client { get; private set; }

        //private static HttpClient _client = new HttpClient()
        //{
        //    BaseAddress = new Uri(Setting.Default.WebApi)
        //};
        //public static HttpClient Client
        //{
        //    get
        //    {
        //        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        return _client;
        //    }
        //}

        static SessionState()
        {
            Client = new HttpClient() { BaseAddress = new Uri(Setting.Default.WebApi) };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
