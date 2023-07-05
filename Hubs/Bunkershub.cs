using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TerraSymposium_PEACE_Server.Hubs
{
    public class Bunkershub : Hub
    {

        [JsonObject]
        public class city
        {
            [JsonProperty("name")] public string name;
            [JsonProperty("x")] public int x;
            [JsonProperty("y")] public int y;
            [JsonProperty("owner")] public string owner;
            [JsonProperty("ID")] public int ID;
            [JsonProperty("Uid")] public int Uid;
        }

        public class citytosend
        {
            [JsonProperty("name")] public string name;
            [JsonProperty("ID")] public int ID;
            [JsonProperty("owner")] public string owner;
        }




        public async Task SendMessage(string user, string Message)
        {
            Console.WriteLine("incomming message from" + user);

            await Clients.All.SendAsync(method: "reciveMessage", user, Message);
        }

        public async Task AttackMessage(string Attacktype, List<string> Targets, string Attacker)
        {
            Console.WriteLine("attack method running");
            await Clients.All.SendAsync(method: "incommingattack", Targets, Attacker, Attacktype);

        }


        public Task Syncmap1(string cityin, string usersent)
        {
            Console.WriteLine($"map sync request from {usersent}");
            ;
            return Clients.Others.SendAsync(method: "Syncmap1", cityin);
        }
        public Task Syncmap2(string cityin, string usersent)
        {
            Console.WriteLine($"map sync request from {usersent}");

            return Clients.Others.SendAsync(method: "Syncmap2", cityin);
        }
        public Task Syncmap3(string cityin, string usersent)
        {
            Console.WriteLine($"map sync request from {usersent}");

            return Clients.Others.SendAsync(method: "Syncmap3", cityin);
        }
        public Task Syncmap4(string cityin, string usersent)
        {
            Console.WriteLine($"map sync request from {usersent}");

            return Clients.Others.SendAsync(method: "Syncmap4", cityin);
        }

    }
}