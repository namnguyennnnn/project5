using Grpc.Core;
using Grpc.Net.Client;


namespace ExercisesApi
{
    public class GrpcChannelManager
    {
        private static readonly Lazy<GrpcChannel> _audioChannel = new Lazy<GrpcChannel>(() =>
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") 
                .Build();

            return GrpcChannel.ForAddress(configuration["AudioServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 10 * 1024 * 1024,
                UnsafeUseInsecureChannelCallCredentials = true
            });
        });
        private static readonly Lazy<GrpcChannel> _categoryChannel = new Lazy<GrpcChannel>(() =>
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") 
                .Build();

            return GrpcChannel.ForAddress(configuration["CategoryServer"], new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Insecure,
                MaxSendMessageSize = 10 * 1024 * 1024,
                UnsafeUseInsecureChannelCallCredentials = true
            });
        });
        public static GrpcChannel AudioChannel => _audioChannel.Value;
        public static GrpcChannel CategoryChannel => _categoryChannel.Value;
    }
}
