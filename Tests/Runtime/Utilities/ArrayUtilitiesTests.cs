using NUnit.Framework;

namespace Extensions {
    public class ArrayUtilitiesTests {

        [Test]
        public void Append_ShouldAppendAnItemToTheEndOfPassedArray() {
            int[] array = new int[0];
            ArrayUtilities.Append(ref array, 5);

            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(5, array[0]);
        }

        [Test]
        public void Append_ShouldAppendAnItemToTheEndOfReturnedArray() {
            int[] array = new int[0];
            int[] newArray = ArrayUtilities.Append(array, 5);

            Assert.AreEqual(1, newArray.Length);
            Assert.AreEqual(5, newArray[0]);
        }

        [Test]
        public void Append_ShouldNotModifyTheExistingArray() {
            int[] array = new int[0];
            int[] newArray = ArrayUtilities.Append(array, 5);

            Assert.AreEqual(0, array.Length);
        }
    }
}
