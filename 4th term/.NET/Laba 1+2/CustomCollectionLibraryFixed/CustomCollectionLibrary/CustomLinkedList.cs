using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollectionLibrary
{
    public class CustomLinkedList<T> : ICollection<T> where T : IComparable<T>
    {
        public delegate void DataEventHandler(string message, T data, string key);
        public delegate void EventHandler(string message);

        public event DataEventHandler AddAction = delegate { };
        public event DataEventHandler DeleteAction = delegate { };
        public event EventHandler ClearAction = delegate { };

        private CustomLinkedListNode<T> Head { get; set; }
        private CustomLinkedListNode<T> Tail { get; set; }
        public int Count { get; private set; }
        public bool IsReadOnly => false;
        public CustomLinkedList()
        {
            AddAction += ShowMessageWithData;
            DeleteAction += ShowMessageWithData;
            ClearAction += ShowMessageWithoutData;
        }

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

            AddAction?.Invoke("Added element with data: ", item, "add");
        }
        public CustomLinkedListNode<T> AddAfter(CustomLinkedListNode<T> oldNode, T item)
        {
            CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(item);
            AddAfter(oldNode, newNode);
            return newNode;
        }
        public void AddAfter(CustomLinkedListNode<T> oldNode, CustomLinkedListNode<T> newNode)
        {
            if (!(oldNode.Next is null))
            {
                oldNode.Next.Previous = newNode;
                newNode.Next = oldNode.Next;
                newNode.Previous = oldNode;
                oldNode.Next = newNode;
            }
            else
            {
                oldNode.Next = newNode;
                newNode.Previous = oldNode;
            }

            if (oldNode == Tail)
            {

                Tail = newNode;
            }

            Count++;

            AddAction?.Invoke("Added element with data: ", newNode.Data, "add");
        }
        public CustomLinkedListNode<T> AddBefore(CustomLinkedListNode<T> oldNode, T item)
        {
            CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(item);
            AddBefore(oldNode, newNode);
            return newNode;
        }
        public void AddBefore(CustomLinkedListNode<T> oldNode, CustomLinkedListNode<T> newNode)
        {
            if (!(oldNode.Previous is null))
            {
                oldNode.Previous.Next = newNode;
                newNode.Previous = oldNode.Previous;
                oldNode.Previous = newNode;
                newNode.Next = oldNode;
            }
            else
            {
                oldNode.Previous = newNode;
                newNode.Next = oldNode;
            }

            if (oldNode == Head)
            {

                Head = newNode;
            }

            Count++;

            AddAction?.Invoke("Added element with data: ", newNode.Data, "add");
        }
        public CustomLinkedListNode<T> AddFirst(T item)
        {
            CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(item);
            AddFirst(newNode);
            return newNode;
        }
        public void AddFirst(CustomLinkedListNode<T> newNode)
        {
            if (!(Head is null))
            {
                Head.Previous = newNode;
                newNode.Next = Head;
                Head = newNode;
                Count++;
            }
            else
            {
                Head = newNode;
                Tail = newNode;
                Count = 1;
            }

            AddAction?.Invoke("Added element with data: ", newNode.Data, "add");
        }
        public CustomLinkedListNode<T> AddLast(T item)
        {
            CustomLinkedListNode<T> newNode = new CustomLinkedListNode<T>(item);
            AddLast(newNode);
            return newNode;
        }
        public void AddLast(CustomLinkedListNode<T> newNode)
        {
            if (!(Tail is null))
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
                Tail = newNode;
                Count++;
            }
            else
            {
                Head = newNode;
                Tail = newNode;
                Count = 1;
            }

            AddAction?.Invoke("Added element with data: ", newNode.Data, "add");
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

            if (Head == CustomLinkedListNodeToRemove)
                Head = Head.Next;

            if (Tail == CustomLinkedListNodeToRemove)
                Tail = Tail.Previous;

            Count--;

            DeleteAction?.Invoke("Removed element with data: ", item, "del");

            return true;
        }
        public CustomLinkedListNode<T> GetCustomLinkedListNodeByIndex(int index)
        {
            var counter = 0;

            if (Head == null)
            {
                throw new ArgumentException("Index outbound of a range!");
            }

            if (index >= Count)
            {
                return null;
            }

            var temp = Head;


            while (temp != null)
            {
                if (counter == index)
                {
                    return temp;
                }

                counter++;
                temp = temp.Next;
            }

            throw new ArgumentException("Index outbound of a range!");
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((uint)arrayIndex >= array.Length)
                throw new ArgumentException("Index outbound of a range!");

            var index = 0;

            while (array.Length > index)
            {
                var CustomLinkedListNode = GetCustomLinkedListNodeByIndex(index);
                if (CustomLinkedListNode == null)
                {
                    return;
                }

                array[index] = CustomLinkedListNode.Data;

                index++;
            }
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;

            ClearAction?.Invoke("List completely cleared");
        }

        public IEnumerator<T> GetEnumerator() => new CustomLinkedListEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

                Current = list.Head != null ? list.Head.Data : default;
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

        public static void ShowMessageWithData(string message, T data, string key)
        {
            Console.Write(message);
            switch (key)
            {
                case "add":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "del":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
            Console.WriteLine(data);
            Console.ResetColor();
        }
        public static void ShowMessageWithoutData(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
