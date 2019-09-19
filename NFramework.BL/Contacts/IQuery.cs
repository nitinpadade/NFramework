namespace NFramework.BL.Contacts
{
    public interface IQuery<TResult, TParameters>
    {
        TResult Execute(TParameters parameters);
    }
}
