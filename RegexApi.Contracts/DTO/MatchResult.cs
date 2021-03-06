namespace RegexApi.Contracts.DTO
{
    using System.Collections.Generic;
    public class MatchResult
    {
        public string FullMatch { get; }
        public int Position { get; }
        public IEnumerable<Group> Groups { get; set; }
        public MatchResult(string value, int position , IEnumerable<Group> groups)
        {
            FullMatch = value;
            Position = position;
            Groups = groups;
        }

        public class Group
        {
            public string Value { get; }
            public int Position { get; }

            public Group(string value,int position)
            {
                Value = value;
                Position = position;
            }
        }
    }
}