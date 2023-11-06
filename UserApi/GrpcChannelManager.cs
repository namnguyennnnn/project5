using Grpc.Core;
using Grpc.Net.Client;

namespace UserApi
{
    public class GrpcChannelManager
    {
        private static readonly Lazy<GrpcChannel> _exerciseChannel = new Lazy<GrpcChannel>(() =>
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            {
                configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.Production.json")
               .Build();
            }
            //var handler = new HttpClientHandler();
            //handler.ServerCertificateCustomValidationCallback =
            //HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            return GrpcChannel.ForAddress(configuration["ExerciseServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 1024,
                UnsafeUseInsecureChannelCallCredentials = true,
               // HttpHandler = handler
            });
        });

        public static GrpcChannel ExerciseChannel => _exerciseChannel.Value;
    }
}