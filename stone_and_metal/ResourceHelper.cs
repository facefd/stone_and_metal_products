using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace stone_and_metal
{
    public static class ResourceHelper
    {
        public static string GetLogoPath() =>
            Path.Combine(Application.StartupPath, "LogoStoneAndMetal.png");

        public static Image LoadLogo() =>
            File.Exists(GetLogoPath()) ? Image.FromFile(GetLogoPath()) : null;

        public static string GetAppVersion() =>
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
    }
}