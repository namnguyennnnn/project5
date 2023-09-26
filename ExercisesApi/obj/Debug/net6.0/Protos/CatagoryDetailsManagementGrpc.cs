// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/catagory_details_management.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace CatagoryDetailsManagement {
  public static partial class CatagoryDetailManager
  {
    static readonly string __ServiceName = "catagory_details_management.CatagoryDetailManager";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest> __Marshaller_catagory_details_management_GetCatagoryDetailInForRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse> __Marshaller_catagory_details_management_GetCatagoryDetailInForResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest, global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse> __Method_GetCatagoryDetailInFor = new grpc::Method<global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest, global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCatagoryDetailInFor",
        __Marshaller_catagory_details_management_GetCatagoryDetailInForRequest,
        __Marshaller_catagory_details_management_GetCatagoryDetailInForResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::CatagoryDetailsManagement.CatagoryDetailsManagementReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for CatagoryDetailManager</summary>
    public partial class CatagoryDetailManagerClient : grpc::ClientBase<CatagoryDetailManagerClient>
    {
      /// <summary>Creates a new client for CatagoryDetailManager</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CatagoryDetailManagerClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CatagoryDetailManager that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public CatagoryDetailManagerClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CatagoryDetailManagerClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected CatagoryDetailManagerClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse GetCatagoryDetailInFor(global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetCatagoryDetailInFor(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse GetCatagoryDetailInFor(global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetCatagoryDetailInFor, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse> GetCatagoryDetailInForAsync(global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetCatagoryDetailInForAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse> GetCatagoryDetailInForAsync(global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetCatagoryDetailInFor, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override CatagoryDetailManagerClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CatagoryDetailManagerClient(configuration);
      }
    }

  }
}
#endregion