using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        private const int MAX = int.MaxValue;
        private const String NEGATIVE_DURABILITY_MESSAGE = "Cannot initialize pencil with negative durability.";
        private const String NEGATIVE_LENGTH_MESSAGE = "Cannot initialize pencil with negative length.";
        private const String NEGATIVE_ERASER_DURABILITY_MESSAGE = "Cannot initialize pencil with negative durability.";

        private const char EMPTY = ' ';
        private const char NEWLINE = '\n';

        private int _initialDurability;
        private int _pointDurability;
        private int _length;
        private int _eraserDurability;

        public Pencil()
        {
            _pointDurability = _initialDurability = MAX;
            _length = MAX;
            _eraserDurability = MAX;
        }

        public Pencil(int initialDurability)
        {
            checkInitialDurabilityValid(initialDurability);
            _pointDurability = _initialDurability = initialDurability;
            _length = MAX;
            _eraserDurability = MAX;
        }

        public Pencil(int initialDurability, int length)
        {
            checkInitialDurabilityValid(initialDurability);
            checkInitialLengthValid(length);
            _pointDurability = _initialDurability = initialDurability;
            _length = length;
            _eraserDurability = MAX;
        }

        public Pencil(int initialDurability, int length, int eraserDurability)
        {
            checkInitialDurabilityValid(initialDurability);
            checkInitialLengthValid(length);
            if(eraserDurability <= 0)
            {
                throw new ArgumentException(NEGATIVE_ERASER_DURABILITY_MESSAGE);
            }
            _pointDurability = _initialDurability = initialDurability;
            _length = length;
            _eraserDurability = eraserDurability;
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
                _pointDurability = _initialDurability;
            }
        }

        public void Erase(Paper paper, String word)
        {
            int index = paper.Text.ToUpper().LastIndexOf(word.ToUpper(), StringComparison.CurrentCulture);
            if(index >= 0 && _eraserDurability > 0)
            {
                if(_eraserDurability < word.Length)
                {
                    paper.Text = createErasedString(paper.Text,
                                                    index + word.Length - _eraserDurability,
                                                    index + word.Length,
                                                    _eraserDurability);
                    _eraserDurability = 0;
                }
                else
                {
                    paper.Text = createErasedString(paper.Text, index, index + word.Length, word.Length);
                    _eraserDurability -= word.Length;
                }

            }
        }

        public void Edit(Paper paper, String text, int position)
        {
            String former = paper.Text.Substring(0, position);
            String latter = paper.Text.Substring(position + text.Length);
            paper.Text = String.Concat(former, text, latter);
        }

        private String createErasedString(String text, int startIndex, int endIndex, int erasedAmount)
        {
            String erasedString = new String(EMPTY, erasedAmount);
            String former = text.Substring(0, startIndex);
            String latter = text.Substring(endIndex);
            return String.Concat(former, erasedString, latter);
        }

        private void checkInitialDurabilityValid(int initialDurability)
        {
            if (initialDurability < 0)
            {
                throw new ArgumentException(NEGATIVE_DURABILITY_MESSAGE);
            }
        }

        private void checkInitialLengthValid(int initialLength)
        {
            if (initialLength < 0)
            {
                throw new ArgumentException(NEGATIVE_LENGTH_MESSAGE);
            }
        }

        private String applyDurabilityToWriting(String text)
        {
            char[] chars = text.ToCharArray();
            for (uint i = 0; i < chars.Length; i++)
            {
                if(chars[i] != EMPTY && chars[i] != NEWLINE)
                {
                    if (_pointDurability <= 0)
                    {
                        chars[i] = EMPTY;
                    }
                    else if(Char.IsUpper(chars[i]))
                    {
                        _pointDurability -= 2;
                    }
                    else
                    {
                        _pointDurability--;
                    }
                }
            }
            return new String(chars);
        }
    }
}
