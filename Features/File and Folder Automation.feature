Feature: File and Folder Automation

  Scenario: Automate folder and file operations
    Given I open File Explorer and navigate to C:\
    When I create a folder named "TrumpfMetamation"
    And I create a file named "Welcome.txt" inside the folder
    And I write "Welcome to Trumpf Metamation!" into the file
    Then I verify the file contains "Welcome to Trumpf Metamation!"
    When I delete the file and folder
    Then I confirm the file and folder are deleted successfully

