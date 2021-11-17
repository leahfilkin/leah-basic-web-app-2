using System;

namespace BasicWebApp.Classes
{
    public class QueryParameters
    {
        private const int MaxSize = 100;
        private readonly int _size = 10;
        private const int MaxPage = 100;
        private readonly int _page= 1;
        private string _sortBy = String.Empty;
        private string _order = String.Empty;
        
        public string SortBy { get; init; }
        
        public string Order { get; init; }

        public int Page {             
            get => _page;
            init => _page = Math.Min(MaxPage, value); }

        public int Size
        {
            get => _size;
            init => _size = Math.Min(MaxSize, value);
        }
    }
}