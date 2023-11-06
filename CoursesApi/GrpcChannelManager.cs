using Grpc.Core;
using Grpc.Net.Client;


namespace CoursesApi
{
    public class GrpcChannelManager
    {
       
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
            return GrpcChannel.ForAddress(configuration["UserServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 10 * 1024 * 1024,
                UnsafeUseInsecureChannelCallCredentials = true,
            });
        });
        public static GrpcChannel UserChannel => _userChannel.Value;
    }
}
