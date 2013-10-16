namespace vigilo.domain.services.Interfaces
{
    public interface ICommand<in TIn, out TOut>
    {
        TOut Execute(TIn request);
    }
}