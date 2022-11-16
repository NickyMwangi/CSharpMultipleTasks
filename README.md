# CSharpMultipleTasks
Executing Multple Tasks in C# using Task.WhenAll.

# What's Task.WhenAll Method
It;s a CSharp method that is used to run all the Tasks simultaneously, if tasks contain 10 entries, so, all these 10 tasks are to be executed simultaneously.

# Task.WhenAll using Task.Run
Task.Run is used to offload the current thread by unfeering the main thread.
As we wait for await Task.WhenAll() statement to be called the main method is frozen, when it get's called, the thread is active and starts procesing.


# What to expect
I have created three methods as follows to show and explain task.whenall with multple tasks. You can increase the number of cars to process in the generateCars method
Initiate the mumber of cars to generate. \
List<Cars> cars = Cars.GenerateCars(10, 'A');\
# TODO
 * with Task.WhenAll(tasks) and Task.Delay(1000) takes 1.06 seconds 
 * with Task.WhenAll(tasks) and without Task.Delay(1000) takes 0.001 seconds 
 * The Problem with is, It makes the main thred freeze for 8 seconds
 \
Cars.ProcessCarsWithTaskWhenAll(cars);

## TODO
 * without Task.WhenAll(tasks) and Task.Delay(1000) takes 10.14 seconds 
 * without Task.WhenAll(tasks) and without Task.Delay(1000) takes 0.00 seconds 
 \
Cars.ProcessCarsWithoutTaskWhenAll(cars);

## TODO
 * with this main thread doesn't freeze anymore.
 *This reduces main thread execution time
 \
Cars.ProcessCarsOffLoad(cars);
