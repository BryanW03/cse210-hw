using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();
        _words = new List<Word>();

        foreach (string w in text.Split(' '))
        {
            if (!string.IsNullOrWhiteSpace(w))
                _words.Add(new Word(w));
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public void HideRandomWords(int count = 3)
    {
        List<Word> visible = _words.Where(w => !w.IsHidden()).ToList();
        if (visible.Count == 0) return;

        int hideCount = Math.Min(count, visible.Count);
        for (int i = 0; i < hideCount; i++)
        {
            int index = _random.Next(visible.Count);
            visible[index].Hide();
            visible.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{words}";
    }
}