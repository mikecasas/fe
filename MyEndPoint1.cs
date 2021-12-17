namespace MyWebApp
{
    public class MyEndPoint1 : Endpoint<MyRequest1>
    {
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/user/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(MyRequest1 req, CancellationToken ct)
        {
            var response = new MyResponse1()
            {
                FullName = req.FirstName + " " + req.LastName,
                IsOver18 = req.Age > 18
            };

            await SendAsync(response);
        }
    }
}
