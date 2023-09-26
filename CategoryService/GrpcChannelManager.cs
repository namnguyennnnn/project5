using Grpc.Core;
using Grpc.Net.Client;

namespace CategoryService
{
    public class GrpcChannelManager
    {
        private static readonly Lazy<GrpcChannel> _exerciseChannel= new Lazy<GrpcChannel>(() =>
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") 
                .Build();

            return GrpcChannel.ForAddress(configuration["ExerciseServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 1024 ,
                UnsafeUseInsecureChannelCallCredentials = true
            });
        });

        public static GrpcChannel ExerciseChannel => _exerciseChannel.Value;
    }
}
