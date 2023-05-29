using TasksApp;

var bankAccount = new BankAccount();

var tasksBankAccount = new Task[10];

for (int i = 0; i < tasksBankAccount.Length; i++)
{
    tasksBankAccount[i] = Task.Run(() =>
    {
        for (int j = 0; j < 10; j++)
        {
            bankAccount.Deposit(10);
            bankAccount.Withdraw(5);
        }
    });
}

Task.WaitAll(tasksBankAccount);

Console.WriteLine($"Final balance: {bankAccount.Balance}");

var counter = new ThreadSafeCounter();
var tasksThreadSafeCounter = new Task[10];

for (int i = 0; i < tasksThreadSafeCounter.Length; i++)
{
    tasksThreadSafeCounter[i] = Task.Run(() =>
    {
        for (int j = 0; j < 100; j++)
        {
            counter.Increment();
        }
    });
}

Task.WaitAll(tasksThreadSafeCounter);

Console.WriteLine($"Final count: {counter.Count}");
