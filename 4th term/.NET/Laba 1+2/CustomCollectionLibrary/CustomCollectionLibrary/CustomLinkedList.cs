using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollectionLibrary 
{
    public class CustomLinkedList<T> : ICollection<T> where T : IComparable<T>
    {

        public event EventHandler<CustomLinkedListEventHandler<T>> AddNode;
        public event EventHandler<CustomLinkedListEventHandler<T>> RemoveNode;
        public event EventHandler<CustomLinkedListEventHandler<T>> ClearCustomLinkedList;

        private CustomLinkedListNode<T> Head { get; set; }
        private CustomLinkedListNode<T> Tail { get; set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;

        public void Add(T item)
        {
            var temp = new CustomLinkedListNode<T>(item);

            if (Head == null)
            {
                Head = temp;
                Tail = temp;
            }

            Tail!.Next = temp;
            temp.Previous = Tail;
            Tail = temp;

            ++Count;

            AddNode?.Invoke(this, new CustomLinkedListEventHandler<T>()
            {
                Value = item,
                ActionType = CollectionActionType.AddNode
            });
        }

        public bool Contains(T item)
        {
            var temp = Head;

            if (temp == null)
                return false;

            if (item == null && temp.Data == null)
                return true;

            while (temp?.Next != null)
            {
                if (temp.Data?.CompareTo(item) == 0)
                    return true;

                temp = temp.Next;
            }

            return temp!.Data?.CompareTo(item) == 0;
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
                return false;

            var CustomLinkedListNodeToRemove = GetCustomLinkedListNode(item);

            var prevCustomLinkedListNode = CustomLinkedListNodeToRemove!.Previous;
            var nextCustomLinkedListNode = CustomLinkedListNodeToRemove.Next;

            if (prevCustomLinkedListNode != null)
                prevCustomLinkedListNode.Next = nextCustomLinkedListNode;

            if (nextCustomLinkedListNode != null)
                nextCustomLinkedListNode.Previous = prevCustomLinkedListNode;

            RemoveNode?.Invoke(this, new CustomLinkedListEventHandler<T>()
            {
                Value = item,
                ActionType = CollectionActionType.RemoveNode
            });
            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((uint)arrayIndex >= array.Length)
                throw new ArgumentException("Index outbound of a range!");

            var index = 0;
            while (array.Length > arrayIndex)
            {
                var CustomLinkedListNode = GetCustomLinkedListNodeByIndex(index);
                if (CustomLinkedListNode == null)
                    return;

                array[arrayIndex] = CustomLinkedListNode.Data ?? default;

                ++arrayIndex;
            }
        }

        private CustomLinkedListNode<T> GetCustomLinkedListNodeByIndex(int index)
        {
            var CustomLinkedListNodesPassed = 0;

            if (Head == null)
                return null;

            if (index >= Count)
                return null;

            var currCustomLinkedListNode = Head;
            while (index < CustomLinkedListNodesPassed && currCustomLinkedListNode is { Next: { } })
            {
                currCustomLinkedListNode = currCustomLinkedListNode.Next;
                ++CustomLinkedListNodesPassed;
            }

            return currCustomLinkedListNode;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;

            ClearCustomLinkedList?.Invoke(this, new CustomLinkedListEventHandler<T>()
            {
                ActionType = CollectionActionType.ClearCustomLinkedList
            });
        }

        public IEnumerator<T> GetEnumerator() => new CustomLinkedListEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private CustomLinkedListNode<T> GetCustomLinkedListNode(T item)
        {
            if (Head == null)
                return null;

            var temp = Head;

            while (temp!.Next != null)
            {
                if (temp.Data?.CompareTo(item) == 0)
                    return temp;

                temp = temp.Next;
            }

            if (temp.Data == null && item == null)
                return temp;

            return temp.Data!.CompareTo(item) == 0 ? temp : null;
        }

        private struct CustomLinkedListEnumerator : IEnumerator<T>
        {
            public T Current { get; private set; }
            object IEnumerator.Current => Current!;

            private CustomLinkedListNode<T> _currentCustomLinkedListNode;
            private readonly CustomLinkedList<T> _list;


            public CustomLinkedListEnumerator(CustomLinkedList<T> list)
            {
                _list = list;

                _currentCustomLinkedListNode = list.Head;

                Current = list.Head != null? list.Head.Data : default;
            }

            public bool MoveNext()
            {
                if (_currentCustomLinkedListNode == null)
                    return false;

                Current = _currentCustomLinkedListNode.Data;
                _currentCustomLinkedListNode = _currentCustomLinkedListNode.Next;

                return _currentCustomLinkedListNode != _list.Head;
            }

            public void Reset()
            {
                _currentCustomLinkedListNode = _list.Head;
                Current = default;
            }

            public void Dispose()
            {
            }
        }
    }
}
