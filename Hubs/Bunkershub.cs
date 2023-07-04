using Microsoft.AspNetCore.SignalR;

namespace BunkersV3.Hubs
{
    public class Bunkershub : Hub
    {



        

        public Task SendMessage(string user, string Message)
        {
            Console.WriteLine("incomming message from" + user);

            return Clients.All.SendAsync(method: "reciveMessage", user, Message);
        }

        public Task AttackMessage(string Attacktype, List<string> Targets, string Attacker)
        {
            Console.WriteLine("attack method running");
            return Clients.All.SendAsync(method: "incommingattack", Targets, Attacker, Attacktype);

        }

    }
}