using IdentityModel.Client;
using Microsoft.Extensions.Logging;

namespace ProcesoAutonomo.ServiceA.HttpClients;

public interface IIdentityServerClient
{
    Task<string> RequestClientCredentialsTokenAsync();
}

public class IdentityServerClient : IIdentityServerClient
{
    private readonly HttpClient _httpClient;
    private readonly ClientCredentialsTokenRequest _tokenRequest;
    private readonly ILogger<IdentityServerClient> _logger;

    public IdentityServerClient(
        HttpClient httpClient,
        ClientCredentialsTokenRequest tokenRequest,
        ILogger<IdentityServerClient> logger)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _tokenRequest = tokenRequest ?? throw new ArgumentNullException(nameof(tokenRequest));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<string> RequestClientCredentialsTokenAsync()
    {
        // request the access token token
        var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(_tokenRequest);
        if (tokenResponse.IsError)
        {
            _logger.LogError(tokenResponse.Error);
            throw new HttpRequestException("Something went wrong while requesting the access token");
        }
        return tokenResponse.AccessToken;
    }
}

public class ProtectedServiceABearerTokenHandler : DelegatingHandler
{
    private readonly IIdentityServerClient _identityServerClient;

    public ProtectedServiceABearerTokenHandler(
        IIdentityServerClient identityClient)
    {
        _identityServerClient = identityClient
            ?? throw new ArgumentNullException(nameof(identityClient));
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // request the access token
        var accessToken = await _identityServerClient.RequestClientCredentialsTokenAsync();

        // set the bearer token to the outgoing request
        request.SetBearerToken(accessToken);

        // Proceed calling the inner handler, that will actually send the request
        // to our protected api
        return await base.SendAsync(request, cancellationToken);
    }
}

public class NSwagServiceAClientsSettings
{
    public string? UriString { get; set; }
    public string? Issuer { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? Scope { get; set; }
}
