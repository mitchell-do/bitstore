namespace Bitstore.Application.DTO.User;

public record UserUpdateBalanceRequest(Guid UserId,  decimal Amount);