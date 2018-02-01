using System;
namespace PencilDurabilityKata.Kata
{
    public class Paper
    {
        public String Text { get; set; }

        public Paper()
        {
            Text = "";
        }

        public Paper(String initialText)
        {
            Text = initialText;
        }
    }
}
