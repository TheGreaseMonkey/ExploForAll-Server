﻿using ExploForAll.Server.Models;

namespace ExploForAll.Server.Interactors.AccountUseCase
{
    public class CreateNewAccountResponse : Response
    {
        public CreateNewAccountResponse()
        {

        }

        public CreateNewAccountResponse(ResponseTypes status, string message)
        {
            base.Message = message;
            base.Status = status;
        }
    }
}
