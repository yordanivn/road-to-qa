namespace MyArray.Test
{
    public class MyArrayTests

    {
        [Test]
        public void MyArray_should_ReplaceValue_When_PositionIsValid()
        {
            var arr = new MyArray(5);
            var result = arr.Replace(2, 99);

            Assert.IsTrue(result);
            Assert.That(arr.Array[2], Is.EqualTo(99));
        }
        [Test]
        public void MyArray_Should_ThrowException_When_PositionIsLessThanZero()
        {
            var arr = new MyArray(5);
            Assert.Throws<ArgumentException>(() => arr.Replace(-8, 0));
        }
    }
}