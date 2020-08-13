using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XSummit
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		void Button_Clicked(object sender, EventArgs e)
		{
			XSummitExtended.Native.Contact.SaveContactAsync("XEssentials");
		}
	}
}
