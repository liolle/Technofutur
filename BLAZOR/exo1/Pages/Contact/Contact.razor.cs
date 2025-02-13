using Microsoft.AspNetCore.Components;
using exo1.models;
namespace exo1.Pages.Contact;

public partial class Contact : ComponentBase
{
    public ContactModel Model { get; set; } = new();


    private void SubmitValidFrom (){
        Console.WriteLine(Model.ToString());
    }
}