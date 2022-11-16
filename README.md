# CSharpMultipleTasks
Executing Multple Tasks in C# using Task.WhenAll.

# What's Task.WhenAll Method
It;s a CSharp method that is used to run all the Tasks simultaneously, if tasks contain 10 entries, so, all these 10 tasks are to be executed simultaneously.

# Task.WhenAll using Task.Run
Task.Run is used to offload the current thread by unfeering the main thread.
As we wait for await Task.WhenAll() statement to be called the main method is frozen, when it get's called, the thread is active and starts procesing.
