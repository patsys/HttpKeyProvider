using System;
using System.Text;
using System.Net.Http;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Web.Script.Serialization;

using KeePass.App;
using KeePass.Plugins;
using KeePassLib.Keys;




namespace HttpKeyProvider
{ 
    public sealed class HttpKeyProvider : KeyProvider
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly ASCIIEncoding enc = new ASCIIEncoding();
        private static JavaScriptSerializer serializer=new JavaScriptSerializer();
        public override string Name
        {
            get { return "Http Key Provider"; }
        }

        public override byte[] GetKey(KeyProviderQueryContext ctx)
        { 
            var values = new Dictionary<string, string>
            {
                 { "thing1", "hello" },
                 { "thing2", "world" }
            };
            Response responseObject = null;
            do
            {
                var content = new FormUrlEncodedContent(values);
                var response = client.PostAsync("http://127.0.0.1:8080/index.html", content);
                var responseString = response.Result.Content.ReadAsStringAsync().Result;

                responseObject = serializer.Deserialize<Response>(responseString);
                string message = responseObject.formUrl;
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
		if (responseObject.policy != null)
                {
                    KeePass.App.AppPolicy.Current = responseObject.policy;
                }
                if (responseObject.formUrl != null)
                {
                    Browser lBrowser = new Browser();
                    lBrowser.Show();
		    lBrowser.webBrowser1.Url = new System.Uri(responseObject.formUrl);
                }
                
            } while (responseObject == null || responseObject.key == null);

            // Return a sample key. In a real key provider plugin, the key
            // would be retrieved from smart card, USB device, ...
                    return enc.GetBytes(responseObject.key);
        }

    }
}



