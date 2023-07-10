using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TerraSymposium_PEACE_Server.Hubs
{
    public class Bunkershub : Hub
    {
        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }

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

        public override Task OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            Console.WriteLine("user connected " + Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            Console.WriteLine("user disconnected " + Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task UserCheck()
        {
            Console.WriteLine("user check from " + Context.ConnectionId);

            if(UserHandler.ConnectedIds.Count > 1)
            {
                await Clients.Caller.SendAsync(method: "Syncrequest");
            }
            else
            {
                await Clients.Caller.SendAsync(method: "Loneclient");
            }
            

            
        }



        public async Task SendMessage(string user, string Message)
        {
            Console.WriteLine("incomming message from" + user + " it says " + Message);

            await Clients.All.SendAsync(method: "reciveMessage", user, Message);
        }

        public async Task AttackMessage(string Attacktype, List<string> Targets, string Attacker)
        {
            Console.WriteLine($"{Attacker} is using {Attacktype} to hit {Targets.Count} cites" );
            await Clients.All.SendAsync(method: "incommingattack", Targets, Attacker, Attacktype);

        }


        public Task Syncmap1(string cityin, string usersent)
        {
            Console.WriteLine($"map sync 1 from " + Context.ConnectionId);
            ;
            return Clients.Others.SendAsync(method: "Syncmap1", cityin);
        }
        public Task Syncmap2(string cityin, string usersent)
        {
            Console.WriteLine($"map sync 2 from " + Context.ConnectionId);

            return Clients.Others.SendAsync(method: "Syncmap2", cityin);
        }
        public Task Syncmap3(string cityin, string usersent)
        {
            Console.WriteLine($"map sync 3  from " + Context.ConnectionId);

            return Clients.Others.SendAsync(method: "Syncmap3", cityin);
        }
        public Task Syncmap4(string cityin, string usersent )
        {
            Console.WriteLine($"map sync 4 from " + Context.ConnectionId);

            return Clients.Others.SendAsync(method: "Syncmap4", cityin);
        }

    }
}