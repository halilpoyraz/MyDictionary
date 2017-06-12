using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary.Models
{
    public class Dictionary
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Language { get; set; }
        public string Type { get; set; }
        [NotNull]
        public string Word { get; set; }
        [NotNull]
        public string Meaning { get; set; }
        public string W_SampleSentence { get; set; }
        public string M_SampleSentence { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
