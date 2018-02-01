﻿using System;
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
            if(index >= 0)
            {
                String erasedString = new String(EMPTY, word.Length);
                String former = paper.Text.Substring(0, index);
                String latter = paper.Text.Substring(index + word.Length);
                paper.Text = former + erasedString + latter;
            }
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
