using System.Collections.Generic;
using System;

namespace LyraWMS.Models;

public class Picklist
{
    public int Id { get; set; }
    public string Uuid { get; set; }
    public string Reference { get; set; }
    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }
    public string Customer { get; set; }
}
