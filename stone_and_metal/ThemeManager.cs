using System;
using System.Drawing;
using System.Windows.Forms;

namespace stone_and_metal
{
    public static class ThemeManager
    {
        public static bool IsDarkMode { get; private set; } = false;

        // Цвета для тёмной темы
        private static readonly Color DarkBackColor = Color.FromArgb(30, 30, 30);
        private static readonly Color DarkForeColor = Color.White;
        private static readonly Color DarkMenuBackColor = Color.FromArgb(40, 40, 40);
        private static readonly Color DarkMenuForeColor = Color.White;
        private static readonly Color DarkSubMenuBackColor = Color.FromArgb(50, 50, 50);
        private static readonly Color DarkGridColor = Color.Gray;
        private static readonly Color DarkCellBackColor = Color.FromArgb(50, 50, 50);
        private static readonly Color DarkCellForeColor = Color.White;
        private static readonly Color DarkCellSelBackColor = Color.FromArgb(70, 70, 70);
        private static readonly Color DarkCellSelForeColor = Color.White;
        private static readonly Color DarkHeaderBackColor = Color.FromArgb(60, 60, 60);
        private static readonly Color DarkHeaderForeColor = Color.White;
        private static readonly Color DarkButtonBackColor = Color.FromArgb(60, 60, 60);
        private static readonly Color DarkButtonForeColor = Color.White;
        private static readonly Color DarkButtonBorderColor = Color.Gray;
        private static readonly Color DarkButtonHoverBackColor = Color.FromArgb(80, 80, 80);

        // Цвета для светлой темы
        private static readonly Color LightBackColor = SystemColors.Control;
        private static readonly Color LightForeColor = SystemColors.ControlText;
        private static readonly Color LightMenuBackColor = SystemColors.Menu;
        private static readonly Color LightMenuForeColor = SystemColors.MenuText;
        private static readonly Color LightSubMenuBackColor = SystemColors.Menu;
        private static readonly Color LightGridColor = SystemColors.Control;
        private static readonly Color LightCellBackColor = SystemColors.Window;
        private static readonly Color LightCellForeColor = SystemColors.ControlText;
        private static readonly Color LightCellSelBackColor = SystemColors.Highlight;
        private static readonly Color LightCellSelForeColor = SystemColors.HighlightText;
        private static readonly Color LightHeaderBackColor = SystemColors.Control;
        private static readonly Color LightHeaderForeColor = SystemColors.ControlText;
        private static readonly Color LightButtonBackColor = SystemColors.Control;
        private static readonly Color LightButtonForeColor = SystemColors.ControlText;
        private static readonly Color LightButtonBorderColor = SystemColors.ControlDark;
        private static readonly Color LightButtonHoverBackColor = SystemColors.ControlLight;

        public static void ToggleTheme(Form form, DataGridView dataGridView, Button button, MenuStrip menuStrip)
        {
            IsDarkMode = !IsDarkMode;
            ApplyTheme(form, dataGridView, button, menuStrip);
        }

        public static void ApplyTheme(Form form, DataGridView dataGridView, Button button, MenuStrip menuStrip)
        {
            var backColor = IsDarkMode ? DarkBackColor : LightBackColor;
            var foreColor = IsDarkMode ? DarkForeColor : LightForeColor;

            // Форма
            form.BackColor = backColor;
            form.ForeColor = foreColor;

            // Меню
            menuStrip.BackColor = IsDarkMode ? DarkMenuBackColor : LightMenuBackColor;
            menuStrip.ForeColor = IsDarkMode ? DarkMenuForeColor : LightMenuForeColor;
            foreach (ToolStripItem item in menuStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = IsDarkMode ? DarkMenuBackColor : LightMenuBackColor;
                    menuItem.ForeColor = IsDarkMode ? DarkMenuForeColor : LightMenuForeColor;
                    foreach (ToolStripItem subItem in menuItem.DropDownItems)
                    {
                        if (subItem is ToolStripMenuItem subMenuItem)
                        {
                            subMenuItem.BackColor = IsDarkMode ? DarkSubMenuBackColor : LightSubMenuBackColor;
                            subMenuItem.ForeColor = IsDarkMode ? DarkMenuForeColor : LightMenuForeColor;
                        }
                    }
                }
            }

            // Таблица
            dataGridView.BackgroundColor = IsDarkMode ? DarkCellBackColor : LightCellBackColor;
            dataGridView.GridColor = IsDarkMode ? DarkGridColor : LightGridColor;
            dataGridView.DefaultCellStyle.BackColor = IsDarkMode ? DarkCellBackColor : LightCellBackColor;
            dataGridView.DefaultCellStyle.ForeColor = IsDarkMode ? DarkCellForeColor : LightCellForeColor;
            dataGridView.DefaultCellStyle.SelectionBackColor = IsDarkMode ? DarkCellSelBackColor : LightCellSelBackColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = IsDarkMode ? DarkCellSelForeColor : LightCellSelForeColor;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = IsDarkMode ? DarkHeaderBackColor : LightHeaderBackColor;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = IsDarkMode ? DarkHeaderForeColor : LightHeaderForeColor;
            dataGridView.EnableHeadersVisualStyles = false; // Важно!

            // Кнопка
            button.BackColor = IsDarkMode ? DarkButtonBackColor : LightButtonBackColor;
            button.ForeColor = IsDarkMode ? DarkButtonForeColor : LightButtonForeColor;
            button.FlatAppearance.BorderColor = IsDarkMode ? DarkButtonBorderColor : LightButtonBorderColor;
            button.FlatAppearance.MouseOverBackColor = IsDarkMode ? DarkButtonHoverBackColor : LightButtonHoverBackColor;

            // Другие элементы можно добавить по аналогии
        }

        public static void ApplyCurrentTheme(Form form, DataGridView dataGridView, Button button, MenuStrip menuStrip)
        {
            ApplyTheme(form, dataGridView, button, menuStrip);
        }
    }
}