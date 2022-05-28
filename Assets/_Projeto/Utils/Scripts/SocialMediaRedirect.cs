using UnityEngine;

namespace com.Icypeak.Orbit.Utils
{
    public class SocialMediaRedirect : MonoBehaviour
    {
        public void RedirectToTwitter()
        {
            Application.OpenURL("https://twitter.com/icypeakstudio");
        }

        public void RedirectToWebsite()
        {
            Application.OpenURL("https://www.google.com.br/");
        }

        public void RedirectToPayment()
        {
            Application.OpenURL("https://www.picpay.com/site");
        }
    }
}