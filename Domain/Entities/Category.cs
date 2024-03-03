﻿namespace Domain.Entities
{
    public class Category:Entity
    {
        public required string Title {  get; set; }
        
        public string? Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } 
    }
}
