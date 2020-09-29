using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamBookstoreApp.Mob.Models;
using XamBookstoreApp.Mob.Utilities;

namespace XamBookstoreApp.Mob.Services
{
    public class BookstoreService
    {
        private static BookstoreService _instance;

        public static BookstoreService Instance
        {
            get
            {
                return _instance ?? (_instance = new BookstoreService());
            }
        }

        public async Task<Result> GetBook()
        {
            var result = new Result() { DidSucceed = false };

            try
            {
                using (var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.BaseAPI}/{StaticDefinition.EndPoint}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(new HttpMethod("GET"), apiUri);

                    using (var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == HttpStatusCode.OK)
                        {
                            result.DidSucceed = true;
                            result.ResponseObject = JsonConvert.DeserializeObject<List<Book>>(resp.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public async Task<Result> GetBook(string id)
        {
            var result = new Result() { DidSucceed = false };

            try
            {
                using (var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.BaseAPI}/{StaticDefinition.EndPoint}/id:length(24)?id={id}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(new HttpMethod("GET"), apiUri);

                    using (var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == HttpStatusCode.OK)
                        {
                            result.DidSucceed = true;
                            result.ResponseObject = JsonConvert.DeserializeObject<Book>(resp.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<Result> SaveBook(Book book)
        {
            var result = new Result() { DidSucceed = false };

            try
            {
                using(var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.BaseAPI}/{StaticDefinition.EndPoint}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(new HttpMethod("POST"), apiUri);

                    request.Content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                    using(var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == HttpStatusCode.OK)
                        {
                            result.DidSucceed = true;
                            result.ResponseObject = JsonConvert.DeserializeObject<Book>(resp.Content.ReadAsStringAsync().Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<Result> UpdateBook(Book book)
        {
            var result = new Result() { DidSucceed = false };

            try
            {
                using (var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.BaseAPI}/{StaticDefinition.EndPoint}/id:length(24)?id={book.Id}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(new HttpMethod("PUT"), apiUri);

                    request.Content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                    using (var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == HttpStatusCode.OK)
                        {
                            result.DidSucceed = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public async Task<Result> DeleteBook(string id)
        {
            var result = new Result() { DidSucceed = false };

            try
            {
                using (var client = new HttpClient())
                {
                    var apiUri = $"{StaticDefinition.BaseAPI}/{StaticDefinition.EndPoint}/id:length(24)?id={id}";

                    client.BaseAddress = new Uri(apiUri);

                    var request = new HttpRequestMessage(new HttpMethod("DELETE"), apiUri);

                    using (var resp = await client.SendAsync(request))
                    {
                        if (resp.StatusCode == HttpStatusCode.OK)
                        {
                            result.DidSucceed = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
