using Android.Content;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XSummitExtended.Renderers;

[assembly:ExportRenderer(typeof(LabelExt), typeof(LabelR))]
namespace XSummitExtended.Renderers
{
	public class LabelR : LabelRenderer
	{
		public LabelR(Context context)
			: base(context)
		{

		}

		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control is { })
			{
				var label = (LabelExt)Element;
				Control.SetShadowLayer(label.ShadowRadius, 5, 5, Color.Red.ToAndroid());
			}
		}
	}
}
