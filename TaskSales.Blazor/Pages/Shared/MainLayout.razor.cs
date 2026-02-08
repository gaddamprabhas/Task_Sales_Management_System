using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using TaskSales.Blazor.Services;

public partial class MainLayout : LayoutComponentBase
{
    [Inject] AuthenticationStateProvider AuthProvider { get; set; } = default!;
    [Inject] UserManager<IdentityUser> UserManager { get; set; } = default!;
    [Inject] EmployeeApiService EmployeeService { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
            return;

        var identityUser = await UserManager.GetUserAsync(user);
        if (identityUser == null || identityUser.Email == null)
            return;

        await EmployeeService.EnsureEmployeeExistsAsync(
            identityUser.Id,
            identityUser.Email
        );
    }
}
