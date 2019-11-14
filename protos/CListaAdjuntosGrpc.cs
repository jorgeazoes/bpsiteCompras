// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: CListaAdjuntos.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace PROYCUATRO {
  public static partial class CListaAdjuntosService
  {
    static readonly string __ServiceName = "CListaAdjuntosService";

    static readonly grpc::Marshaller<global::PROYCUATRO.GetCAdjuntosRequest> __Marshaller_GetCAdjuntosRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PROYCUATRO.GetCAdjuntosRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PROYCUATRO.GetCAdjuntosResponse> __Marshaller_GetCAdjuntosResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PROYCUATRO.GetCAdjuntosResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::PROYCUATRO.GetCAdjuntosRequest, global::PROYCUATRO.GetCAdjuntosResponse> __Method_GetAdjuntos = new grpc::Method<global::PROYCUATRO.GetCAdjuntosRequest, global::PROYCUATRO.GetCAdjuntosResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetAdjuntos",
        __Marshaller_GetCAdjuntosRequest,
        __Marshaller_GetCAdjuntosResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PROYCUATRO.CListaAdjuntosReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CListaAdjuntosService</summary>
    [grpc::BindServiceMethod(typeof(CListaAdjuntosService), "BindService")]
    public abstract partial class CListaAdjuntosServiceBase
    {
      public virtual global::System.Threading.Tasks.Task GetAdjuntos(global::PROYCUATRO.GetCAdjuntosRequest request, grpc::IServerStreamWriter<global::PROYCUATRO.GetCAdjuntosResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for CListaAdjuntosService</summary>
    public partial class CListaAdjuntosServiceClient : grpc::ClientBase<CListaAdjuntosServiceClient>
    {
      /// <summary>Creates a new client for CListaAdjuntosService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public CListaAdjuntosServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for CListaAdjuntosService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public CListaAdjuntosServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected CListaAdjuntosServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected CListaAdjuntosServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::PROYCUATRO.GetCAdjuntosResponse> GetAdjuntos(global::PROYCUATRO.GetCAdjuntosRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAdjuntos(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::PROYCUATRO.GetCAdjuntosResponse> GetAdjuntos(global::PROYCUATRO.GetCAdjuntosRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetAdjuntos, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override CListaAdjuntosServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new CListaAdjuntosServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(CListaAdjuntosServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetAdjuntos, serviceImpl.GetAdjuntos).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CListaAdjuntosServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetAdjuntos, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::PROYCUATRO.GetCAdjuntosRequest, global::PROYCUATRO.GetCAdjuntosResponse>(serviceImpl.GetAdjuntos));
    }

  }
}
#endregion
