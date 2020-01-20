using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Primavera.Hurakan.Core;
using Primavera.Hurakan.Handlers;

/* 
 * 
 * NOTES: 
 *    Please move this test class and implement tests in the BotHandlers.Tests project.
 *    As soon as you do, the "Microsoft.VisualStudio.QualityTools.UnitTestFramework" reference can be removed from this sample
 *  
*/

namespace Primavera.Bot.PDEXTopic.Tests
{
    [TestClass]
    public class PDEXTopicTests
    {
        [TestMethod]
        [DeploymentItem(@"..\")]
        public void PDEXTopicFirstTaskTest()
        {
            // ... Implement test here
        }

        [TestMethod]
        [DeploymentItem(@"..\")]
        public void TemplatePipelineExecutionExampleTest()
        {
            // Use this test pattern if you wish to test your handlers on a full pipeline.

            // Create Handler List.
            var handlers = new List<IntegrationConfigPipelineHandler>();

            // Add the Load Work Queue Handler
            IntegrationConfigPipelineHandler mockHandlerConfig = new IntegrationConfigPipelineHandler()
            {
                Active = "true",
                Id = "ErpReadConfig",
                Type = "Primavera.Hurakan.Handlers.ErpReadConfig",
                Behavior = "Reader",
                Order = "0",
                ConfigStr = @""
            };
            handlers.Add(mockHandlerConfig);

            // Insert more handlers as required.

            // Create the pipeline.
            IntegrationConfig mockIntegrationConfig = new IntegrationConfig()
            {
                Pipelines = new IntegrationConfigPipeline[1] // one pipeline only for example purposes
                {
                    new IntegrationConfigPipeline()
                    {
                        Active = "true",
                        Id = "123",
                        Handlers = handlers.ToArray()
                    }
                }
            };

            // Create mock integration message
            IMessage msg = new IntegrationMessage();

            // Create pipeline engine and execute it.
            using (PipelineEngine engine = new PipelineEngine("pipelineId", mockIntegrationConfig))
            {
                msg = engine.Execute(msg);
            }
        }

        // ... Implement more test methods as required.
    }
}
