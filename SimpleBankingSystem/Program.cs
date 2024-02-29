using Microsoft.Extensions.DependencyInjection;
using SimpleBankingSystem;

var serviceProvider = new ServiceCollection()
	.AddDbContext<ApplicationDbContext>()
	.AddTransient<Actions>()
	.AddTransient<SystemActions>()
	.BuildServiceProvider();


var action=serviceProvider.GetService<Actions>();
var SystemAction = serviceProvider.GetService<SystemActions>();

//add new users
SystemAction.CreateAccount(2234, "ahmed", 2000);
SystemAction.CreateAccount(2222, "mohamed");
SystemAction.CreateAccount(3333, "ali",2500);
SystemAction.CreateAccount(4444, "mona", 1000000);
SystemAction.CreateAccount(1222, "nada", 1655);

// Deposting
//Console.WriteLine(action.CheckBalance(3333));
//action.Deposting(3333, 1000);
//Console.WriteLine(action.CheckBalance(3333));

//Console.WriteLine(action.CheckBalance(4444));
//action.WithDrawing(4444, 655);
//Console.WriteLine(action.CheckBalance(4444));

SystemAction.DeleteAccount(2222);