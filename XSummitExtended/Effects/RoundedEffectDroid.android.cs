using Android.Graphics;
using Android.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XSummitExtended.Effects;

//[assembly: ResolutionGroupName("XSummitExtend")]
[assembly: ExportEffect(typeof(RoundedEffectDroid), "RoundedEffect")]

namespace XSummitExtended.Effects
{
	class RoundedEffectDroid : PlatformEffect
	{
		private Android.Views.View View => Control ?? Container;

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
				View.OutlineProvider = ViewOutlineProvider.Background;
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
			View.ClipToOutline = true;
		}

		private void SetCornerRadius()
		{
			var cornerRadius = RoundedEffect.GetCornerRadius(Element) * GetDensity();
			View.OutlineProvider = new RoundedOutlineProvider(cornerRadius);
		}

		private static double GetDensity() =>
			DeviceDisplay.MainDisplayInfo.Density;

		private class RoundedOutlineProvider : ViewOutlineProvider
		{
			private readonly double _radius;

			public RoundedOutlineProvider(double radius)
			{
				_radius = radius;
			}

			public override void GetOutline(Android.Views.View view, Outline outline)
			{
				outline?.SetRoundRect(0, 0, view.Width, view.Height, (float)_radius);
			}
		}
	}
}
