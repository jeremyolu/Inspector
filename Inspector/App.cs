using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Inspector
{
    public class App
    {
        public async Task Run()
        {
            Console.WriteLine("Social Inspector v1.0: ");
            Console.WriteLine();
            Console.WriteLine("Developed by Jeremy Olu: ");
            Console.WriteLine("----------------------");
            Console.WriteLine();

            Console.WriteLine("Enter username to search: ");
            Console.WriteLine();
            
            string username = Console.ReadLine();
            Console.WriteLine();

            if (!string.IsNullOrEmpty(username))
            {
                Console.WriteLine($"searching social network accounts for {username}...");
                Console.WriteLine();

                var socialNetworks = GetSocialNetworks(username);

                var results = new Dictionary<string, string>();

                await FindSocialNetworkAccounts(username, socialNetworks, results);
            }
            else
            {
                Console.WriteLine("No username provided");
            }
        }

        private List<SocialNetwork> GetSocialNetworks(string username)
        {
            return new List<SocialNetwork>
            {
                new SocialNetwork { Name = "Twitter", Url = $"https://twitter.com/{username}" },
                new SocialNetwork { Name = "Instagram", Url = $"https://instagram.com/{username}" },
                new SocialNetwork { Name = "Tiktok", Url = $"https://www.tiktok.com/@{username}" },
                new SocialNetwork { Name = "Pinterest", Url = $"https://www.pinterest.com/{username}" },
                new SocialNetwork { Name = "Snapchat", Url = $"https://www.snapchat.com/add/{username}" },
                new SocialNetwork { Name = "Clubhouse", Url = $"https://www.clubhouse.com/@{username}" },
                new SocialNetwork { Name = "Youtube", Url = $"https://www.youtube.com/{username}" },
                new SocialNetwork { Name = "CashApp", Url = $"https://cash.app/{username}" }
            };
        }

        private async Task<bool> AccountExist(string accountUrl)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(accountUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        private async Task FindSocialNetworkAccounts(string username, List<SocialNetwork> socialNetworks, Dictionary<string, string> results)
        {
            foreach (var social in socialNetworks)
            {
                var result = await AccountExist(social.Url);

                if (result)
                {
                    results.Add(social.Name, social.Url);
                }
            }

            Console.WriteLine("Results: ");
            Console.WriteLine();

            if (results.Count > 0)
            {
                Console.WriteLine($"Inspector found {results.Count} accounts with the specified username: {username}");
                Console.WriteLine();

                foreach (var account in results.OrderBy(r => r.Key))
                {
                    Console.WriteLine($"{account.Key} - {account.Value}");
                }
            }
            else
            {
                Console.WriteLine($"No results found for: {username}");
            }
        }
    }
}
