﻿namespace MeuLivroDeReceitas.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
