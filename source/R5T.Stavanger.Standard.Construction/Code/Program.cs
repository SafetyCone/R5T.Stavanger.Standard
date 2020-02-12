using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Chalandri;
using R5T.Evosmos;
using R5T.Richmond;


namespace R5T.Stavanger.Standard.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var serviceProvider = ServiceProviderBuilder.NewUseStartup<Startup>() as ServiceProvider)
            {
                var program = serviceProvider.GetRequiredService<Program>();

                program.Run();
            }
        }


        private void Run()
        {
            var shortcutTargetFilePath = this.TestingDataDirectoryContentPathsProvider.GetBasicTextFilePath();

            var shortcutFilePath = this.TemporaryDirectoryFilePathProvider.GetTemporaryDirectoryFilePath("Testing Text.txt");

            this.ShortcutOperator.CreateShortcut(shortcutFilePath, shortcutTargetFilePath);
        }


        #region Services and Constructor

        private IShortcutOperator ShortcutOperator { get; }
        private ITestingDataDirectoryContentPathsProvider TestingDataDirectoryContentPathsProvider { get; }
        private ITemporaryDirectoryFilePathProvider TemporaryDirectoryFilePathProvider { get; }


        public Program(
            IShortcutOperator shortcutOperator,
            ITestingDataDirectoryContentPathsProvider testingDataDirectoryContentPathsProvider,
            ITemporaryDirectoryFilePathProvider temporaryDirectoryFilePathProvider)
        {
            this.ShortcutOperator = shortcutOperator;
            this.TestingDataDirectoryContentPathsProvider = testingDataDirectoryContentPathsProvider;
            this.TemporaryDirectoryFilePathProvider = temporaryDirectoryFilePathProvider;
        }

        #endregion
    }
}
