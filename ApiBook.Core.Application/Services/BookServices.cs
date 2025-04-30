using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ApiBook.Core.Application.Interfaces;
using ApiBook.Core.Application.ViewModels;

namespace ApiBook.Core.Application.Services
{
    public class BookServices : IBookInterface
    {
        private readonly HttpClient _http;
        private readonly string _baseUrl;

        public BookServices(HttpClient http, IConfiguration config)
        {
            _http = http;
            _baseUrl = config["ExternalApiSettings:FakeRestApiBaseUrl"];
        }

        public async Task<IEnumerable<BookViewModels>> GetBooksAsync()
        {
            var resp = await _http.GetAsync($"{_baseUrl}/Books");
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<BookViewModels>>(json);
        }

        public async Task<BookViewModels> GetBookByIdAsync(int id)
        {
            var resp = await _http.GetAsync($"{_baseUrl}/Books/{id}");
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BookViewModels>(json);
        }

        public async Task<BookViewModels> CreateBookAsync(BookViewModels bookView)
        {
            var payload = JsonConvert.SerializeObject(bookView);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var resp = await _http.PostAsync($"{_baseUrl}/Books", content);
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BookViewModels>(json);
        }

        public async Task<BookViewModels> UpdateBookAsync(int id, BookViewModels bookView)
        {
            var payload = JsonConvert.SerializeObject(bookView);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var resp = await _http.PutAsync($"{_baseUrl}/Books/{id}", content);
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;
            resp.EnsureSuccessStatusCode();
            var json = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BookViewModels>(json);
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var resp = await _http.DeleteAsync($"{_baseUrl}/Books/{id}");
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
                return false;
            resp.EnsureSuccessStatusCode();
            return true;
        }

        
    }
}
