// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: COrdenesCompra.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace PROYCUATRO {
  public static partial class OrdenesCompraService
  {
    static readonly string __ServiceName = "OrdenesCompraService";

    static readonly grpc::Marshaller<global::PROYCUATRO.GetOrdenesRequest> __Marshaller_GetOrdenesRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PROYCUATRO.GetOrdenesRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::PROYCUATRO.GetOrdenesResponse> __Marshaller_GetOrdenesResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::PROYCUATRO.GetOrdenesResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::PROYCUATRO.GetOrdenesRequest, global::PROYCUATRO.GetOrdenesResponse> __Method_GetOrdenes = new grpc::Method<global::PROYCUATRO.GetOrdenesRequest, global::PROYCUATRO.GetOrdenesResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetOrdenes",
        __Marshaller_GetOrdenesRequest,
        __Marshaller_GetOrdenesResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::PROYCUATRO.COrdenesCompraReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of OrdenesCompraService</summary>
    [grpc::BindServiceMethod(typeof(OrdenesCompraService), "BindService")]
    public abstract partial class OrdenesCompraServiceBase
    {
      public virtual global::System.Threading.Tasks.Task GetOrdenes(global::PROYCUATRO.GetOrdenesRequest request, grpc::IServerStreamWriter<global::PROYCUATRO.GetOrdenesResponse> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for OrdenesCompraService</summary>
    public partial class OrdenesCompraServiceClient : grpc::ClientBase<OrdenesCompraServiceClient>
    {
      /// <summary>Creates a new client for OrdenesCompraService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public OrdenesCompraServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for OrdenesCompraService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public OrdenesCompraServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected OrdenesCompraServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected OrdenesCompraServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual grpc::AsyncServerStreamingCall<global::PROYCUATRO.GetOrdenesResponse> GetOrdenes(global::PROYCUATRO.GetOrdenesRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOrdenes(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::PROYCUATRO.GetOrdenesResponse> GetOrdenes(global::PROYCUATRO.GetOrdenesRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetOrdenes, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override OrdenesCompraServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new OrdenesCompraServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(OrdenesCompraServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetOrdenes, serviceImpl.GetOrdenes).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, OrdenesCompraServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetOrdenes, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::PROYCUATRO.GetOrdenesRequest, global::PROYCUATRO.GetOrdenesResponse>(serviceImpl.GetOrdenes));
    }

  }
}
#endregion
