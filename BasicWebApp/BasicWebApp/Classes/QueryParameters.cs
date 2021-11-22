using System;

namespace BasicWebApp.Classes
{
    public class QueryParameters
    {
        private const int MaxSize = 100;
        private readonly int _size = 10;
        private const int MaxPage = 100;
        private readonly int _page= 1;
        private readonly string _sortBy = string.Empty;
        private readonly string _order = string.Empty;
        
        public string SortBy
        {
            get => _sortBy;
            init => _sortBy = value;
        }

        public string Order {             
            get => _order;
            init => _order = value;
        }

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