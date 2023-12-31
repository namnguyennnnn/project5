// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/exercise_management.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ExerciseManagement {

  /// <summary>Holder for reflection information generated from Protos/exercise_management.proto</summary>
  public static partial class ExerciseManagementReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/exercise_management.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ExerciseManagementReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CiBQcm90b3MvZXhlcmNpc2VfbWFuYWdlbWVudC5wcm90bxITZXhlcmNpc2Vf",
            "bWFuYWdlbWVudBobZ29vZ2xlL3Byb3RvYnVmL2VtcHR5LnByb3RvIikKEkdl",
            "dEV4ZXJjaXNlUmVxdWVzdBITCgtleGVyY2lzZV9pZBgBIAEoCSKSAQoTR2V0",
            "RXhlcmNpc2VSZXNwb25zZRITCgtleGVyY2lzZV9pZBgBIAEoCRIaChJjYXRl",
            "Z29yeV9kZXRhaWxfaWQYAiABKAkSGQoRdGl0bGVfb2ZfZXhlcmNpc2UYAyAB",
            "KAkSHAoUZXhlcmNpc2VfZGVzY3JpcHRpb24YBCABKAkSEQoJY3JlYXRlX2F0",
            "GAUgASgJIjQKFkRlbGV0ZUV4ZXJjaXNlc1JlcXVlc3QSGgoSY2F0ZWdvcnlf",
            "ZGV0YWlsX2lkGAEgASgJIikKF0RlbGV0ZUV4ZXJjaXNlc1Jlc3BvbnNlEg4K",
            "BlN0YXR1cxgBIAEoBTLhAQoPRXhlcmNpc2VNYW5hZ2VyEmAKC0dldEV4ZXJj",
            "aXNlEicuZXhlcmNpc2VfbWFuYWdlbWVudC5HZXRFeGVyY2lzZVJlcXVlc3Qa",
            "KC5leGVyY2lzZV9tYW5hZ2VtZW50LkdldEV4ZXJjaXNlUmVzcG9uc2USbAoP",
            "RGVsZXRlRXhlcmNpc2VzEisuZXhlcmNpc2VfbWFuYWdlbWVudC5EZWxldGVF",
            "eGVyY2lzZXNSZXF1ZXN0GiwuZXhlcmNpc2VfbWFuYWdlbWVudC5EZWxldGVF",
            "eGVyY2lzZXNSZXNwb25zZWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ExerciseManagement.GetExerciseRequest), global::ExerciseManagement.GetExerciseRequest.Parser, new[]{ "ExerciseId" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExerciseManagement.GetExerciseResponse), global::ExerciseManagement.GetExerciseResponse.Parser, new[]{ "ExerciseId", "CategoryDetailId", "TitleOfExercise", "ExerciseDescription", "CreateAt" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExerciseManagement.DeleteExercisesRequest), global::ExerciseManagement.DeleteExercisesRequest.Parser, new[]{ "CategoryDetailId" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ExerciseManagement.DeleteExercisesResponse), global::ExerciseManagement.DeleteExercisesResponse.Parser, new[]{ "Status" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetExerciseRequest : pb::IMessage<GetExerciseRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetExerciseRequest> _parser = new pb::MessageParser<GetExerciseRequest>(() => new GetExerciseRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetExerciseRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExerciseManagement.ExerciseManagementReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetExerciseRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetExerciseRequest(GetExerciseRequest other) : this() {
      exerciseId_ = other.exerciseId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetExerciseRequest Clone() {
      return new GetExerciseRequest(this);
    }

    /// <summary>Field number for the "exercise_id" field.</summary>
    public const int ExerciseIdFieldNumber = 1;
    private string exerciseId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ExerciseId {
      get { return exerciseId_; }
      set {
        exerciseId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GetExerciseRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetExerciseRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ExerciseId != other.ExerciseId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ExerciseId.Length != 0) hash ^= ExerciseId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ExerciseId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ExerciseId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ExerciseId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ExerciseId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ExerciseId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ExerciseId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GetExerciseRequest other) {
      if (other == null) {
        return;
      }
      if (other.ExerciseId.Length != 0) {
        ExerciseId = other.ExerciseId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ExerciseId = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            ExerciseId = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class GetExerciseResponse : pb::IMessage<GetExerciseResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetExerciseResponse> _parser = new pb::MessageParser<GetExerciseResponse>(() => new GetExerciseResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetExerciseResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExerciseManagement.ExerciseManagementReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetExerciseResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetExerciseResponse(GetExerciseResponse other) : this() {
      exerciseId_ = other.exerciseId_;
      categoryDetailId_ = other.categoryDetailId_;
      titleOfExercise_ = other.titleOfExercise_;
      exerciseDescription_ = other.exerciseDescription_;
      createAt_ = other.createAt_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetExerciseResponse Clone() {
      return new GetExerciseResponse(this);
    }

    /// <summary>Field number for the "exercise_id" field.</summary>
    public const int ExerciseIdFieldNumber = 1;
    private string exerciseId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ExerciseId {
      get { return exerciseId_; }
      set {
        exerciseId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "category_detail_id" field.</summary>
    public const int CategoryDetailIdFieldNumber = 2;
    private string categoryDetailId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CategoryDetailId {
      get { return categoryDetailId_; }
      set {
        categoryDetailId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "title_of_exercise" field.</summary>
    public const int TitleOfExerciseFieldNumber = 3;
    private string titleOfExercise_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string TitleOfExercise {
      get { return titleOfExercise_; }
      set {
        titleOfExercise_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "exercise_description" field.</summary>
    public const int ExerciseDescriptionFieldNumber = 4;
    private string exerciseDescription_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string ExerciseDescription {
      get { return exerciseDescription_; }
      set {
        exerciseDescription_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "create_at" field.</summary>
    public const int CreateAtFieldNumber = 5;
    private string createAt_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CreateAt {
      get { return createAt_; }
      set {
        createAt_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GetExerciseResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetExerciseResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ExerciseId != other.ExerciseId) return false;
      if (CategoryDetailId != other.CategoryDetailId) return false;
      if (TitleOfExercise != other.TitleOfExercise) return false;
      if (ExerciseDescription != other.ExerciseDescription) return false;
      if (CreateAt != other.CreateAt) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ExerciseId.Length != 0) hash ^= ExerciseId.GetHashCode();
      if (CategoryDetailId.Length != 0) hash ^= CategoryDetailId.GetHashCode();
      if (TitleOfExercise.Length != 0) hash ^= TitleOfExercise.GetHashCode();
      if (ExerciseDescription.Length != 0) hash ^= ExerciseDescription.GetHashCode();
      if (CreateAt.Length != 0) hash ^= CreateAt.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ExerciseId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ExerciseId);
      }
      if (CategoryDetailId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CategoryDetailId);
      }
      if (TitleOfExercise.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(TitleOfExercise);
      }
      if (ExerciseDescription.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(ExerciseDescription);
      }
      if (CreateAt.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(CreateAt);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ExerciseId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(ExerciseId);
      }
      if (CategoryDetailId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CategoryDetailId);
      }
      if (TitleOfExercise.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(TitleOfExercise);
      }
      if (ExerciseDescription.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(ExerciseDescription);
      }
      if (CreateAt.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(CreateAt);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ExerciseId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ExerciseId);
      }
      if (CategoryDetailId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CategoryDetailId);
      }
      if (TitleOfExercise.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(TitleOfExercise);
      }
      if (ExerciseDescription.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ExerciseDescription);
      }
      if (CreateAt.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CreateAt);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GetExerciseResponse other) {
      if (other == null) {
        return;
      }
      if (other.ExerciseId.Length != 0) {
        ExerciseId = other.ExerciseId;
      }
      if (other.CategoryDetailId.Length != 0) {
        CategoryDetailId = other.CategoryDetailId;
      }
      if (other.TitleOfExercise.Length != 0) {
        TitleOfExercise = other.TitleOfExercise;
      }
      if (other.ExerciseDescription.Length != 0) {
        ExerciseDescription = other.ExerciseDescription;
      }
      if (other.CreateAt.Length != 0) {
        CreateAt = other.CreateAt;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            ExerciseId = input.ReadString();
            break;
          }
          case 18: {
            CategoryDetailId = input.ReadString();
            break;
          }
          case 26: {
            TitleOfExercise = input.ReadString();
            break;
          }
          case 34: {
            ExerciseDescription = input.ReadString();
            break;
          }
          case 42: {
            CreateAt = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            ExerciseId = input.ReadString();
            break;
          }
          case 18: {
            CategoryDetailId = input.ReadString();
            break;
          }
          case 26: {
            TitleOfExercise = input.ReadString();
            break;
          }
          case 34: {
            ExerciseDescription = input.ReadString();
            break;
          }
          case 42: {
            CreateAt = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class DeleteExercisesRequest : pb::IMessage<DeleteExercisesRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<DeleteExercisesRequest> _parser = new pb::MessageParser<DeleteExercisesRequest>(() => new DeleteExercisesRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<DeleteExercisesRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExerciseManagement.ExerciseManagementReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteExercisesRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteExercisesRequest(DeleteExercisesRequest other) : this() {
      categoryDetailId_ = other.categoryDetailId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteExercisesRequest Clone() {
      return new DeleteExercisesRequest(this);
    }

    /// <summary>Field number for the "category_detail_id" field.</summary>
    public const int CategoryDetailIdFieldNumber = 1;
    private string categoryDetailId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CategoryDetailId {
      get { return categoryDetailId_; }
      set {
        categoryDetailId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as DeleteExercisesRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(DeleteExercisesRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CategoryDetailId != other.CategoryDetailId) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (CategoryDetailId.Length != 0) hash ^= CategoryDetailId.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (CategoryDetailId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CategoryDetailId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (CategoryDetailId.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(CategoryDetailId);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (CategoryDetailId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CategoryDetailId);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(DeleteExercisesRequest other) {
      if (other == null) {
        return;
      }
      if (other.CategoryDetailId.Length != 0) {
        CategoryDetailId = other.CategoryDetailId;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            CategoryDetailId = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            CategoryDetailId = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class DeleteExercisesResponse : pb::IMessage<DeleteExercisesResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<DeleteExercisesResponse> _parser = new pb::MessageParser<DeleteExercisesResponse>(() => new DeleteExercisesResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<DeleteExercisesResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ExerciseManagement.ExerciseManagementReflection.Descriptor.MessageTypes[3]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteExercisesResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteExercisesResponse(DeleteExercisesResponse other) : this() {
      status_ = other.status_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public DeleteExercisesResponse Clone() {
      return new DeleteExercisesResponse(this);
    }

    /// <summary>Field number for the "Status" field.</summary>
    public const int StatusFieldNumber = 1;
    private int status_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int Status {
      get { return status_; }
      set {
        status_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as DeleteExercisesResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(DeleteExercisesResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Status != other.Status) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Status != 0) hash ^= Status.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Status != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Status);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Status != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Status);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (Status != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Status);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(DeleteExercisesResponse other) {
      if (other == null) {
        return;
      }
      if (other.Status != 0) {
        Status = other.Status;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Status = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Status = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
