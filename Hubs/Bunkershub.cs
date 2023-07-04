using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TerraSymposium_PEACE_Server.Hubs
{
    public class Bunkershub : Hub
    {



        

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

    }
}