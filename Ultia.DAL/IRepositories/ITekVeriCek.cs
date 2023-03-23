namespace Ultia.DAL.IRepositories
{
    public interface ITekVeriCek<T> where T : class
    {
        T TekVeriCek(int id);
    }
}
