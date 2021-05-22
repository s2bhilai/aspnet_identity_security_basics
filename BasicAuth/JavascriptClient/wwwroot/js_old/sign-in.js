

var createState = function () {
    return "asdfasdfasdgagaqetqwtqertwdsdfasdfasd";
}

var createNonce = function () {
    return "asdfasdfsdkflamdfmasldmfaslkdflasdf";
}

var signIn = function () {

    var redirectUri = "https://localhost:44389/Home/SignIn";
    var responseType = "id_token token"; // For implicit flow
    var scope = "openid ApiOne";

    var authUrl =
        "/connect/authorize/callback" +
"?client_id=client_id_js"+
"&redirect_uri=" + encodeURIComponent(redirectUri) +
"&response_type=" + encodeURIComponent(responseType) +
"&scope=" + encodeURIComponent(scope) +
"&nonce=" + createNonce() +
"&state=" + createState();

    var returnUrl = encodeURIComponent(authUrl);

    window.location.href = "https://localhost:44369/Auth/Login?ReturnUrl=" + returnUrl;
}