﻿using System;
using System.ComponentModel.DataAnnotations;
using YoW.Infrastructure.Models.intefaces;

namespace YoW.Infrastructure.Models.abstracts
{
  public abstract class HardDeletedObjectModel : IHardDeletedModel
  {
    [Key]
    [Required]
    public Guid Id { get; set; }

    [Required]
    public DateTime CreatedTime { get; set; }

    [Required]
    public string CreatedBy { get; set; }

    [Required]
    public DateTime UpdatedTime { get; set; }

    [Required]
    public string UpdatedBy { get; set; }
  }
}