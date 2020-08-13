using CoreAnimation;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XSummitExtended.Effects;

//[assembly: ResolutionGroupName("XSummitExtend")]
[assembly: ExportEffect(typeof(RoundedEffectiOS), "RoundedEffect")]
namespace XSummitExtended.Effects
{
	public class RoundedEffectiOS : PlatformEffect
	{
		protected override void OnAttached()
		{
			try
			{
				PrepareContainer();
				SetCornerRadius();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		protected override void OnDetached()
		{
			try
			{
				Container.Layer.CornerRadius = new nfloat(0);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
			}
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			if (args.PropertyName == RoundedEffect.CornerRadiusProperty.PropertyName)
				SetCornerRadius();
		}

		private void PrepareContainer()
		{
			Container.ClipsToBounds = true;
			Container.Layer.AllowsEdgeAntialiasing = true;
			Container.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.All;
		}

		private void SetCornerRadius()
		{
			var cornerRadius = RoundedEffect.GetCornerRadius(Element);
			Container.Layer.CornerRadius = new nfloat(cornerRadius);
		}
	}
}
