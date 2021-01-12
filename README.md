# UsingHangfireInASPNETCore_Demo

[Hangfire](https://www.hangfire.io/) provides a simple way to run background processes in our .NET applications. In this [Blazor Server](https://docs.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-5.0) based ASP.NET Core application, we’ll explore how executing background jobs in Hangfire can enhance the user experience of managing a custom task list where task items include a “schedule window” feature and other time-based elements. 

In this simple task list app, we support the following use cases:

1.	User can view list of saved tasks for a given day.
2.	Users can choose a date from a calendar.
3.	User can save a task with a date to associate it with a given day.
4.	User can save a task with a date and a “schedule window” to denote the time window in which a task should be completed.
5.	User gets a notification when the “schedule window” for a task begins and ends.
6.	User can mark tasks as completed.
7.	User can soft delete a task.

Note: If you’d like to run the sample, you’ll need to create a SQL Server database in localdb and apply the application’s migrations using database update. https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
