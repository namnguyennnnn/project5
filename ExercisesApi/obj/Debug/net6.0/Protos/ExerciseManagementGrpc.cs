// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/exercise_management.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ExerciseManagement {
  public static partial class ExerciseManager
  {
    static readonly string __ServiceName = "exercise_management.ExerciseManager";

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
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExerciseRequest> __Marshaller_exercise_management_GetExerciseRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExerciseRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExerciseResponse> __Marshaller_exercise_management_GetExerciseResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExerciseResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.DeleteExercisesRequest> __Marshaller_exercise_management_DeleteExercisesRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.DeleteExercisesRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.DeleteExercisesResponse> __Marshaller_exercise_management_DeleteExercisesResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.DeleteExercisesResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsByUserIdRequest> __Marshaller_exercise_management_GetExamResultsByUserIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsByUserIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsByUserIdResponse> __Marshaller_exercise_management_GetExamResultsByUserIdResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsByUserIdResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdRequest> __Marshaller_exercise_management_GetExamResultsFromTimeRangeByUserIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdResponse> __Marshaller_exercise_management_GetExamResultsFromTimeRangeByUserIdResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsByIdRequest> __Marshaller_exercise_management_GetExamResultsByIdRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsByIdRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsByIdResponse> __Marshaller_exercise_management_GetExamResultsByIdResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsByIdResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResquest> __Marshaller_exercise_management_GetExamResultsByExerciseIdAndUidResquest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResquest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResponse> __Marshaller_exercise_management_GetExamResultsByExerciseIdAndUidResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.DeleteExamResultRequest> __Marshaller_exercise_management_DeleteExamResultRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.DeleteExamResultRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.DeleteExamResultResponse> __Marshaller_exercise_management_DeleteExamResultResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.DeleteExamResultResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.DeleteExamResultsRequest> __Marshaller_exercise_management_DeleteExamResultsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.DeleteExamResultsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ExerciseManagement.DeleteExamResultsResponse> __Marshaller_exercise_management_DeleteExamResultsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ExerciseManagement.DeleteExamResultsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.GetExerciseRequest, global::ExerciseManagement.GetExerciseResponse> __Method_GetExercise = new grpc::Method<global::ExerciseManagement.GetExerciseRequest, global::ExerciseManagement.GetExerciseResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExercise",
        __Marshaller_exercise_management_GetExerciseRequest,
        __Marshaller_exercise_management_GetExerciseResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.DeleteExercisesRequest, global::ExerciseManagement.DeleteExercisesResponse> __Method_DeleteExercises = new grpc::Method<global::ExerciseManagement.DeleteExercisesRequest, global::ExerciseManagement.DeleteExercisesResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteExercises",
        __Marshaller_exercise_management_DeleteExercisesRequest,
        __Marshaller_exercise_management_DeleteExercisesResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.GetExamResultsByUserIdRequest, global::ExerciseManagement.GetExamResultsByUserIdResponse> __Method_GetExamResultsByUserId = new grpc::Method<global::ExerciseManagement.GetExamResultsByUserIdRequest, global::ExerciseManagement.GetExamResultsByUserIdResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExamResultsByUserId",
        __Marshaller_exercise_management_GetExamResultsByUserIdRequest,
        __Marshaller_exercise_management_GetExamResultsByUserIdResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdRequest, global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdResponse> __Method_GetExamResultsFromTimeRangeByUserId = new grpc::Method<global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdRequest, global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExamResultsFromTimeRangeByUserId",
        __Marshaller_exercise_management_GetExamResultsFromTimeRangeByUserIdRequest,
        __Marshaller_exercise_management_GetExamResultsFromTimeRangeByUserIdResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.GetExamResultsByIdRequest, global::ExerciseManagement.GetExamResultsByIdResponse> __Method_GetExamResultsById = new grpc::Method<global::ExerciseManagement.GetExamResultsByIdRequest, global::ExerciseManagement.GetExamResultsByIdResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExamResultsById",
        __Marshaller_exercise_management_GetExamResultsByIdRequest,
        __Marshaller_exercise_management_GetExamResultsByIdResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResquest, global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResponse> __Method_GetExamResultsByExerciseIdAndUid = new grpc::Method<global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResquest, global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetExamResultsByExerciseIdAndUid",
        __Marshaller_exercise_management_GetExamResultsByExerciseIdAndUidResquest,
        __Marshaller_exercise_management_GetExamResultsByExerciseIdAndUidResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.DeleteExamResultRequest, global::ExerciseManagement.DeleteExamResultResponse> __Method_DeleteExamResult = new grpc::Method<global::ExerciseManagement.DeleteExamResultRequest, global::ExerciseManagement.DeleteExamResultResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteExamResult",
        __Marshaller_exercise_management_DeleteExamResultRequest,
        __Marshaller_exercise_management_DeleteExamResultResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ExerciseManagement.DeleteExamResultsRequest, global::ExerciseManagement.DeleteExamResultsResponse> __Method_DeleteExamResults = new grpc::Method<global::ExerciseManagement.DeleteExamResultsRequest, global::ExerciseManagement.DeleteExamResultsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteExamResults",
        __Marshaller_exercise_management_DeleteExamResultsRequest,
        __Marshaller_exercise_management_DeleteExamResultsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ExerciseManagement.ExerciseManagementReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ExerciseManager</summary>
    [grpc::BindServiceMethod(typeof(ExerciseManager), "BindService")]
    public abstract partial class ExerciseManagerBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.GetExerciseResponse> GetExercise(global::ExerciseManagement.GetExerciseRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.DeleteExercisesResponse> DeleteExercises(global::ExerciseManagement.DeleteExercisesRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.GetExamResultsByUserIdResponse> GetExamResultsByUserId(global::ExerciseManagement.GetExamResultsByUserIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdResponse> GetExamResultsFromTimeRangeByUserId(global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.GetExamResultsByIdResponse> GetExamResultsById(global::ExerciseManagement.GetExamResultsByIdRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResponse> GetExamResultsByExerciseIdAndUid(global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResquest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.DeleteExamResultResponse> DeleteExamResult(global::ExerciseManagement.DeleteExamResultRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ExerciseManagement.DeleteExamResultsResponse> DeleteExamResults(global::ExerciseManagement.DeleteExamResultsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ExerciseManagerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetExercise, serviceImpl.GetExercise)
          .AddMethod(__Method_DeleteExercises, serviceImpl.DeleteExercises)
          .AddMethod(__Method_GetExamResultsByUserId, serviceImpl.GetExamResultsByUserId)
          .AddMethod(__Method_GetExamResultsFromTimeRangeByUserId, serviceImpl.GetExamResultsFromTimeRangeByUserId)
          .AddMethod(__Method_GetExamResultsById, serviceImpl.GetExamResultsById)
          .AddMethod(__Method_GetExamResultsByExerciseIdAndUid, serviceImpl.GetExamResultsByExerciseIdAndUid)
          .AddMethod(__Method_DeleteExamResult, serviceImpl.DeleteExamResult)
          .AddMethod(__Method_DeleteExamResults, serviceImpl.DeleteExamResults).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ExerciseManagerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetExercise, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.GetExerciseRequest, global::ExerciseManagement.GetExerciseResponse>(serviceImpl.GetExercise));
      serviceBinder.AddMethod(__Method_DeleteExercises, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.DeleteExercisesRequest, global::ExerciseManagement.DeleteExercisesResponse>(serviceImpl.DeleteExercises));
      serviceBinder.AddMethod(__Method_GetExamResultsByUserId, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.GetExamResultsByUserIdRequest, global::ExerciseManagement.GetExamResultsByUserIdResponse>(serviceImpl.GetExamResultsByUserId));
      serviceBinder.AddMethod(__Method_GetExamResultsFromTimeRangeByUserId, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdRequest, global::ExerciseManagement.GetExamResultsFromTimeRangeByUserIdResponse>(serviceImpl.GetExamResultsFromTimeRangeByUserId));
      serviceBinder.AddMethod(__Method_GetExamResultsById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.GetExamResultsByIdRequest, global::ExerciseManagement.GetExamResultsByIdResponse>(serviceImpl.GetExamResultsById));
      serviceBinder.AddMethod(__Method_GetExamResultsByExerciseIdAndUid, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResquest, global::ExerciseManagement.GetExamResultsByExerciseIdAndUidResponse>(serviceImpl.GetExamResultsByExerciseIdAndUid));
      serviceBinder.AddMethod(__Method_DeleteExamResult, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.DeleteExamResultRequest, global::ExerciseManagement.DeleteExamResultResponse>(serviceImpl.DeleteExamResult));
      serviceBinder.AddMethod(__Method_DeleteExamResults, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ExerciseManagement.DeleteExamResultsRequest, global::ExerciseManagement.DeleteExamResultsResponse>(serviceImpl.DeleteExamResults));
    }

  }
}
#endregion
