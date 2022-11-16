using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMultipleTasks.MultipleTasks
{
    public class Cars
    {
        public string Registration_No { get; set; } = string.Empty;
        public string Chasis_No { get; set; } = string.Empty;
        public string Make { get; set; } = string.Empty;

        public static List<Cars> GenerateCars(int number, char val)
        {
            List<Cars> cars = new List<Cars>();
            for (int n = 0; n < number; n++)
            {
                val++;
                Cars car = new Cars()
                {
                    Registration_No = string.Concat("KCY", number,n, val),
                    Chasis_No = string.Concat("NSP-OOK",n, val, "-", number),
                    Make = "Volkswagen"
                };
                cars.Add(car);
            }
            return cars;
        }

        /* TODO 
         * Process each car 
         */
        public static async Task<string> ProcessCar(Cars car)
        {
            //Delaying execution for 1 Sec to help test task.whenAll
            await Task.Delay(1000);
            string message = $"Car Number: {car.Registration_No} Make: {car.Make} Processed";
            //Console.WriteLine($"Car Number: {car.Registration_No} Processed");
            return message;
        }

        /* TODO 
         * Execute the Multiple tasks concurrrently with 
         * foreach
         * await Task.WhenAll(tasks): Tells there is a list of tasks and should wait until all tasks are done before continuing. 
         * await Task.WhenAll(tasks): Enables all tasks to be run simultaneously.
         * A problem with this is So, until the await Task.WhenAll(tasks) statement is called, our Main thread is frozen.
         * As soon as we called await Task.WhenAll(tasks) method, the thread is active and starts processing.
         */
        public static async void ProcessCarsWithTaskWhenAll(List<Cars> cars)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new List<Task<string>>();
            foreach (var car in cars)
            {
                var response = ProcessCar(car);
                tasks.Add(response);
            }

            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Processing with TaskWhenAll of {cars.Count} Car Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }


        /* TODO 
         * Normal methos Task.WhenAll();
         */
        public static async void ProcessCarsWithoutTaskWhenAll(List<Cars> cars)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new List<Task<string>>();
            foreach (var car in cars)
            {
                var response = await ProcessCar(car);
            }
            stopwatch.Stop();
            Console.WriteLine($"Processing without TaskWhenAll of {cars.Count} Car Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }

        /* TODO
         * Offloading the Current Thread
         * don’t want our Main thread to freeze for 8 seconds
         * offload the foreach loop to another thread by using the Task.Run Asynchronous Method in C#
         * 
         */
        public static async void ProcessCarsOffLoad(List<Cars> cars)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new List<Task<string>>();

            await Task.Run(() =>
            {
                foreach (var car in cars)
                {
                    var response = ProcessCar(car);
                    tasks.Add(response);
                }
            });
            //It will execute all the tasks concurrently
            await Task.WhenAll(tasks);
            stopwatch.Stop();
            Console.WriteLine($"Processing with Task.Run of {cars.Count} Car Done in {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
        }
    }
}
