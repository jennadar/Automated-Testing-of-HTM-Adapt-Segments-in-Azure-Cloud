namespace MyLib;
public class MyVolumeCalculator
{
    private int volume;

    public int calculateCubeVolume(int dim)
    {
        volume = dim * dim * dim;
        return volume;
    }

    public int calculatePyramidVolume(int dimA, int dimB, int dimC)
    {
        volume = (dimA * dimB * dimC) / 3;
        return volume;
    }

}
