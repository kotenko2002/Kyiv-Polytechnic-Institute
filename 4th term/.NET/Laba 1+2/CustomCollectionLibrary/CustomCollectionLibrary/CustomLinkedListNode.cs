using System;
using System.Collections.Generic;
using System.Text;

namespace CustomCollectionLibrary
{
    public sealed class CustomLinkedListNode<T>
    {
        public CustomLinkedListNode<T> Previous { get; set; }
        public CustomLinkedListNode<T> Next { get; set; }
        public T Data { get; }

        public CustomLinkedListNode(T data) => Data = data;

    }
}
