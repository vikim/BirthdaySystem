namespace BirthdaySystem.Web.Infrastructure.Populators
{
    using System;
    using System.Web.Mvc;

    // http://stackoverflow.com/questions/5824124/html5-placeholders-with-net-mvc-3-razor-editorfor-extension
    public class PlaceHolderAttribute : Attribute, IMetadataAware
    {
        private readonly string _placeholder;

        public PlaceHolderAttribute(string placeholder)
        {
            _placeholder = placeholder;
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["placeholder"] = _placeholder;
        }
    }
}
