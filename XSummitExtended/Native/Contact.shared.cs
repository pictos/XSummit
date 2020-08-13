using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XSummitExtended.Native
{
	public static partial class Contact
	{
		public static Task SaveContactAsync(string name) =>
			PlatformSaveContactAsync(name);
	}
}
