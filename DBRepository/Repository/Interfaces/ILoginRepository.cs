﻿using BusinesEntites;
using NaveenreddyAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repository.Interfaces
{
    public interface ILoginRepository:IRepository<LoginDetails>
    {
        Task<B_Login> AddLogin(B_Login logindetails, B_LoginHistory history);
    }
}