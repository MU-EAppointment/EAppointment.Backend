﻿using EAppointment.Domain.Entities.Commons;
using EAppointment.Domain.Enums;

namespace EAppointment.Domain.Entities
{
    public sealed class Doctor : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DepartmentEnum Department { get; set; } = DepartmentEnum.Default;
        public string FullName => string.Join(" ", FirstName, LastName);
    }
}
