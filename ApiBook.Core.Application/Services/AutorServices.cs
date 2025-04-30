using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ApiBook.Core.Application.ViewModels;
using ApiBook.Core.Application.Interfaces;

public class AutorServices : IAutorInterface
{
    private readonly HttpClient _http;
    private readonly string _baseUrl;

    public AutorServices(HttpClient http, IConfiguration config)
    {
        _http = http;
        _baseUrl = config["ExternalApiSettings:FakeRestApiBaseUrl"];
    }

    public async Task<IEnumerable<AutorViewModels>> GetAuthorsAsync()
    {
        var resp = await _http.GetAsync($"{_baseUrl}/Authors");
        resp.EnsureSuccessStatusCode();
        var json = await resp.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<AutorViewModels>>(json);
    }

    public async Task<AutorViewModels> GetAuthorByIdAsync(int id)
    {
        var resp = await _http.GetAsync($"{_baseUrl}/Authors/{id}");
        if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;

        resp.EnsureSuccessStatusCode();
        var json = await resp.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AutorViewModels>(json);
    }

    public async Task<AutorViewModels> CreateAuthorAsync(AutorViewModels autorView)
    {
        var payload = JsonConvert.SerializeObject(autorView);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        var resp = await _http.PostAsync($"{_baseUrl}/Authors", content);
        resp.EnsureSuccessStatusCode();
        var json = await resp.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AutorViewModels>(json);
    }

    public async Task<AutorViewModels> UpdateAuthorAsync(int id, AutorViewModels autorView)
    {
        var payload = JsonConvert.SerializeObject(autorView);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");

        var resp = await _http.PutAsync($"{_baseUrl}/Authors/{id}", content);
        if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            return null;

        resp.EnsureSuccessStatusCode();
        var json = await resp.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AutorViewModels>(json);
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var resp = await _http.DeleteAsync($"{_baseUrl}/Authors/{id}");
        if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            return false;

        resp.EnsureSuccessStatusCode();
        return true;
    }
}
