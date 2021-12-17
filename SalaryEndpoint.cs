namespace MyWebApp
{
    public class SalaryEnpoint : Endpoint<MyRequest1>
    {
        public override void Configure()
        {
            Verbs(Http.POST);
            Routes("/api/salary");
            Claims("Manager");

            //Claims("AdminID", "EmployeeID");  --ClaimsAll
            //Roles("Admin", "Manager");
            //Permissions("UpdateUsersPermission", "DeleteUsersPermission"); ---PermissionsAll
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
