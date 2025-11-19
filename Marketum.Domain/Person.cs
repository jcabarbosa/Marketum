using System;

namespace Marketum.Domain
{
    public abstract class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;   
        public string Address { get; set; } = string.Empty;
        public string TaxNr { get; set; } = string.Empty;

        public abstract string GetContactSummary();
    }
}