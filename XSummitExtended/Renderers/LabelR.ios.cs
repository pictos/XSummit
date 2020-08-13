using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XSummitExtended.Renderers;

[assembly: ExportRenderer(typeof(LabelExt), typeof(LabelR))]
namespace XSummitExtended.Renderers
{
	public class LabelR : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control is { })
			{
				var label = (LabelExt)Element;
				var layer = Control.Layer;
				layer.ShadowColor = Color.Red.ToCGColor();
				layer.ShadowOffset = new CGSize(5, 5);
				layer.ShadowOpacity = 1.0f;
				layer.ShadowRadius = label.ShadowRadius;
			}
		}
	}
}
