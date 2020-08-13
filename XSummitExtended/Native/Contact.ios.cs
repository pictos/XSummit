using Contacts;
using ContactsUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Essentials;

namespace XSummitExtended.Native
{
	public static partial class Contact
	{
		static Task PlatformSaveContactAsync(string name)
		{
            var uiView = Platform.GetCurrentUIViewController();

            if (uiView == null)
                throw new ArgumentNullException($"The View Controller can't be null.");

            using var contact = new CNMutableContact();

            if (!string.IsNullOrEmpty(name))
            {
                var nameSplit = name.Split(' ');
                contact.GivenName = nameSplit[0];
                contact.FamilyName = nameSplit.Length > 1 ? nameSplit[^1] : " ";
            }


            try
            {
                using var view = CNContactViewController.FromNewContact(contact);
                view.Delegate = new ContactSaveDelegate();
                using var nav = new UINavigationController(view);
                uiView.PresentModalViewController(nav, true);

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromException(ex);
            }
        }
	}

    class ContactSaveDelegate : CNContactViewControllerDelegate
    {
        public ContactSaveDelegate()
        {
        }

        public ContactSaveDelegate(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidComplete(CNContactViewController viewController, CNContact contact)
        {
            viewController.DismissModalViewController(true);
        }
    }
}
