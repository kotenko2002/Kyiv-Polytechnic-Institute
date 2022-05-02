using CustomCollectionLibrary;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class CustomLinkedListTests
    {
        [Fact]
        public void AddElementsToDlsTest()
        {
            CustomLinkedList<string> dls = new CustomLinkedList<string>();

            dls.Add("U");
            dls.Add("S");
            dls.Add("A");

            Assert.Equal("USA", string.Join("", dls));
        }

        [Fact]
        public void DlsEnumerateElementsTest()
        {
            CustomLinkedList<int> dls = new CustomLinkedList<int>{ 9, 1, 1 };

            Assert.Equal("911", string.Join("", dls));
        }

        [Fact]
        public void DlsClearTest()
        {
            CustomLinkedList<string> dls = new CustomLinkedList<string>{"I","love","Paris!"};

            dls.Clear();

            Assert.Empty(dls);
        }

        [Fact]
        public void EnumeratorResetTest()
        {
            CustomLinkedList<int> dls = new CustomLinkedList<int>(){ 8, 6, 1 };

            string res = "";
            using IEnumerator<int> enumerator = dls.GetEnumerator();

            while (enumerator.MoveNext())
                res += enumerator.Current;

            Assert.Equal("861", res);
        }

        [Fact]
        public void CollectionsReadonlyTest()
        {
            CustomLinkedList<string> dls = new CustomLinkedList<string>{ "W","T","F" };

            Assert.False(dls.IsReadOnly);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(100)]
        public void RemoveTest(int valToRemove)
        {
            CustomLinkedList<int> dls = new CustomLinkedList<int>(){ 1, 2, 3, 4 };

            dls.Remove(valToRemove);

            Assert.DoesNotContain(valToRemove, dls);
        }

        [Theory]
        [MemberData(nameof(Values))]
        public void DlsContainsElementTest(string[] values)
        {
            CustomLinkedList<string> dls = new CustomLinkedList<string>();

            foreach (var value in values)
                dls.Add(value);

            Assert.Contains(values[0], dls);
        }

        public static IEnumerable<object[]> Values =>
            new List<object[]>
            {
            new object[] {new[] {"1", "2", "3"}},
            new object[] {new string[] {null!}}
            };
    }
}
