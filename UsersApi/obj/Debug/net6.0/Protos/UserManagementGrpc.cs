// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user_management.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace UserManagement {
  public static partial class UserManager
  {
    static readonly string __ServiceName = "user_management.UserManager";

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
    static readonly grpc::Marshaller<global::UserManagement.GetUserByEmailRequest> __Marshaller_user_management_GetUserByEmailRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.GetUserByEmailRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.GetUserByEmailResponse> __Marshaller_user_management_GetUserByEmailResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.GetUserByEmailResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.GetUsersByIdsRequest> __Marshaller_user_management_GetUsersByIdsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.GetUsersByIdsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.GetUsersByIdsResponse> __Marshaller_user_management_GetUsersByIdsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.GetUsersByIdsResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.AddUserRequest> __Marshaller_user_management_AddUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.AddUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.AddUserResponse> __Marshaller_user_management_AddUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.AddUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.VerifyAccountRequest> __Marshaller_user_management_VerifyAccountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.VerifyAccountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.VerifyAccountResponse> __Marshaller_user_management_VerifyAccountResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.VerifyAccountResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.GetTotalCommentsRequest> __Marshaller_user_management_GetTotalCommentsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.GetTotalCommentsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.GetTotalCommentsResponse> __Marshaller_user_management_GetTotalCommentsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.GetTotalCommentsResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.UpdatePasswordRequest> __Marshaller_user_management_UpdatePasswordRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.UpdatePasswordRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::UserManagement.UpdatePasswordResponse> __Marshaller_user_management_UpdatePasswordResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::UserManagement.UpdatePasswordResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::UserManagement.GetUserByEmailRequest, global::UserManagement.GetUserByEmailResponse> __Method_GetUserByEmail = new grpc::Method<global::UserManagement.GetUserByEmailRequest, global::UserManagement.GetUserByEmailResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUserByEmail",
        __Marshaller_user_management_GetUserByEmailRequest,
        __Marshaller_user_management_GetUserByEmailResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::UserManagement.GetUsersByIdsRequest, global::UserManagement.GetUsersByIdsResponse> __Method_GetUsersByIds = new grpc::Method<global::UserManagement.GetUsersByIdsRequest, global::UserManagement.GetUsersByIdsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUsersByIds",
        __Marshaller_user_management_GetUsersByIdsRequest,
        __Marshaller_user_management_GetUsersByIdsResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::UserManagement.AddUserRequest, global::UserManagement.AddUserResponse> __Method_AddUser = new grpc::Method<global::UserManagement.AddUserRequest, global::UserManagement.AddUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddUser",
        __Marshaller_user_management_AddUserRequest,
        __Marshaller_user_management_AddUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::UserManagement.VerifyAccountRequest, global::UserManagement.VerifyAccountResponse> __Method_VerifyAccount = new grpc::Method<global::UserManagement.VerifyAccountRequest, global::UserManagement.VerifyAccountResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "VerifyAccount",
        __Marshaller_user_management_VerifyAccountRequest,
        __Marshaller_user_management_VerifyAccountResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::UserManagement.GetTotalCommentsRequest, global::UserManagement.GetTotalCommentsResponse> __Method_GetTotalComments = new grpc::Method<global::UserManagement.GetTotalCommentsRequest, global::UserManagement.GetTotalCommentsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetTotalComments",
        __Marshaller_user_management_GetTotalCommentsRequest,
        __Marshaller_user_management_GetTotalCommentsResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::UserManagement.UpdatePasswordRequest, global::UserManagement.UpdatePasswordResponse> __Method_UpdatePassword = new grpc::Method<global::UserManagement.UpdatePasswordRequest, global::UserManagement.UpdatePasswordResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdatePassword",
        __Marshaller_user_management_UpdatePasswordRequest,
        __Marshaller_user_management_UpdatePasswordResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::UserManagement.UserManagementReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of UserManager</summary>
    [grpc::BindServiceMethod(typeof(UserManager), "BindService")]
    public abstract partial class UserManagerBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::UserManagement.GetUserByEmailResponse> GetUserByEmail(global::UserManagement.GetUserByEmailRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::UserManagement.GetUsersByIdsResponse> GetUsersByIds(global::UserManagement.GetUsersByIdsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::UserManagement.AddUserResponse> AddUser(global::UserManagement.AddUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::UserManagement.VerifyAccountResponse> VerifyAccount(global::UserManagement.VerifyAccountRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::UserManagement.GetTotalCommentsResponse> GetTotalComments(global::UserManagement.GetTotalCommentsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::UserManagement.UpdatePasswordResponse> UpdatePassword(global::UserManagement.UpdatePasswordRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(UserManagerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetUserByEmail, serviceImpl.GetUserByEmail)
          .AddMethod(__Method_GetUsersByIds, serviceImpl.GetUsersByIds)
          .AddMethod(__Method_AddUser, serviceImpl.AddUser)
          .AddMethod(__Method_VerifyAccount, serviceImpl.VerifyAccount)
          .AddMethod(__Method_GetTotalComments, serviceImpl.GetTotalComments)
          .AddMethod(__Method_UpdatePassword, serviceImpl.UpdatePassword).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, UserManagerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetUserByEmail, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserManagement.GetUserByEmailRequest, global::UserManagement.GetUserByEmailResponse>(serviceImpl.GetUserByEmail));
      serviceBinder.AddMethod(__Method_GetUsersByIds, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserManagement.GetUsersByIdsRequest, global::UserManagement.GetUsersByIdsResponse>(serviceImpl.GetUsersByIds));
      serviceBinder.AddMethod(__Method_AddUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserManagement.AddUserRequest, global::UserManagement.AddUserResponse>(serviceImpl.AddUser));
      serviceBinder.AddMethod(__Method_VerifyAccount, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserManagement.VerifyAccountRequest, global::UserManagement.VerifyAccountResponse>(serviceImpl.VerifyAccount));
      serviceBinder.AddMethod(__Method_GetTotalComments, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserManagement.GetTotalCommentsRequest, global::UserManagement.GetTotalCommentsResponse>(serviceImpl.GetTotalComments));
      serviceBinder.AddMethod(__Method_UpdatePassword, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::UserManagement.UpdatePasswordRequest, global::UserManagement.UpdatePasswordResponse>(serviceImpl.UpdatePassword));
    }

  }
}
#endregion