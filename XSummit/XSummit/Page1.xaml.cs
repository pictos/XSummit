using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XSummit
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		ObservableCollection<string> Names { get; } = new ObservableCollection<string>();

		public Page1()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			var http = new HttpClient();

			var r = await http.GetStringAsync("https://inumeraveis.com.br/");

			var frase = r.Split(new string[] { "<a href" }, StringSplitOptions.None).ToList();
			frase.RemoveAt(0);
			frase.RemoveAt(0);
			foreach (var item in frase)
			{
				var index = item.IndexOf("\n");
				var p = item.Substring(index).Replace("\n", "");
				p = p.Replace("<\a>", "");
				Names.Add(p);
			}
			cv.ItemsSource = Names;
		}

		public static string StripHTML(string input)
		{
			return Regex.Replace(input, "<.*?>", String.Empty);
		}

		void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			XSummitExtended.Native.Contact.SaveContactAsync("XSummit");
		}
	}
}