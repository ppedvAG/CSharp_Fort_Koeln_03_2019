using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsTasksAsyncAwait
{
    class Program
    {
        static string _sieger = string.Empty;
        static CancellationTokenSource _cts;


        static void Main(string[] args)
        {
            List<Action> methods = new List<Action>()
            {
                //EinfachenThread,
                //ThreadsWettrennen,
                //ThreadsWettrennen,
                //ThreadsWettrennen,
                //ThreadsWettrennen,
                //ThreadsWettrennen,
                //ThreadCanceln,
                //ThreadsWettrennenMitTasks,
                AsyncAwait
            };

            foreach (var item in methods)
            {
                Console.WriteLine($"{item.Method.Name} wird ausgeführt---------------");
                item.Invoke();
            }

            Console.WriteLine("Main-Thread wartet auf Beendigung");
            Console.ReadKey();
            Console.WriteLine("Main-Thread ist fertig");
        }

        private static void AsyncAwait()
        {
            List<string> urls = new List<string>()
            {
                "http://www.zeit.de",
                "http://www.google.de",
                "http://www.asijdiasjdiasjdijasidjasidjaisjdi.de",
                "http://www.goggle.de",
                "http://www.youtube.de",
                "http://www.zeit.de",
                "http://www.zeit.de",
                "http://www.zeit.de",
                "http://www.zeit.de"
            };

            int fertigeSeiten = 0;

            List<Task> tasks = new List<Task>();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (var url in urls)
            {
                tasks.Add(CheckWebsite(url, () => Console.WriteLine($"Fertigen Seiten: {++fertigeSeiten}")));
            }

            Task.WaitAll(tasks.ToArray());

            watch.Stop();

            Console.WriteLine($"Gesamtzeit: {watch.ElapsedMilliseconds}");
        }

        private async static Task CheckWebsite(string url, Action finishCallback = null)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            HttpClient client = new HttpClient();
            try
            {
                //ab await wird in einem parallelen Thread auf das Ergebnis gewartet
                string result = await client.GetStringAsync(url);
                watch.Stop();
                Console.WriteLine($"{url} hat {watch.ElapsedMilliseconds} gebraucht");
                finishCallback?.Invoke();
            }
            catch (Exception)
            {
                Console.WriteLine($"{url} geht nicht!");
                finishCallback?.Invoke();
            }
        }

        private static void ThreadsWettrennenMitTasks()
        {
            Task<string> schuhmacher = new Task<string>(() =>
            {
                MacheEtwasAufwändiges("Schuhmacher", 10, 50, false);
                return "Schuhmacher";
            });
            Task<string> häkkinen = new Task<string>(() =>
            {
                MacheEtwasAufwändiges("Häkkinen", 10, 50, false);
                return "Häkkinen";
            });

            schuhmacher.Start();
            häkkinen.Start();


            Task<string>[] rennfahrer = new Task<string>[] { schuhmacher, häkkinen };

            foreach (var einRennfahrer in rennfahrer)
            {
                einRennfahrer.ContinueWith(t => Console.WriteLine($"{t.Result} ist im Ziel!"));
            }

            int siegerIndex = Task.WaitAny(rennfahrer);

            Console.WriteLine($"Sieger {rennfahrer[siegerIndex].Result}");

        }

        private static void ThreadCanceln()
        {
            _cts = new CancellationTokenSource();
            Thread gericht = new Thread(() => MacheEtwasAufwändiges("Gericht", 10, 1000, true, _cts.Token));
            gericht.Start();


            Console.WriteLine("Möchten Sie den Prozess abbrechen?");
            Console.ReadKey();
            //gericht.Abort();
            _cts.CancelAfter(100);
        }

        private static void ThreadsWettrennen()
        {
            _sieger = string.Empty;

            Thread schuhmacher = new Thread(() => MacheEtwasAufwändiges("Schuhmacher", 10, 50, false));
            Thread häkkinen = new Thread(() => MacheEtwasAufwändiges("Häkkinen", 10, 50, false));

            //häkkinen.Priority = ThreadPriority.Lowest;
            //schuhmacher.Priority = ThreadPriority.Highest;
            häkkinen.Start();
            schuhmacher.Start();



            Console.WriteLine("Rennen gestartet");

            häkkinen.Join();
            schuhmacher.Join();

            Console.WriteLine($"Sieger war {_sieger}");
        }

        private static void EinfachenThread()
        {
            Thread t1 = new Thread(() => { MacheEtwasAufwändiges("Thread1", 10, 300); });
            //Threads laufen standardmäßig im Vordergrund
            t1.IsBackground = true;
            t1.Start();

            Console.WriteLine("Thread wurde gestartet");
        }

        private static void MacheEtwasAufwändiges(string name, int steps, int stepTime, bool verbose = true, CancellationToken token = default(CancellationToken))
        {
            for (int i = 0; i < steps; i++)
            {
                Thread.Sleep(stepTime);
                //interpolated Strings
                if (verbose)
                    Console.WriteLine($"{name}: Step {i + 1} done!");
                if (token != default && token.IsCancellationRequested)
                {
                    Console.WriteLine("OK, ich hör ja auf!");
                    return;
                }
            }


            if (verbose)
                Console.WriteLine($"{name} fertig!");

            lock (_sieger)
            {

                if (_sieger == string.Empty)
                {
                    _sieger = name;
                }
            }
        }
    }

}
