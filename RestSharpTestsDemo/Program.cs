using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;

var client = new RestClient("https://api.github.com");


//var request = new RestRequest("/repos/{user}/{repos}/issues");
var request = new RestRequest("/users/{user}/repos");

// add user KirilDechevPetkov
request.AddUrlSegment("user", "KirilDechevPetkov");
// Automation_NUnit_Summator
request.AddUrlSegment("repos", "Automation_NUnit_Summator");

var responce = await client.ExecuteAsync(request);

var repos = JsonSerializer.Deserialize<List<Repo>>(responce.Content);

foreach (var repo in repos)
{
    Console.WriteLine("REPORT FULL NAME: " + repo.full_name);
}    

System.Console.WriteLine("STATUS CODE: " + responce.StatusCode);
System.Console.WriteLine("BODY: " + responce.Content);