using NFramework.BL.Contacts;
using NFramework.Data;
using NFramework.DTO.CommandModels.UserDelete;
using NFramework.DTO.Result.Command;
using System;

namespace NFramework.BL.Command.UserDelete
{
    public class UserDeleteCommand : ICommand<CommandResult, UserDeleteModel>
    {
        public readonly NFrameworkDataContext _dataContext;
        public UserDeleteCommand(NFrameworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CommandResult Dispatch(UserDeleteModel cmdObj)
        {
            try
            {
                return CommandResult.Executed("User Deleted Successfully");
            }
            catch (Exception ex)
            {

                return CommandResult.Failed("Error While Deleting User", ex.ToString(), ex);
            }
        }
    }
}
