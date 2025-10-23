﻿using Microsoft.AspNetCore.Identity;
using Sapphire17.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sapphire17.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[]? ImageData { get; set; }
        public string? ImageMimeType { get; set; }
        public bool Important { get; set; }
        public string Theme { get; set; }
        public bool Completed { get; set; }

        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
