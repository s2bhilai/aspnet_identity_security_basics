

var config = {
    authority: "https://localhost:44369/",
    client_id: "client_id_js",
    redirect_uri: "https://localhost:44389/Home/SignIn",
    response_type: "id_token token",
    scope: "openid ApiOne"
};

var userManager = new Oidc.UserManager(config);

var signIn = function () {
    userManager.signinRedirect();
}

userManager.getUser().then(user => {
    console.log("user: ", user);
    if (user) {
        axios.defaults.headers.common["Authorization"] = "Bearer " + user.access_token;
    }
});

var callApi = function () {
    axios.get('https://localhost:44327/secret')
        .then(res => {
            console.log(res);
        });
}