using System;

namespace BasicWebApp.Classes
{
    public class QueryParameters
    {
        private const int MaxSize = 100;
        private readonly int _size = 10;

        public int Page { get; init; }

        public int Size
        {
            get => _size;
            init => _size = Math.Min(MaxSize, value);
        }
    }
}