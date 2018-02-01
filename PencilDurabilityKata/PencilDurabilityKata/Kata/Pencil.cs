using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        private const int MAX_DURABILITY = int.MaxValue;
        private const char EMPTY = ' ';
        private const char NEWLINE = '\n';

        private int _initialDurability;
        private int _durability;

        public Pencil()
        {
            _durability = _initialDurability = MAX_DURABILITY;
        }

        public Pencil(int initialDurability)
        {
            _durability = _initialDurability = initialDurability;
        }

        public void Write(Paper paper, String text)
        {
            String appliedText = applyDurabilityToWriting(text);
            paper.Text = paper.Text + appliedText;
        }

        public void Sharpen()
        {
            _durability = _initialDurability;
        }

        private String applyDurabilityToWriting(String text)
        {
            char[] chars = text.ToCharArray();
            for (uint i = 0; i < chars.Length; i++)
            {
                if(chars[i] != EMPTY && chars[i] != NEWLINE)
                {
                    if (_durability <= 0)
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
