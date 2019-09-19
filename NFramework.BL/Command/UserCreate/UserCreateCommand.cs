using NFramework.BL.Contacts;
using NFramework.Data;
using NFramework.DTO.CommandModels.UserCreate;
using NFramework.DTO.Result.Command;
using System;

namespace NFramework.BL.Command.UserCreate
{
    public class UserCreateCommand : ICommand<CommandResult, UserCreateModel>
    {

        public readonly NFrameworkDataContext _dataContext;
        public UserCreateCommand(NFrameworkDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public CommandResult Dispatch(UserCreateModel cmdObj)
        {
            try
            {
                return CommandResult.ReturnExecuted("Command Executed Successfully", cmdObj);
            }
            catch (Exception ex)
            {

                return CommandResult.Failed("Error While Executing Command", ex.ToString(), ex);
            }
        }
    }
}
