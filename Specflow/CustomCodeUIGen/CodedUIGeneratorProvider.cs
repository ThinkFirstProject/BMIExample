using CodedUIGeneratorProvider.Generator.SpecFlowPlugin;
using TechTalk.SpecFlow.Infrastructure;
[assembly:GeneratorPlugin(typeof(CodedUIGeneratorPlugin))]

namespace CodedUIGeneratorProvider.Generator.SpecFlowPlugin
{
    using System.CodeDom;

    using BoDi;

    using TechTalk.SpecFlow.Generator;
    using TechTalk.SpecFlow.Generator.Configuration;
    using TechTalk.SpecFlow.Generator.Plugins;
    using TechTalk.SpecFlow.Generator.UnitTestProvider;
    using TechTalk.SpecFlow.UnitTestProvider;
    using TechTalk.SpecFlow.Utils;

    /// <summary>
    /// The CodedUI generator plugin.
    /// </summary>
    public class CodedUIGeneratorPlugin : IGeneratorPlugin
    {
        /// <summary>
        /// The register dependencies.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public void RegisterDependencies(ObjectContainer container)
        {
        }

        /// <summary>
        /// The register customizations.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="generatorConfiguration">
        /// The generator configuration.
        /// </param>
        public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            container.RegisterTypeAs<CodedUIGeneratorProvider, IUnitTestGeneratorProvider>();
            container.RegisterTypeAs<MsTest2010RuntimeProvider, IUnitTestRuntimeProvider>();
        }

        /// <summary>
        /// The register configuration defaults.
        /// </summary>
        /// <param name="specFlowConfiguration">
        /// The spec flow configuration.
        /// </param>
        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {
        }
    }

    /// <summary>
    /// The CodedUI generator.
    /// </summary>
    public class CodedUIGeneratorProvider : MsTest2010GeneratorProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodedUiGeneratorProvider"/> class.
        /// </summary>
        /// <param name="codeDomHelper">
        /// The code dom helper.
        /// </param>
        public CodedUIGeneratorProvider(CodeDomHelper codeDomHelper)
            : base(codeDomHelper)
        {
        }

        /// <summary>
        /// The set test class.
        /// </summary>
        /// <param name="generationContext">
        /// The generation context.
        /// </param>
        /// <param name="featureTitle">
        /// The feature title.
        /// </param>
        /// <param name="featureDescription">
        /// The feature description.
        /// </param>
        public override void SetTestClass(TestClassGenerationContext generationContext, string featureTitle, string featureDescription)
        {
            base.SetTestClass(generationContext, featureTitle, featureDescription);

            foreach (CodeAttributeDeclaration declaration in generationContext.TestClass.CustomAttributes)
            {
                if (declaration.Name == "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute")
                {
                    generationContext.TestClass.CustomAttributes.Remove(declaration);
                    break;
                }
            }

            generationContext.TestClass.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference("Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute")));
        }
    }
}

