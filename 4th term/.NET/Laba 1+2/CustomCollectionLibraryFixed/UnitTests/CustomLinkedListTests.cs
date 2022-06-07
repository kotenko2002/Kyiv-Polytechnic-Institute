using CustomCollectionLibrary;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class CustomLinkedListTests
    {
        [Fact]
        public void AddTests()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "M", "V", "C" };

            list.Add("!");

            Assert.Equal("MVC!", string.Join("", list));
        }

        [Fact]
        public void AddItemAfterNodeTests()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>() { 2, 0, 0 };

            var node = list.GetCustomLinkedListNodeByIndex(list.Count - 1);
            list.AddAfter(node, 2);
            Assert.Equal("2002", string.Join("", list));
        }

        [Fact]
        public void AddNodeAfterNodeTests()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "X","Y","Z" };

            var node = list.GetCustomLinkedListNodeByIndex(list.Count - 1);
            var newNode = new CustomLinkedListNode<string>("Q");

            list.AddAfter(node, newNode);

            Assert.Equal("XYZQ", string.Join("", list));
        }

        [Fact]
        public void AddItemBeforeNodeTests()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>() { 4, 1, 4 };

            var node = list.GetCustomLinkedListNodeByIndex(list.Count - 1);
            list.AddBefore(node, 1);
            Assert.Equal("4114", string.Join("", list));
        }

        [Fact]
        public void AddNodeBeforeNodeTests()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "U", "A", "R" };

            var node = list.GetCustomLinkedListNodeByIndex(list.Count - 1);
            var newNode = new CustomLinkedListNode<string>("A");

            list.AddBefore(node, newNode);

            Assert.Equal("UAAR", string.Join("", list));
        }

        [Fact]
        public void AddItemFirstTests()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>() { 7, 7, 7 };

            list.AddFirst(1);

            Assert.Equal("1777", string.Join("", list));
        }

        [Fact]
        public void AddNodeFirstTests()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "N", "E", "T" };

            var node = new CustomLinkedListNode<string>(".");

            list.AddFirst(node);

            Assert.Equal(".NET", string.Join("", list));
        }

        [Fact]
        public void AddItemLastTests()
        {
            CustomLinkedList<int> list = new CustomLinkedList<int>() { 8, 8, 0 };

            list.AddLast(5);

            Assert.Equal("8805", string.Join("", list));
        }

        [Fact]
        public void AddNodeLastTests()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "w", "w", "w" };

            var node = new CustomLinkedListNode<string>(".");

            list.AddLast(node);

            Assert.Equal("www.", string.Join("", list));
        }

        [Fact]
        public void ContainsInstemTests()
        {
            test(new CustomLinkedList<int>() { 4, 5, 9 }, 4, true);
            test(new CustomLinkedList<int>() { 1, 5, 9 }, 2, false);

            void test(CustomLinkedList<int> list, int element, bool result)
            {
                Assert.Equal(list.Contains(element), result);
            }
        }

        [Fact]
        public void RemoveTests()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "U", "S", "A" };

            list.Remove("A");

            Assert.Equal("US", string.Join("", list));
        }

        [Fact]
        public void GetNodeByIndexTest()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "A", "P", "I" };

            CustomLinkedListNode<string> node = new CustomLinkedListNode<string>("2.0");
            list.AddLast(node);

            var nodeByIndex = list.GetCustomLinkedListNodeByIndex(list.Count - 1);

            Assert.Equal(node, nodeByIndex);
        }

        [Fact]
        public void CopyToTest()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>() { "C", "S", "S" };
            var array = new string[list.Count];

            list.CopyTo(array, list.Count - 1);

            Assert.Equal(string.Join("", list), string.Join("", array));
        }

        [Fact]
        public void ClearTest()
        {
            CustomLinkedList<string> list = new CustomLinkedList<string> { "some", "text", "here" };

            list.Clear();

            Assert.Empty(list);
        }
    }
}
