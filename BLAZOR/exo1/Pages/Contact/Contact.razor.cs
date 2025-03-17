using Microsoft.AspNetCore.Components;
using exo1.models;
using exo1.services;
namespace exo1.Pages.Contact;


public partial class Contact : ComponentBase
{
    public ContactModel Model { get; set; } = new();

    [Inject]
    ToastService Toast {get;set;}

    private void SubmitValidFrom (){
        Toast.ShowCustom($"Hello {Model.Nom}",Model.Color);
    }
}