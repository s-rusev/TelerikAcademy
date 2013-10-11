namespace MusicStore.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:50672/") };

        internal static void Main()
        {
           
            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            //Console.WriteLine("Add artist:");
            //AddNewArtist("Pesho", new DateTime(2012, 12, 12), "Bulgaria");
            //Console.WriteLine("Removing artist: ");
            //RemoveArtist(20);
            //Console.WriteLine("Get artist:");
            //GetArtist(10);
            //Console.WriteLine("Update artist:");
            //UpdateArtist(27, "Penka", new DateTime(2011, 11, 12), "Brazil");

            /*
             * The GetAsync method sends an HTTP GET request. As the name implies, GetAsyc is asynchronous.
             * It returns immediately, without waiting for a response from the server.
             * The return value is a Task object that represents the asynchronous operation.
             * When the operation completes, the Task.Result property contains the HTTP response.
             */
            HttpResponseMessage response = Client.GetAsync("api/Artist").Result; // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                foreach (var a in artists)
                {
                    Console.WriteLine("{0,4} | {1,6} | {2} | {3}", a.ArtistId, a.Name, a.BirthDate, a.Country);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void AddNewArtist(string name, DateTime birthDate, string country)
        {
            var artist = new Artist() { Name = name, BirthDate = birthDate, Country = country };

            var response = Client.PostAsJsonAsync("api/Artist", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void RemoveArtist(int id)
        {
            var response = Client.DeleteAsync("api/Artist/"+ id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist removed!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void GetArtist(int id)
        {
            var response = Client.GetAsync("api/Artist/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist found!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        internal static void UpdateArtist(int id, string name, DateTime birthDate, string country)
        {
            Artist artist = new Artist() { Name = name, BirthDate = birthDate, Country = country };

            var response = Client.PutAsJsonAsync("api/Artist/" + id, artist).Result;
           
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist updated!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
