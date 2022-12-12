namespace ScrollToLastItem
{
    internal class MessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MeTemplate { get; set; }
        public DataTemplate TheyTemplate { get; set; }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var ts = (Message)item;

            if(ts.FromMe)
                return MeTemplate;

            return TheyTemplate;
        }
    }
}
