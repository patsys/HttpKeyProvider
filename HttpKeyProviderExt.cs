using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using KeePass.Plugins;
using KeePassLib.Keys;
using KeePassLib.Utility;
using KeePassLib.Serialization;
using KeePass.UI;
namespace HttpKeyProvider
{
    public sealed class HttpKeyProviderExt : Plugin
    {
        private IPluginHost m_host = null;
        private HttpKeyProvider m_prov = new HttpKeyProvider();
        private ToolStripSeparator m_tsSeparator = null;
        private ToolStripMenuItem m_tsmiMenuItem = null;

        public override bool Initialize(IPluginHost host)
        {
            m_host = host;

            m_host.KeyProviderPool.Add(m_prov);
            ToolStripItemCollection tsMenu = m_host.MainWindow.ToolsMenu.DropDownItems;



            // Add a separator at the bottom

            m_tsSeparator = new ToolStripSeparator();

            tsMenu.Add(m_tsSeparator);



            // Add menu item 'Do Something'

            m_tsmiMenuItem = new ToolStripMenuItem();

            m_tsmiMenuItem.Text = "HttpKeyProvider settings";

            m_tsmiMenuItem.Click += this.OnMenuDoSomething;

            tsMenu.Add(m_tsmiMenuItem);
            return true;
        }

         private void OnMenuDoSomething(object sender, EventArgs e)

        {
            HttpKeyProviderForm form = new HttpKeyProviderForm();
            form.Show();
            //HttpKeyProviderUIForm form = new HttpKeyProviderUIForm();
            //form.Show();

        }

        public override void Terminate()
        {
            m_host.KeyProviderPool.Remove(m_prov);
        }
    }
}