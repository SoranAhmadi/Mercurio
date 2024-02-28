﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Service
{
    public class ServiceCreateDTO
    {
        public required string Title { get; set; }
        public required string Title1 { get; set; }
        public required string Subtitle { get; set; }
        public required string Title2 { get; set; }
        public required string ImageBase64 { get; set; }
        public List<string> ServiceItems { get; set; }

        [MaxLength(500)]
        public string? ExtraTitle { get; set; }
        [MaxLength(500)]
        public string? ExtraDescription { get; set; }

    }
}
