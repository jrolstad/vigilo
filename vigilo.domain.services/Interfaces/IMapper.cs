namespace vigilo.domain.services.Interfaces
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn request);
    }
}