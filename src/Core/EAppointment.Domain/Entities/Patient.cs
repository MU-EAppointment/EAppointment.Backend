﻿namespace EAppointment.Domain.Entities
{
    public class Patient
    {
        public Patient() => Id = Guid.NewGuid();

        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string IdentityNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
