using Microsoft.Maui.Platform;
using WebView = Android.Webkit.WebView;

namespace AssistViewMAUI;

public class ContentSizedWebViewClient : MauiWebViewClient
{
    public ContentSizedWebViewClient(ContentSizedWebViewHandler handler) : base(handler)
    {
    }

    public override void OnPageFinished(WebView? view, string? url)
    {
        base.OnPageFinished(view, url);
        view.EvaluateJavascript(ContentSizeObserverBridge.InitializerScript, null);
    }
}