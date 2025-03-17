using exo1.services;
using Microsoft.AspNetCore.Components;
namespace exo1.Pages.Toast;

public partial class Toast : ComponentBase
{

    [Inject]
    ToastService? ToastService {get;set;}
    private bool ShowMessage { get; set; } = false;
    private string MessageContent { get; set; } = string.Empty;
    private string MessageType { get; set; } = "success"; // default to success
    public int DismissAfter { get; set; } = 3;
    public string Col {get;set;} = "#28a745";

    private string MessageTypeClass => MessageType switch
    {
        "success" => "toast-message-success",
        "failure" => "toast-message-failure",
        "alert" => "toast-message-alert",
        "warning" => "toast-message-warning",
        _ => "toast-message-default"
    };


    protected override async Task OnParametersSetAsync()
    {
        if (ShowMessage && DismissAfter > 0)
        {
            await Task.Delay(DismissAfter * 1000);
            HideMessage();
        }
    }

    protected override void OnInitialized()
    {
        ToastService!.OnShow += ShowToast;
        ToastService.OnHide += HideMessage;
    }

    private async void ShowToast(string message,string color, string type, int dismissAfter)
    {
        MessageContent = message;
        MessageType = type;
        ShowMessage = true;
        Col = color;

        await InvokeAsync(StateHasChanged); // Ensure the UI updates

        if (dismissAfter > 0)
        {
            await Task.Delay(dismissAfter * 1000);
            HideMessage();
        }
    }

    private void HideMessage()
    {
        ShowMessage = false;
        InvokeAsync(StateHasChanged); // Ensure the UI updates
    }

    public void Dispose()
    {
        ToastService!.OnShow -= ShowToast;
        ToastService.OnHide -= HideMessage;
    }
}