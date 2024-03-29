﻿using MotoApp.Data.Entities;

namespace MotoApp.Data.Repositories.Extensions;

public static class RepositoryExtensions
{
    public static void AddBatchThenSave<T>(this IRepository<T> repository, T[] items)
        where T : class, IEntity
    {
        foreach (var item in items)
        {
            repository.Add(item);
        }

        repository.Save();
    }
}
