using NUnit.Framework;

using BBUnity.Extensions;

namespace Extensions {
    public class ArrayExtensionsTests {

        [Test]
        public void Append_ShouldAppendAnItemToTheEndOfArray() {
            int[] array = new int[0];
            int[] newArray = array.Append(5);

            Assert.AreEqual(1, newArray.Length);
            Assert.AreEqual(5, newArray[0]);
        }

        [Test]
        public void Append_ShouldNotModifyTheExistingArray() {
            int[] array = new int[0];
            array.Append(5);

            Assert.AreEqual(0, array.Length);
        }
    }
}
