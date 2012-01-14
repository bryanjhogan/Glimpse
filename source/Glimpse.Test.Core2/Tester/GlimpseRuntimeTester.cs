using Glimpse.Core2;
using Glimpse.Core2.Extensibility;
using Glimpse.Core2.Framework;
using Glimpse.Test.Core2.Extensions;
using Moq;

namespace Glimpse.Test.Core2.Tester
{
    public class GlimpseRuntimeTester : GlimpseRuntime
    {
        public Mock<IFrameworkProvider> FrameworkProviderMock { get; set; }
        public Mock<IGlimpseResourceEndpointConfiguration> EndpointConfigMock { get; set; }
        public Mock<IDataStore> HttpRequestStoreMock { get; set; }
        public Mock<IGlimpseTabMetadata> TabMetadataMock { get; set; }
        public Mock<ITab> TabMock { get; set; }
        public Mock<IGlimpsePipelineInspector> PipelineInspectorMock { get; set; }
        public Mock<IGlimpseSerializer> SerializerMock { get; set; }
        public Mock<IGlimpsePersistanceStore> PersistanceStoreMock { get; set; }
        public Mock<ILogger> LoggerMock { get; set; }
        public Mock<IGlimpseResource> ResourceMock { get; set; }
        public Mock<ResourceResult> ResourceResultMock { get; set; }
        public Mock<IRuntimePolicy> ValidatorMock { get; set; }
        public GlimpseConfiguration Configuration { get; set; }

        private GlimpseRuntimeTester(GlimpseConfiguration configuration, Mock<IFrameworkProvider> frameworkProviderMock, Mock<IGlimpseResourceEndpointConfiguration> endpointConfigMock) : base(configuration)
        {
            FrameworkProviderMock = frameworkProviderMock;
            EndpointConfigMock = endpointConfigMock;
            HttpRequestStoreMock = new Mock<IDataStore>();
            TabMetadataMock = new Mock<IGlimpseTabMetadata>().Setup();
            TabMock = new Mock<ITab>().Setup();
            PipelineInspectorMock = new Mock<IGlimpsePipelineInspector>();
            SerializerMock = new Mock<IGlimpseSerializer>();
            PersistanceStoreMock = new Mock<IGlimpsePersistanceStore>();
            LoggerMock = new Mock<ILogger>();
            ResourceMock = new Mock<IGlimpseResource>();
            ResourceResultMock = new Mock<ResourceResult>();
            ValidatorMock = new Mock<IRuntimePolicy>();
            ValidatorMock.Setup(v => v.Execute(It.IsAny<IRuntimePolicyContext>())).Returns(RuntimePolicy.On);
            
            configuration.Serializer = SerializerMock.Object;
            configuration.PersistanceStore = PersistanceStoreMock.Object;
            configuration.Logger = LoggerMock.Object;
            configuration.BasePolicy = RuntimePolicy.On;
            Configuration = configuration;
        }

        public static GlimpseRuntimeTester Create()
        {
            var frameworkProviderMock = new Mock<IFrameworkProvider>().Setup();
            var endpointConfigMock = new Mock<IGlimpseResourceEndpointConfiguration>();

            var configuration =
                new GlimpseConfiguration(frameworkProviderMock.Object, endpointConfigMock.Object).
                    TurnOffAutoDiscover();
            /*configuration.Serializer = SerializerMock.Object;
            configuration.PersistanceStore = PersistanceStoreMock.Object;
            configuration.Logger = LoggerMock.Object;*/

            return new GlimpseRuntimeTester(configuration, frameworkProviderMock, endpointConfigMock);
        }
    }
}