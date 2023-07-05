using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace minecraftsaas.DB {
    public class Login {
        private readonly ILogger _logger;
        private readonly DBUserContext userContext;

        public Login(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<Login>();
            userContext = new DBUserContext(Environment.GetEnvironmentVariable("DBConnectionString"));
        }

        [Function("Login")]
        public async Task<HttpResponseData> RunLogin([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req) {
            User user = await JsonSerializer.DeserializeAsync<User>(req.Body);
            
            var login = await userContext.LoginUser(user);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            if(login) {
                response.WriteString("{\"message\": \"OK\"}");
            } else {
                response = req.CreateResponse(HttpStatusCode.NotFound);
                response.WriteString("{\"message\": \"NO\"}");
            }

            return response;
        }

        [Function("Register")]
        public async Task<HttpResponseData> RunRegister([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req) {
            User user = await JsonSerializer.DeserializeAsync<User>(req.Body);

            var result = await userContext.InsertUser(user);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            response.WriteString(result + "");

            if(result == 1) {
                response.WriteString("{\"message\": \"OK\"}");
            } else {
                response = req.CreateResponse(HttpStatusCode.NotFound);
                response.WriteString("{\"message\": \"NO\"}");
            }

            return response;
        }
    }
}
