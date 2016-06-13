﻿using App.Cqrs.Template.Core.Domain;
using System;

namespace App.Cqrs.Template.Application.ReadModel
{
    public class InventoryItemReadModel : IEntityBase
    {
        public Guid Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Version
        {
            get;
            set;
        }
    }
}