using MyLib;

namespace MyUnitTest;

[TestClass]
public class MyVolumeCalculatorTest
{
    private int volume;

    [TestMethod]
    [DataRow(10, 1000)]
    public void TestCubeVolumeCalculator(int dimA, int expRes)
    {
        var myvolumeCalculator = new MyVolumeCalculator();
        volume = myvolumeCalculator.calculateCubeVolume(dimA);
        Assert.AreEqual(expRes, volume);
    }

    [TestMethod]
    [DataRow(10, 20, 30, 2000)]
    public void TestPyramidVolumeCalculator(int dimA, int dimB, int dimC, int expRes)
    {
        var myvolumeCalculator = new MyVolumeCalculator();
        volume = myvolumeCalculator.calculatePyramidVolume(dimA, dimB, dimC);
        Assert.AreEqual(expRes, volume);
    }
}