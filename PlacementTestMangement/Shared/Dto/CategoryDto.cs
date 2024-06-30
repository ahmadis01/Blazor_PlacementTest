using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementTestMangement.Shared.Dto;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int FromAge { get; set; }
    public int ToAge { get; set; }
}
