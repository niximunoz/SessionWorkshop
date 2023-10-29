#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace SessionWorkshop.Models;
public class User
{
    [Required]
    public string Name { get; set; }

    public int Number { get; set; } = 22;
}