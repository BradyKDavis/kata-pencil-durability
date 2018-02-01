using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        private const uint MAX_DURABILITY = uint.MaxValue;
        private const char EMPTY = ' ';
        private const char NEWLINE = '\n';

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
                if(chars[i] != EMPTY && chars[i] != NEWLINE)
                {
                    if (_durability == 0)
                    {
                        chars[i] = EMPTY;
                    }
                    else if(Char.IsUpper(chars[i]))
                    {
                        _durability -= 2;
                    }
                    else
                    {
                        _durability--;
                    }
                }
            }
            return new String(chars);
        }
    }
}
