// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/catagory_details_management.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace CatagoryDetailsManagement {

  /// <summary>Holder for reflection information generated from Protos/catagory_details_management.proto</summary>
  public static partial class CatagoryDetailsManagementReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/catagory_details_management.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static CatagoryDetailsManagementReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CihQcm90b3MvY2F0YWdvcnlfZGV0YWlsc19tYW5hZ2VtZW50LnByb3RvEhtj",
            "YXRhZ29yeV9kZXRhaWxzX21hbmFnZW1lbnQaG2dvb2dsZS9wcm90b2J1Zi9l",
            "bXB0eS5wcm90byI7Ch1HZXRDYXRhZ29yeURldGFpbEluRm9yUmVxdWVzdBIa",
            "ChJjYXRlZ29yeV9kZXRhaWxfaWQYASABKAkihgEKHkdldENhdGFnb3J5RGV0",
            "YWlsSW5Gb3JSZXNwb25zZRIaChJjYXRlZ29yeV9kZXRhaWxfaWQYASABKAkS",
            "HAoUY2F0ZWdvcnlfZGV0YWlsX25hbWUYAiABKAkSEwoLY2F0ZWdvcnlfaWQY",
            "AyABKAkSFQoNY2F0ZWdvcnlfbmFtZRgEIAEoCTKrAQoVQ2F0YWdvcnlEZXRh",
            "aWxNYW5hZ2VyEpEBChZHZXRDYXRhZ29yeURldGFpbEluRm9yEjouY2F0YWdv",
            "cnlfZGV0YWlsc19tYW5hZ2VtZW50LkdldENhdGFnb3J5RGV0YWlsSW5Gb3JS",
            "ZXF1ZXN0GjsuY2F0YWdvcnlfZGV0YWlsc19tYW5hZ2VtZW50LkdldENhdGFn",
            "b3J5RGV0YWlsSW5Gb3JSZXNwb25zZWIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.EmptyReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest), global::CatagoryDetailsManagement.GetCatagoryDetailInForRequest.Parser, new[]{ "CategoryDetailId" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse), global::CatagoryDetailsManagement.GetCatagoryDetailInForResponse.Parser, new[]{ "CategoryDetailId", "CategoryDetailName", "CategoryId", "CategoryName" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetCatagoryDetailInForRequest : pb::IMessage<GetCatagoryDetailInForRequest>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetCatagoryDetailInForRequest> _parser = new pb::MessageParser<GetCatagoryDetailInForRequest>(() => new GetCatagoryDetailInForRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetCatagoryDetailInForRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CatagoryDetailsManagement.CatagoryDetailsManagementReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetCatagoryDetailInForRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetCatagoryDetailInForRequest(GetCatagoryDetailInForRequest other) : this() {
      categoryDetailId_ = other.categoryDetailId_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetCatagoryDetailInForRequest Clone() {
      return new GetCatagoryDetailInForRequest(this);
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
      return Equals(other as GetCatagoryDetailInForRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetCatagoryDetailInForRequest other) {
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
    public void MergeFrom(GetCatagoryDetailInForRequest other) {
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

  public sealed partial class GetCatagoryDetailInForResponse : pb::IMessage<GetCatagoryDetailInForResponse>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<GetCatagoryDetailInForResponse> _parser = new pb::MessageParser<GetCatagoryDetailInForResponse>(() => new GetCatagoryDetailInForResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<GetCatagoryDetailInForResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::CatagoryDetailsManagement.CatagoryDetailsManagementReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetCatagoryDetailInForResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetCatagoryDetailInForResponse(GetCatagoryDetailInForResponse other) : this() {
      categoryDetailId_ = other.categoryDetailId_;
      categoryDetailName_ = other.categoryDetailName_;
      categoryId_ = other.categoryId_;
      categoryName_ = other.categoryName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public GetCatagoryDetailInForResponse Clone() {
      return new GetCatagoryDetailInForResponse(this);
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

    /// <summary>Field number for the "category_detail_name" field.</summary>
    public const int CategoryDetailNameFieldNumber = 2;
    private string categoryDetailName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CategoryDetailName {
      get { return categoryDetailName_; }
      set {
        categoryDetailName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "category_id" field.</summary>
    public const int CategoryIdFieldNumber = 3;
    private string categoryId_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CategoryId {
      get { return categoryId_; }
      set {
        categoryId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "category_name" field.</summary>
    public const int CategoryNameFieldNumber = 4;
    private string categoryName_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public string CategoryName {
      get { return categoryName_; }
      set {
        categoryName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as GetCatagoryDetailInForResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(GetCatagoryDetailInForResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (CategoryDetailId != other.CategoryDetailId) return false;
      if (CategoryDetailName != other.CategoryDetailName) return false;
      if (CategoryId != other.CategoryId) return false;
      if (CategoryName != other.CategoryName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (CategoryDetailId.Length != 0) hash ^= CategoryDetailId.GetHashCode();
      if (CategoryDetailName.Length != 0) hash ^= CategoryDetailName.GetHashCode();
      if (CategoryId.Length != 0) hash ^= CategoryId.GetHashCode();
      if (CategoryName.Length != 0) hash ^= CategoryName.GetHashCode();
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
      if (CategoryDetailName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CategoryDetailName);
      }
      if (CategoryId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(CategoryId);
      }
      if (CategoryName.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(CategoryName);
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
      if (CategoryDetailName.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(CategoryDetailName);
      }
      if (CategoryId.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(CategoryId);
      }
      if (CategoryName.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(CategoryName);
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
      if (CategoryDetailName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CategoryDetailName);
      }
      if (CategoryId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CategoryId);
      }
      if (CategoryName.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CategoryName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(GetCatagoryDetailInForResponse other) {
      if (other == null) {
        return;
      }
      if (other.CategoryDetailId.Length != 0) {
        CategoryDetailId = other.CategoryDetailId;
      }
      if (other.CategoryDetailName.Length != 0) {
        CategoryDetailName = other.CategoryDetailName;
      }
      if (other.CategoryId.Length != 0) {
        CategoryId = other.CategoryId;
      }
      if (other.CategoryName.Length != 0) {
        CategoryName = other.CategoryName;
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
          case 18: {
            CategoryDetailName = input.ReadString();
            break;
          }
          case 26: {
            CategoryId = input.ReadString();
            break;
          }
          case 34: {
            CategoryName = input.ReadString();
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
          case 18: {
            CategoryDetailName = input.ReadString();
            break;
          }
          case 26: {
            CategoryId = input.ReadString();
            break;
          }
          case 34: {
            CategoryName = input.ReadString();
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
