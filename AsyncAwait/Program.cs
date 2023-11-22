namespace AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Thread t1 = new Thread(new ThreadStart(Method1));
            //Thread t2 = new Thread(new ThreadStart(Method2));

            //t1.Start();
            //t2.Start();


            void Method1()
            {
                for (int i = 0;i<1000; i++)
                {
                    Console.WriteLine($"METHOD 1:{i}");
                }
            }
            async void Method2()
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine($"METHOD 2:{i}");
                }
            }
            await SimpleTask();
            File.WriteAllText(@"SomeFile.txt", "blah blah,blah");
            string contents=await ReadFile();
            Console.WriteLine(contents);
            async Task SimpleTask()
            {
                Console.WriteLine("Starting of the task");
                await Task.Delay(10000);
                Console.WriteLine("Task complete");
            }
            async Task<string> ReadFile()
            {
                using (StreamReader r = new StreamReader(@"SomeFile.txt"))
                {
                    return await r.ReadToEndAsync();
                }
            }
        }
    }
}