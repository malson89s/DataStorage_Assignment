﻿using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusTypeFactory
{
    public static StatusTypeModel Create(StatusTypeEntity entity) 
    {
        return new StatusTypeModel
        {
            Id = entity.Id,
            StatusName = entity.StatusName,
        };
    }
}
