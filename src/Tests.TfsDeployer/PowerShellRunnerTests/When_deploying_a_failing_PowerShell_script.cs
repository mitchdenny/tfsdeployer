using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using TfsDeployer.DeployAgent;
using TfsDeployer.Journal;
using TfsDeployer.TeamFoundation;

namespace Tests.TfsDeployer.PowerShellRunnerTests
{
    [TestClass]
    public class When_deploying_a_failing_powershell_script
    {
        private static DeployAgentResult DeployFailingPowerShellScript()
        {
            var deploymentEventRecorder = MockRepository.GenerateStub<IDeploymentEventRecorder>();

            using (var scriptFile = new TemporaryFile(".ps1", PowerShellScripts.FailingPowerShellScript))
            {
                var testDeployData = new DeployAgentData
                {
                    NewQuality = "Released",
                    OriginalQuality = null,
                    DeployScriptFile = scriptFile.FileInfo.Name,
                    DeployScriptRoot = scriptFile.FileInfo.DirectoryName,
                    DeployScriptParameters = new List<DeployScriptParameter>(),
                    TfsBuildDetail = new BuildDetail()
                };

                var psAgent = new LocalPowerShellDeployAgent(deploymentEventRecorder);
                return psAgent.Deploy(testDeployData);
            }
        }

        [TestMethod]
        public void Should_output_sufficient_failure_details()
        {
            var result = DeployFailingPowerShellScript();
            Assert.IsTrue(result.HasErrors, "HasErrors");
            StringAssert.Contains(result.Output, "char:", "Output"); // "char:" refers to error position
        }

        [TestMethod]
        public void Should_return_output_generated_prior_to_the_failure_point()
        {
            var result = DeployFailingPowerShellScript();
            Assert.IsTrue(result.HasErrors, "HasErrors");
            StringAssert.Contains(result.Output, "Output this before failing", "Output");
        }

    }
}