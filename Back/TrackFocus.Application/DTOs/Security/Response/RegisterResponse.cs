namespace TrackFocus.Application.DTOs.Response
{
    public record RegisterResponse(string Id, string Email, string Username, DateTime DataNascimento);
}