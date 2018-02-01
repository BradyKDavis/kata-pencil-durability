using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        private const uint MAX_DURABILITY = uint.MaxValue;

        private uint _durability;

        public Pencil()
        {
            _durability = MAX_DURABILITY;
        }

        public Pencil(uint initialDurability)
        {
            _durability = initialDurability;
        }

        public void Write(Paper paper, String text)
        {
            paper.Text = paper.Text + text;
        }
    }
}
