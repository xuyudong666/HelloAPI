namespace HelloAPI
{
    public class UISetting
    {
        public string? FontFamily { get; set; }
        public int FontSize { get; set; }
        public EditorSetting  Editor { get; set; }
        public class EditorSetting
        {
            public string? Background { get; set; }
            public string? Foreground { get; set; }
        }
    }
}
