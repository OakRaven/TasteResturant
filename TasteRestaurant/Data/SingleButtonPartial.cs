namespace TasteRestaurant.Data
{
    public class SingleButtonPartial
    {
        public string ButtonType { get; set; }
        public string Page { get; set; }
        public string Glyph { get; set; }

        public int? Id { get; set; }

        public string ActionParameters
        {
            get => (Id != 0 && Id != null) ? Id.ToString() : null;
        }
    }
}