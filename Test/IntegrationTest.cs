using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;
using Gatherama.Shared;
using Gatherama.Services;
using System.Net.Http;
using System.Net.Http.Json;

namespace Gatherama.Test;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests
{
    private ApiService apiService;
    private PersonDto person;
    private PersonDto personToDelete;
    private readonly string _baseEndpoint = "https://gatheramaapi.azurewebsites.net";


    [SetUp]

    public async Task SetupAsync()
    {
        var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(_baseEndpoint);
        apiService = new ApiService(httpClient);
        person = new PersonDto();
        personToDelete = new PersonDto();

        person.firstName = "Erkki";
        person.lastName = "Esimerkki";
        person.username = "Eke";
        person.email = "EkeOnEsimerkki@gmail.com";
        person.password = "Erkki";

        var response = await apiService.PostPersonAsync(person);
        var responseForDelete = await apiService.GetUserInfoByLogin(person.username, person.password);

        person.Id = response.Id;
        personToDelete.Id = responseForDelete.Id;


    }

    [TearDown]

    public async Task TearDownAsync()
    {
        await apiService.DeletePersonAsync((personToDelete.Id));
    }

    [Test]
    public async Task Person_Register_Should_Create_All_PersonInfoAsync()
    {
        
        //var originalBaseAddress = httpClient.BaseAddress;
       
        Assert.NotNull(apiService);

        // getting the user which we setuped 
        var userinfo = await apiService.GetUserInfoByLogin(person.username, person.password);

        
        // Checking if the registeration went trough and data matches sended
        Assert.That(person.firstName, Is.EqualTo(userinfo.firstName));
        Assert.That(person.lastName, Is.EqualTo(userinfo.lastName));
        Assert.That(person.username, Is.EqualTo(userinfo.username));    
        Assert.That(person.email, Is.EqualTo(userinfo.email));
        Assert.That(person.password, Is.EqualTo(userinfo.password));

    }

    [Test]

    public async Task Person_Login_Should_Return_Success_AND_LoginState_Should_Be_True()
    { 
        var httpClient = new HttpClient();
        var loginState = new LoginState();
        httpClient.BaseAddress = new Uri(_baseEndpoint);

        var httpResponse = await httpClient.PostAsJsonAsync("api/Person/login", person);

        Assert.That(httpResponse.IsSuccessStatusCode);

        var userinfo = await apiService.GetUserInfoByLogin(person.username, person.password);
        loginState.SetLogin(true, userinfo);

        Assert.True(loginState.hasLoggedin);
        Assert.That(loginState.isSingedin.Id, Is.EqualTo(person.Id));



    }
}