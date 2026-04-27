using System;
using System.Collections.Generic;
using System.Text;

namespace Dan_s_Big_Awesome_Acoustic_Songbook_Parser
{
    public class Song
    {
        public string Title { get; private set; }
        public string Key { get; private set; }
        public List<string> Chords { get; private set; } = new List<string>();

        public Dictionary<int, List<string>> ChorusChords { get; set; } = new Dictionary<int, List<string>>();

        public Song(string title, string key, List<string> chords)
        {
            this.Title = title;
            this.Key = key;
            this.Chords = chords;
        }

        public void AddChorus(List<string> chorus)
        {
            var index = this.ChorusChords.Count;
            this.ChorusChords.Add(index, chorus);
        }
    }

}
