using System.Resources;
using Manager.API.ViewModels;

namespace Manager.API.Utilities;

public static class Responses
{
    public static ResultViewModel ApplicationErrorMessage()
    {
        return new ResultViewModel
        {
            Message = "Ocorreu um erro, tente novamente",
            Sucess = false,
            Data = null
        };
    }

    public static ResultViewModel DomainErrorMessage(string message)
    {
        return new ResultViewModel
        {
            Message = message,
            Sucess = false,
            Data = null
        };
    }

    public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
    {
        return new ResultViewModel
        {
            Message = message,
            Sucess = false,
            Data = errors
        };
    }

    public static ResultViewModel UnauthorizedErrorMessage()
    {
        return new ResultViewModel
        {
            Message = "O login ou senha estão incorretos",
            Sucess = false,
            Data = null
        };
    }
}