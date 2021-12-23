using DotnetActionsToolkit;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace dotnet_sample_action
{
    public class Program
    {
        static readonly Core _core = new Core();

        static async Task Main(string[] args)
        {
            try
            {

                var repository = _core.GetInput("repository");
                _core.Info($"Repo is: {repository}");

                var split = repository.Split("/");
                var owner = split[0];
                var repositoryName = split[1];
                _core.Info($"Owner is: {owner} and repository name is: {repositoryName}");

                var pullRequestNumber = _core.GetInput("pullRequestNumber");
                _core.Info($"PR is: {pullRequestNumber}");

                var ctx = _core.GetInput("ctx");
                _core.Info("Context");
                _core.Info("-----------------------------------");
                _core.Info($"{ctx}");
                _core.Info("-----------------------------------");

                var ms = _core.GetInput("milliseconds");
                 _core.Debug($"Waiting {ms} milliseconds..."); // debug is only output if you set teh secret ACTIONS_RUNNER_DEBUG to true

                 _core.Debug(DateTime.Now.ToLongTimeString());
                 await Task.Delay(int.Parse(ms));
                 _core.Debug(DateTime.Now.ToLongTimeString());

                 _core.SetOutput("time", DateTime.Now.ToLongTimeString());
            }
            catch (Exception ex)
            {
                _core.SetFailed(ex.Message);
            }
        }
    }
}
