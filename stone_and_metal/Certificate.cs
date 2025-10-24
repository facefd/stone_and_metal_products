using System;
using System.Windows.Forms;

namespace stone_and_metal
{
    public class Certificate
    {
        public void ShowAbout()
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        public void ShowHelp()
        {
            HelpForm help = new HelpForm();
            help.ShowDialog();
        }

        public void ShowDeveloperInfo()
        {
            DeveloperInfo devInfo = new DeveloperInfo();
            devInfo.ShowDialog();
        }
    }
}