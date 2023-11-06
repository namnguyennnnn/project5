using Grpc.Core;
using Grpc.Net.Client;


namespace ExercisesApi
{
    public class GrpcChannelManager
    {
        private static readonly Lazy<GrpcChannel> _audioChannel = new Lazy<GrpcChannel>(() =>
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

            return GrpcChannel.ForAddress(configuration["AudioServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 15 * 1024 * 1024,
                UnsafeUseInsecureChannelCallCredentials = true,
               // HttpHandler = handler
            });
        });
        private static readonly Lazy<GrpcChannel> _categoryChannel = new Lazy<GrpcChannel>(() =>
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

            return GrpcChannel.ForAddress(configuration["CategoryServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 10 * 1024 * 1024,
                UnsafeUseInsecureChannelCallCredentials = true,
               // HttpHandler = handler
            });
        });
        private static readonly Lazy<GrpcChannel> _userChannel = new Lazy<GrpcChannel>(() =>
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
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            return GrpcChannel.ForAddress(configuration["UserServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 10 * 1024 * 1024,
                UnsafeUseInsecureChannelCallCredentials = true,
                 HttpHandler = handler
            });
        });
        public static GrpcChannel AudioChannel => _audioChannel.Value;
        public static GrpcChannel CategoryChannel => _categoryChannel.Value;
        public static GrpcChannel UserChannel => _userChannel.Value;
    }
}
