using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace SampleHorse.Core.LINQ
{
    public class LinqSamples
    {
        private IEnumerable<Device> devices = new List<Device>()
        {
            new Device(3, "Noise"),
            new Device(4, "Vibration"),
            new Device(1, "Temperature"),
            new Device(5, "Flowspeed"),
            new Device(2, "Hummidity"),
        };


        public void DoSomething()
        {
            //Get only names from devices.
            IEnumerable<string> namesOnly = devices.Select(device => device.Name);
            List<string> namesOnlyList = devices.Select(device => device.Name).ToList();
            var namesOnlyArray = devices.Select(device => device.Name).ToArray();

            //Ordered list of devices
            var orderedList = devices.OrderBy(device => device.Name).ToList();
            var orderedList2 = devices
                .OrderByDescending(device => device.Name)
                .ThenBy(device => device.Id).ToList();

            //Last 2 items
            var last2ItemList = devices
                .OrderByDescending(device => device.Name)
                .Take(2).ToList();

            //2 items after 2.
            var first2ItemList = devices
                .OrderBy(device => device.Name)
                .Skip(2)
                .Take(2)
                .ToList();

            //Lookup
            Device d1 = devices.First(d => d.Id == 3);
            Device d2 = devices.FirstOrDefault(d => d.Id == 99); //Not exists

            //Collect
            var nameHasE = devices.Where(d => d.Name.Contains('e'));
            var nameHasEOrderedList = nameHasE.OrderBy(d => d.Name); //Link
            var finalList = nameHasEOrderedList.ToList(); //Two previous lines are executed here.

            //Intersect collections
            List<Device> otherList = new List<Device>()
            {
                new Device(2, "Hummidity"),
                new Device(4, "Vibration"),
            };
            var commonList = devices.Intersect(otherList);

            //....
        }

        public void DoSomethingWithAnonymousType()
        {
            //Var is variable. This var is not a simplification/replacement for a predefined type
            var anonymList = devices.Select(d =>
                new { NameWithId = $"{d.Id}-{d.Name}" }
            ).ToList();
        }

        public void DoSomethingWithJoin()
        {
            var owners = new List<Owner>()
            {
                new Owner() {Id = 1, Name = "Tom", DeviceId = 1},
                new Owner() {Id = 2, Name = "Mike", DeviceId = 3},
                new Owner() {Id = 3, Name = "Bill", DeviceId = 5},
            };

            //var is variable
            var joined = devices.Join(owners,
                device => device.Id,    //Outer list key selector 
                owner => owner.DeviceId,   //Inner list key selector
                    (device, owner) =>  //result selector
                    new
                    {
                        DeviceId = device.Id,
                        DeviceName = device.Name,
                        OwnerName = owner.Name
                    })
                .ToList();
            
            //Why impossible?: joined = joined.OrderBy(arg => arg.OwnerName);

            foreach (var anonType in joined.OrderBy(arg => arg.OwnerName))
            {
                Console.WriteLine("{0} owned by {1}", anonType.DeviceName, anonType.OwnerName);
            }
        }

        public void DoSomethingWithQuerySyntax()
        {
            var result = from d in devices
                         where d.Id > 1
                         orderby d.Name
                         select new { NameWithId = $"{d.Id}-{d.Name}" };

        }
    }


    internal class Device
    {
        public int Id { get; }
        public string Name { get; }

        public Device(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    internal class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DeviceId { get; set; }
    }
}
