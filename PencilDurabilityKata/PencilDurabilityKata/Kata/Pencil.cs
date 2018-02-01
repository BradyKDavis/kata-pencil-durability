﻿using System;
namespace PencilDurabilityKata.Kata
{
    public class Pencil
    {
        private const int MAX = int.MaxValue;
        private const String NON_POSITIVE_DURABILITY_MESSAGE = "Cannot initialize pencil with non-positive durability.";
        private const String NEGATIVE_LENGTH_MESSAGE = "Cannot initialize pencil with negative length.";

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
            checkInitialDurabilityValid(initialDurability);
            _durability = _initialDurability = initialDurability;
            _length = MAX;
        }

        public Pencil(int initialDurability, int length)
        {
            checkInitialDurabilityValid(initialDurability);
            if(length < 0)
            {
                throw new ArgumentException(NEGATIVE_LENGTH_MESSAGE);
            }
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

        public void Erase(Paper paper, String word)
        {
            int index = paper.Text.IndexOf(word, StringComparison.CurrentCulture);
            if(index >= 0)
            {
                String erasedString = new String(EMPTY, word.Length);
                paper.Text = paper.Text.Replace(word, erasedString);
            }
        }

        private void checkInitialDurabilityValid(int initialDurability)
        {
            if (initialDurability <= 0)
            {
                throw new ArgumentException(NON_POSITIVE_DURABILITY_MESSAGE);
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
