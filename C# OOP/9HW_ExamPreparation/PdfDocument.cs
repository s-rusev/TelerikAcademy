using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class PdfDocument : EncryptableBinaryDocument
    {
        public int? PagesCount { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.PagesCount = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.PagesCount));
        }
    }
}
