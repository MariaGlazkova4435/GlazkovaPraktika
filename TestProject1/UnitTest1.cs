using System;
using Xunit;
using OplataTruda;

namespace TestProject1
{
    public class UnitTest1
    {
        Proverka proverka = new Proverka();

        [Fact]
        public void Test1()
        {
            Assert.True(proverka.NullStr(" "));
        }

        [Fact]
        public void Test2()
        {
            Assert.False(proverka.NullStr("45"));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(4, proverka.SchetPoOkladu("10", "5", "2"));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(0, proverka.SchetPoOkladu("fdg", "5", "10"));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(50, proverka.SchetPoOChasam("10", "5"));
        }

        [Fact]
        public void Test6()
        {
            Assert.Equal(0, proverka.SchetPoOChasam("fdg", "5"));
        }
    }
}
