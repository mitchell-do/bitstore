using Bitstore.Core.Enums;
using Bitstore.Core.Models;

namespace Bitstore.DataAccess.Entities;

public class UserEntity
{
    public Guid  Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public decimal Balance { get; set; } = 0;
    public List<BeatEntity> Beats { get; set; }  = new();
    public List<OrderEntity> Orders { get; set; } = new();
    public List<OrderItemEntity> Items = new();
}