using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gatherama.Shared;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Gatherama.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseEndpoint = "https://gatheramaapi.azurewebsites.net";
        //private readonly string _baseEndpoint = "https://localhost:5000";

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Set the BaseAddress
        }
        public List<PersonDto> persons { get; private set; }
        public List<PlaceDto> places { get; private set; }
        public List<FindingDto> findings { get; private set; }
        public List<FriendshipDto> friendships { get; private set; }
        public List<MediaDto> media { get; private set; }
        public List<SpeciesDto> species { get; private set; }
        //PERSONS
        #region 
        // GET all items
        public async Task<List<PersonDto>> GetPersonsAsync()
        {
            persons = await _httpClient.GetFromJsonAsync<List<PersonDto>>("api/Person");
            return persons;
            // Use _httpClient to fetch data
        }
        // GET item by ID
        public async Task<PersonDto> GetPersonByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/Person/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }
        // GET item by username and password
        public async Task<PersonDto> GetUserInfoByLogin(string username, string password)
        {
            var response = await _httpClient.GetAsync($"api/Person/{username}/{password}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON content to a PersonDto object
            return JsonConvert.DeserializeObject<PersonDto>(content);
        }
        // POST a new item
        public async Task<PersonDto> PostPersonAsync(PersonDto personDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Person/register/", personDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }
        // PUT (update) an item
        public async Task<PersonDto> PutPersonAsync(string id, PersonDto personDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Person/{id}", personDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PersonDto>();
        }

        // DELETE an item
        public async Task DeletePersonAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/Person/{id}");
            response.EnsureSuccessStatusCode();
        }
        #endregion
        //PLACES
        #region
        public async Task<List<PlaceDto>> GetPlacesAsync()
        {
            places = await _httpClient.GetFromJsonAsync<List<PlaceDto>>("api/Place");
            return places;
            // Use _httpClient to fetch data
        }
        // GET item by ID
        public async Task<PlaceDto> GetPlaceByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/Place/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PlaceDto>();
        }
        // POST a new item
        public async Task<PlaceDto> PostPlaceAsync(PlaceDto placeDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Place/", placeDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PlaceDto>();
        }
        // PUT (update) an item
        public async Task<PlaceDto> PutPlaceAsync(string id, PlaceDto placeDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Place/{id}", placeDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PlaceDto>();
        }

        // DELETE an item
        public async Task DeletePlaceAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/Place/{id}");
            response.EnsureSuccessStatusCode();
        }


        #endregion
        //FINDINGS
        #region
        public async Task<List<FindingDto>> GetFindingsAsync()
        {
            findings = await _httpClient.GetFromJsonAsync<List<FindingDto>>("api/Finding");
            return findings;
            // Use _httpClient to fetch data
        }
        // GET item by ID
        public async Task<FindingDto> GetFindingByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/Finding/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FindingDto>();
        }
        // POST a new item
        public async Task<FindingDto> PostFindingAsync(FindingDto findingDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Finding/", findingDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FindingDto>();
        }
        // PUT (update) an item
        public async Task<FindingDto> PutFindingAsync(string id, FindingDto findingDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Finding/{id}", findingDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FindingDto>();
        }

        // DELETE an item
        public async Task DeleteFindingAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/Finding/{id}");
            response.EnsureSuccessStatusCode();
        }
        #endregion
        //FRIENDSHIPS
        #region
        public async Task<List<FriendshipDto>> GetFriendshipsAsync()
        {
            friendships = await _httpClient.GetFromJsonAsync<List<FriendshipDto>>("api/Friendship");
            return friendships;
            // Use _httpClient to fetch data
        }
        // GET item by ID
        public async Task<FriendshipDto> GetFriendshipByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/Friendship/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FriendshipDto>();
        }
        // POST a new item
        public async Task<FriendshipDto> PostFriendshipAsync(FriendshipDto friendshipDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Friendship/", friendshipDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FriendshipDto>();
        }
        // PUT (update) an item
        public async Task<FriendshipDto> PutFriendshipAsync(string id, FriendshipDto friendshipDto)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/Friendship/" + id, friendshipDto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<FriendshipDto>();
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        // DELETE an item
        public async Task DeleteFriendshipAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/Friendship/{id}");
            response.EnsureSuccessStatusCode();
        }
        #endregion
        //MEDIA
        #region
        public async Task<List<MediaDto>> FetchMediasAsync()
        {
            media = await _httpClient.GetFromJsonAsync<List<MediaDto>>("api/Media");
            return media;
            // Use _httpClient to fetch data
        }
        // GET item by ID
        public async Task<MediaDto> GetMediaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MediaDto>();
        }
        // POST a new item
        public async Task<MediaDto> PostMediaAsync(MediaDto mediaDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseEndpoint, mediaDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MediaDto>();
        }
        // PUT (update) an item
        public async Task<MediaDto> PutMediaAsync(int id, MediaDto mediaDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseEndpoint}/{id}", mediaDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<MediaDto>();
        }

        // DELETE an item
        public async Task DeleteMediaAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseEndpoint}/{id}");
            response.EnsureSuccessStatusCode();
        }
        #endregion
        //SPECIES
        #region
        public async Task<List<SpeciesDto>> GetSpeciesAsync()
        {
            species = await _httpClient.GetFromJsonAsync<List<SpeciesDto>>("api/Species");
            return species;
            // Use _httpClient to fetch data
        }
        // GET item by ID
        public async Task<SpeciesDto> GetSpeciesByIdAsync(string id)
        {
            var response = await _httpClient.GetAsync($"api/Species/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SpeciesDto>();
        }
        // POST a new item
        public async Task<SpeciesDto> PostSpeciesAsync(SpeciesDto speciesDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Species/", speciesDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SpeciesDto>();
        }
        // PUT (update) an item
        public async Task<SpeciesDto> PutSpeciesAsync(string id, SpeciesDto speciesDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Species/{id}", speciesDto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SpeciesDto>();
        }

        // DELETE an item
        public async Task DeleteSpeciesAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"api/Species/{id}");
            response.EnsureSuccessStatusCode();
        }
        #endregion
    }
}
