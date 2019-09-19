namespace NFramework.BL.Contacts
{
    public interface ICommand<TResult, TModel>
    {
        TResult Dispatch(TModel cmdObj);
    }
}
