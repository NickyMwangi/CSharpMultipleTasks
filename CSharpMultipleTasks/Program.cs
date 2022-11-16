
using CSharpMultipleTasks.MultipleTasks;
using System.Diagnostics;

/* TODO
 * Event with task.delay(1000) of 1 second it completes with 1.07secs
 * If we remove Task.Delay(1000) in ProcessCar it will take 0 seconds
 * this is because Task.WhenAll(tasks) executes all the tasks concurrently which drastically improves the performance
 */

var stopwatch = new Stopwatch();
stopwatch.Start();
Console.WriteLine($"Main Thread Started");
List<Cars> cars = Cars.GenerateCars(10, 'A');
Console.WriteLine($"Cars Generated : {cars.Count}");
/* TODO
 * with Task.WhenAll(tasks) and Task.Delay(1000) takes 1.06 seconds 
 * with Task.WhenAll(tasks) and without Task.Delay(1000) takes 0.001 seconds 
 * The Problem with is, It makes the main thred freeze for 8 seconds
 */
Cars.ProcessCarsWithTaskWhenAll(cars);


/* TODO
 * without Task.WhenAll(tasks) and Task.Delay(1000) takes 10.14 seconds 
 * without Task.WhenAll(tasks) and without Task.Delay(1000) takes 0.00 seconds 
 */
Cars.ProcessCarsWithoutTaskWhenAll(cars);


/*
 * with this main thread doesn't freeze anymore.
 *This reduces main thread execution time
 */
Cars.ProcessCarsOffLoad(cars);


Console.WriteLine($"Main Thread Completed");
stopwatch.Stop();
Console.WriteLine($"Main Thread Execution Time {stopwatch.ElapsedMilliseconds / 1000.0} Seconds");
Console.ReadKey();