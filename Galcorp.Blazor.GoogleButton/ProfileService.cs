using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Galcorp.Blazor.GoogleButton
{
    public delegate void OnSignInChangedHandler(bool state);

    public class ProfileService
    {
        private IJSRuntime _runtime;

        public User Profile { get; private set; }

        public event OnSignInChangedHandler OnSignInChanged;

        public ProfileService(IJSRuntime runtime, GButtonConfig options)
        {
            this._runtime = runtime;
            
            //// pass this instance to UI
            runtime.InvokeVoidAsync(
                "glogin.setup",
                DotNetObjectReference.Create(this),
                options.GoogleApiPublicKey);

        }

        public async Task<bool> IsSignedInAsync()
        {
            var u = await GetUserInfoAsync();
            return u != null;
        }

        [JSInvokable]
        public void ProfileServiceSignIn(User profile)
        {
            this.Profile = profile;
            this.OnSignInChanged?.Invoke(true);
        }

        [JSInvokable]
        public void ProfileServiceSignOut()
        {
            this.Profile = null;
            this.OnSignInChanged?.Invoke(false);
        }

        public async Task<User> GetUserInfoAsync()
        {
            try
            {
                var u = await _runtime.InvokeAsync<User>("glogin.getUserInfo");
                return u;
            }
            catch(Exception e)
            {

            }
            return await Task.FromResult<User>(null);
        }

        public User GetUserInfo()
        {
            return GetUserInfoAsync().Result;
        }
    }
}
