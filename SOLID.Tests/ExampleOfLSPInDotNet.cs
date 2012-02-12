using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;

namespace SOLID.Tests
{
    public class ExampleOfLSPInDotNet
    {
        [Test]
        public void NAME()
        {
            var readOnlyCollection = new ReadOnlyCollection<int>(new[] {0, 1, 2});

            // Error.
            //readOnlyCollection.Add(1);

            TryToAdd(readOnlyCollection, 1);
        }

        public void TryToAdd(IList<int> list, int item)
        {
            list.Add(item);
        }
    }
}
