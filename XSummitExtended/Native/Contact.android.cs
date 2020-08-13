using Android.App;
using Android.Content;
using Android.Provider;
using System.Threading.Tasks;

namespace XSummitExtended.Native
{
	public static partial class Contact
	{
        public static Activity Activity { get; set; }

        static Task PlatformSaveContactAsync(string name)
        {
            using var intent = new Intent(Intent.ActionInsert);
            intent.SetType(ContactsContract.Contacts.ContentType);
            intent.PutExtra(ContactsContract.Intents.Insert.Name, name);
            Activity.StartActivity(intent);

            return Task.CompletedTask;
        }
    }
}
