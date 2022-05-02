using System;
using System.Collections.Generic;
using System.Text;

namespace CustomCollectionLibrary
{
    public class CustomLinkedListEventHandler<T> : EventArgs where T : IComparable<T>
    {
        public CollectionActionType ActionType { get; set; }
        public T Value { get; set; }
    }

    public enum CollectionActionType
    {
        AddNode,
        RemoveNode,
        ClearCustomLinkedList
    }
}
