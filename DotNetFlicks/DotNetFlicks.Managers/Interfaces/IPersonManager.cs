﻿using DotNetFlicks.Common.Configuration;
using DotNetFlicks.ViewModels.Person;

namespace DotNetFlicks.Managers.Interfaces
{
    public interface IPersonManager
    {
        PersonViewModel Get(int? id);

        PaginatedList<PersonViewModel> GetRequest(IndexRequest query);

        PersonViewModel Save(PersonViewModel vm);

        PersonViewModel Delete(int id);
    }
}
