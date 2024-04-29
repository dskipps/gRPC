using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrpcService1.Services;

public partial class Message
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string MessageText { get; set; } = null!;
}
