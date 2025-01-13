using System.Diagnostics;
using System.IO;
using System.Threading;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TrumpfMetamation_Task1.StepDefinitions
{
    [Binding]
    public class FileAutomationSteps
    {
        private readonly string folderPath = @"C:\TrumpfMetamation";
        private readonly string filePath = @"C:\TrumpfMetamation\Welcome.txt";

        [Given(@"I open File Explorer and navigate to C:\\")]
        public void GivenIOpenFileExplorerAndNavigateToC()
        {
            // Open File Explorer and navigate to C:\
            Process.Start("explorer.exe", "C:\\");
            Thread.Sleep(5000); // Wait for File Explorer to open
        }

        [When(@"I create a folder named ""(.*)""")]
        public void WhenICreateAFolderNamed(string folderName)
        {
            // Create the folder
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                Assert.IsTrue(Directory.Exists(folderPath), "Folder creation failed.");
            }
        }

        [When(@"I create a file named ""(.*)"" inside the folder")]
        public void WhenICreateAFileNamedInsideTheFolder(string fileName)
        {
            // Create the file
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, string.Empty);
                Assert.IsTrue(File.Exists(filePath), "File creation failed.");
            }
        }

        [When(@"I write ""(.*)"" into the file")]
        public void WhenIWriteIntoTheFile(string content)
        {
            // Write content to the file
            File.WriteAllText(filePath, content);
        }

        [Then(@"I verify the file contains ""(.*)""")]
        public void ThenIVerifyTheFileContains(string expectedContent)
        {
            // Read content from the file and verify
            string fileContent = File.ReadAllText(filePath);
            Assert.AreEqual(expectedContent, fileContent, "File content verification failed.");
        }

        [When(@"I delete the file and folder")]
        public void WhenIDeleteTheFileAndFolder()
        {
            // Delete the file and folder
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath);
            }
        }

        [Then(@"I confirm the file and folder are deleted successfully")]
        public void ThenIConfirmTheFileAndFolderAreDeletedSuccessfully()
        {
            // Confirm deletion
            Assert.IsFalse(File.Exists(filePath), "File was not deleted successfully.");
            Assert.IsFalse(Directory.Exists(folderPath), "Folder was not deleted successfully.");
        }
    }
}
