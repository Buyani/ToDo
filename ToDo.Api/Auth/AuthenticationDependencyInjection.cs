using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ToDo.Api.Auth
{
    public static class AuthenticationDependencyInjection
    {
        public static IServiceCollection RegisterAuthentication(this IServiceCollection services)
        {
            var secreteKey = "your_super_secret_key_123!";

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew=TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secreteKey ?? string.Empty)),

                    ValidIssuer = "yourApp",
                    ValidAudience = "yourAppUsers",
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secreteKey))
                };
            });



            return services;
        }
    }
}
