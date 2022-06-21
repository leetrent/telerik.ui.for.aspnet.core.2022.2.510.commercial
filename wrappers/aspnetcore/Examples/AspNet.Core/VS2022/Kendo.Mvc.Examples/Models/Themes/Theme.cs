namespace Kendo.Mvc.Examples.Models.Themes
{
    public class Theme
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string[] Palette { get; set; }

        public static Theme DefaultTheme
        {
            get
            {
                return new Theme
                {
                    Name = "default-ocean-blue",
                    Title = "Ocean Blue",
                    Icon = "eye",
                    Palette = new string[]
                    {
                        "#ffffff",
                        "#f5f5f5",
                        "#ff6358",
                        "#d6534a",
                        "#424242"
                    }
                };
            }
        }
    }
}
