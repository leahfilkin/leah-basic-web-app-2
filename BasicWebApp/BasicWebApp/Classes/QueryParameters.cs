using System;

namespace BasicWebApp.Classes
{
    public class QueryParameters
    {
        private const int _maxSize = 100;
        private int _size = 10;

        public int Page { get; set; }

        public int Size
        {
            get => _size;
            set => _size = Math.Min(_maxSize, value);
        }
    }
}