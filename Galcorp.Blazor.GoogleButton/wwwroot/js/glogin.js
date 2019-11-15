window.glogin = {};

window.glogin.profileServiceReference = null;
window.glogin.client_id = null;

window.glogin.setup = (profileServiceReference, client_id) => {
    window.glogin.profileServiceReference = profileServiceReference;
    window.glogin.client_id = client_id;
    window.glogin.init();
};

window.glogin.onSignIn = (success) => {
    if (success) {
        window.glogin.profileServiceReference.invokeMethodAsync('ProfileServiceSignIn', glogin.getUserInfo());
    } else {
        window.glogin.profileServiceReference.invokeMethodAsync('ProfileServiceSignOut');
    }
};

window.glogin.init = () => {
    if (glogin.client_id) {
        gapi.auth2.init({
            client_id: glogin.client_id,
            scope: 'https://www.googleapis.com/auth/plus.login'
        }).then(function (auth2) {
            auth2.isSignedIn.listen(glogin.onSignIn);

            glogin.onSignIn(auth2.isSignedIn.get());
        }).catch(function (e) {
            console.log('Failed to initialize google api', e);
        });
    } else {
        /// waiting for config init
    }
};

window.glogin.loadAndInit = () => {
    gapi.load('client:auth2', window.glogin.init);
};

window.glogin.askGoogleForLogin = () => {
    gapi.auth2.getAuthInstance().signIn();
};

window.glogin.askGoogleForSignout = () => {
    gapi.auth2.getAuthInstance().signOut();
};

window.glogin.getUserInfo = () => {
    //console.log("getUserInfo: get");
    if (gapi && gapi.auth2) {
        var instance = gapi.auth2.getAuthInstance();

        if (instance && instance.isSignedIn.get()) {
            var profile = instance.currentUser.get().getBasicProfile();
            if (profile) {
                var user = {};
                user.id = profile.getId();
                user.FullName = profile.getName();
                user.GivenName = profile.getGivenName();
                user.FamilyName = profile.getFamilyName();
                user.ImageURL = profile.getImageUrl();
                user.Email = profile.getEmail();
                //console.log("getUserInfo: get", user);
                return user;
            }
            else {
                //console.log("getUserInfo: npo user info, but signed in");
            }
        } else {
            //console.log("getUserInfo: not signed in");
        }
    }
    //console.log("getUserInfo: failed");

    return null;
};
