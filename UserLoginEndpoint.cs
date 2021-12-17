namespace MyWebApp
{
    public class UserLoginEndpoint : Endpoint<LoginRequest>
    {

        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
        {
            if (req.UserName == "admin" && req.Password == "pass")
            {
                var jwtToken = JWTBearer.CreateToken(
                    signingKey: "TokenSigningKey",
                    expireAt: DateTime.UtcNow.AddDays(1),
                    claims: new[] { ("Username", req.UserName), ("UserID", "001") },
                    roles: new[] { "Admin", "Management" },
                    permissions: new[] { "ManageInventory", "ManageUsers" });

                await SendAsync(new
                {
                    Username = req.UserName,
                    Token = jwtToken
                });
            }
            else
            {
                ThrowError("The supplied credentials are invalid!");
            }
        }

    }
}
