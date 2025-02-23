namespace Presentation_ConsoleApp.Dialogs;

public class MainDialog(CustomerDialog customerDialog, ProjectDialog projectDialog)
{
    private readonly CustomerDialog _customerDialog = customerDialog;
    private readonly ProjectDialog _projectDialog = projectDialog;

    public async Task MenuOptions() 
    {
        while (true) 
        {
            Console.Clear();
            Console.WriteLine("1. Create New Customer");
            Console.WriteLine("2. Create New Project");
            Console.WriteLine("3. Get All Customers");
            Console.WriteLine("4. Get All Projects");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input) 
            {
                case "1":
                    await _customerDialog.CreateNewCustomer();
                    break;
                case "2":
                    await _projectDialog.CreateNewProject();
                    break;
                    case "3":
                    await _customerDialog.GetAllCustomers();
                    break;
                    case "4":
                    await _projectDialog.GetAllProjects();
                    break;
                    case "5":
                    Console.WriteLine("Exiting the program..");
                    return;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
