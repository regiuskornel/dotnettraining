using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleHorse.Core.Async
{
    public class AsyncSample
    {
        public void Logic()
        {
            var sw = Stopwatch.StartNew();

            var tasks = new List<Task>(); //Task is a base of generic Task<int> which is used
            tasks.Add(DoSomethingAsync(@"https://en.wikipedia.org/wiki/Main_Page#/media/File:Voyager.jpg"));

            tasks.Add(DoSomethingAsync(@"https://en.wikipedia.org/wiki/Main_Page#/media/File:Liquid_oxygen_in_a_beaker_(cropped_and_retouched).jpg"));

            tasks.Add(DoSomethingAsync(@"https://en.wikipedia.org/wiki/Artificial_intelligence#/media/File:Complex_systems_organizational_map.jpg"));

            sw.Stop();
            Console.WriteLine("Elapsed so far : {0} ms",sw.ElapsedMilliseconds);
            sw.Restart();

            //Wait all task to be completed
            Task.WaitAll(tasks.ToArray());

            sw.Stop();
            Console.WriteLine("Elapsed so far : {0} ms", sw.ElapsedMilliseconds);

        }

        private async Task<int> DoSomethingAsync(string url)
        {
            using (var webReq = new WebClient())
            {
                var uri = new Uri(url);
                var image1 = await webReq.DownloadDataTaskAsync(uri);
                return image1.Length;
            }
        }

        private void WithoutAsync()
        {

        }

        private Task<int> DoSomethingWoAsync(string url)
        {
            using (var webReq = new WebClient())
            {
                var uri = new Uri(url);
                Task<byte[]> imageTask =  webReq.DownloadDataTaskAsync(uri);
                Task<int> resultTask = imageTask.ContinueWith(task => task.Result.Length);
                return resultTask;
            }
        }
    }
}
