using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorSpreadsheetComponent
{
    public class JsInterop
    {
        public static Task<string> Prompt(string message)
        {
            
            return JSRuntime.Current.InvokeAsync<string>(
                "BlazorSpreadsheetCompJsFunctions.showPrompt",
                message);
        }

        public static Task<string> Alert(string message)
        {
            
            return JSRuntime.Current.InvokeAsync<string>(
                "BlazorSpreadsheetCompJsFunctions.alert",
                message);
        }
    }
}
