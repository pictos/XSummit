using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XSummitExtended.Renderers
{
	public class LabelExt : Xamarin.Forms.Label
	{

		public static readonly BindableProperty ShadowRadiusProperty =
			BindableProperty.Create(nameof(ShadowRadius),
						typeof(float),
						typeof(LabelExt),
						default(float));

		public float ShadowRadius { get => (float)GetValue(ShadowRadiusProperty); set => SetValue(ShadowRadiusProperty, value); }
	}
}
