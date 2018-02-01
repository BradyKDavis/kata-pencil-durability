using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        private const int MAX = int.MaxValue;
        private const char EMPTY = ' ';
        private const char NEWLINE = '\n';

        private int _initialDurability;
        private int _durability;

        private int _length;

        public Pencil()
        {
            _durability = _initialDurability = MAX;
            _length = MAX;
        }

        public Pencil(int initialDurability)
        {
            _durability = _initialDurability = initialDurability;
            _length = MAX;
        }

        public Pencil(int initialDurability, int length)
        {
            _durability = _initialDurability = initialDurability;
            _length = length;
        }

        public void Write(Paper paper, String text)
        {
            String appliedText = applyDurabilityToWriting(text);
            paper.Text = paper.Text + appliedText;
        }

        public void Sharpen()
        {
            if(_length > 0)
            {
                _length--;
                _durability = _initialDurability;
            }


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
