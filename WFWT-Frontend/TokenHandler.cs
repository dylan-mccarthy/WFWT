using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;

namespace WFWT_Frontend;
public class TokenHandler : DelegatingHandler {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenHandler(IHttpContextAccessor httpContextAccessor) {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
        if(_httpContextAccessor == null || _httpContextAccessor.HttpContext == null) {
            return await base.SendAsync(request, cancellationToken);
        }
        var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        return await base.SendAsync(request, cancellationToken);
    }
}