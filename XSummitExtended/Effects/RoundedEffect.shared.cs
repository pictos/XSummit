using System.Linq;
using Xamarin.Forms;

namespace XSummitExtended.Effects
{
	public class RoundedEffect : RoutingEffect
	{
		public RoundedEffect()
			: base("XSummitExtend.RoundedEffect")
		{

		}

		public static readonly BindableProperty CornerRadiusProperty =
		   BindableProperty.CreateAttached(
			   "CornerRadius",
			   typeof(int),
			   typeof(RoundedEffect),
			   10,
			   propertyChanged: OnCornerRadiusChanged);

		public static int GetCornerRadius(BindableObject view) =>
			(int)view.GetValue(CornerRadiusProperty);

		public static void SetCornerRadius(BindableObject view, int value) =>
			view.SetValue(CornerRadiusProperty, value);

		static void OnCornerRadiusChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (!(bindable is View view))
				return;

			var cornerRadius = (int)newValue;
			var effect = view.Effects.OfType<RoundedEffect>().FirstOrDefault();

			if (cornerRadius > 0 && effect == null)
				view.Effects.Add(new RoundedEffect());

			if (cornerRadius == 0 && effect != null)
				view.Effects.Remove(effect);
		}
	}
}
