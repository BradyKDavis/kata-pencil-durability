using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        public Pencil()
        {
        }

        public void Write(Paper paper, String text)
        {
            paper.Text = text;
        }
    }
}
