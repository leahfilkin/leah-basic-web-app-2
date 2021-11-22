using System;

namespace BasicWebApp.Classes
{
    public class QueryParameters
    {
        private const int MaxSize = 100;
        private readonly int _size = 10;
        private const int MaxPage = 100;
        private readonly int _page= 1;
        
        public string SortBy { get; init; } = string.Empty;

        public string Order { get; init; } = string.Empty;

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