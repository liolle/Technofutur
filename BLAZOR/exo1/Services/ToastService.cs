using System.Drawing;

namespace exo1.services;
public class ToastService
{
    public event Action<string, string,string, int> OnShow;
    public event Action OnHide;

    public void ShowToast(string message,string color, string type = "info", int dismissAfter = 3)
    {
        OnShow?.Invoke(message,color, type, dismissAfter);
    }

    public void HideToast()
    {
        OnHide?.Invoke();
    }

    public void ShowCustom (string message,string color, int dismissAfter = 3){
        ShowToast(message,color, "success", dismissAfter);
    }

    public void ShowSuccess(string message, int dismissAfter = 3) => ShowToast(message,"#28a745", "success", dismissAfter);
    public void ShowError(string message, int dismissAfter = 3) => ShowToast(message,"#dc3545", "failure", dismissAfter);
    public void ShowWarning(string message, int dismissAfter = 3) => ShowToast(message,"#ffc107", "warning", dismissAfter);
    public void ShowInfo(string message, int dismissAfter = 3) => ShowToast(message,"#ff8800", "info", dismissAfter);
    public void ShowAlert(string message, int dismissAfter = 3) => ShowToast(message,"#17a2b8", "alert", dismissAfter);
}