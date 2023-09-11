using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


//Adiciona o servico de Controller
builder.Services.AddControllers();


builder.Services.AddAuthentication(
   options =>
   {

       options.DefaultAuthenticateScheme = "JwtBearer";
       options.DefaultAuthenticateScheme = "JwtBearer";

   })

    .AddJwtBearer("JwtBearer", Options =>
    {

        Options.TokenValidationParameters = new TokenValidationParameters
        {
            //Valida quem esta solicitando o token
            ValidateIssuer = true,

            //Valida quem esta recebendo o token
            ValidateAudience = true,

            //Define se o tempo de expiracao sera validado
            ValidateLifetime = true,

            //forma de criptografia e valida a chave de autenticacao do token
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai.inlock.webApi-chave-autenticacao-webapi-dev")),

            //Valida o tempo de expiracao do token
            ClockSkew = TimeSpan.FromMinutes(5),


            //De onde esta vindo o token
            ValidIssuer = "senai.inlock.webApi",

            //De onde o token esta indo 
            ValidAudience = "senai.inlock.webApi"


        };

    });


//Configuracao do servico do swagger documentacao
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API senai.inlock.webApi Bayer",
        Description = "API gerenciadora de jogos - projeto da sprint 2 - API BackEnd",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Henrique",
            Url = new Uri("https://example.com/contact")
        },

    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });



});


var app = builder.Build();

//Comeca a configuracao do swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Finaliza a configuracao do swagger



app.MapControllers();

//Adiciona autenticacao
app.UseAuthentication();


//adiciona autorizacao
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
