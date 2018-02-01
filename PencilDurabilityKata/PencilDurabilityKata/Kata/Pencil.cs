using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        private const uint MAX_DURABILITY = uint.MaxValue;
        private char EMPTY = ' ';

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
            String appliedText = applyDurabilityToWriting(text);
            paper.Text = paper.Text + appliedText;
        }

        private String applyDurabilityToWriting(String text)
        {
            char[] chars = text.ToCharArray();
            for (uint i = 0; i < chars.Length; i++)
            {
                if(_durability == 0)
                {
                    chars[i] = EMPTY;
                }
                else if(chars[i] != EMPTY)
                {
                    _durability--;
                }
            }
            return new String(chars);
        }
    }
}
