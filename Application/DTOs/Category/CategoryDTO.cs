﻿namespace Application.DTOs.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Permalink { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }


    }
}
