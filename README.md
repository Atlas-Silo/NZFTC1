# NZFTC

NZFTC App RepoPre-populated repo workflow



1\. Clone the repo (contains generator scripts and mock services).

2\. Run scripts\\Generate-ProjectStructure.ps1 -DevName "<YourName>" -ProjectName "NZFTC.EmployeeMgmt" -CreateSampleFiles

3\. Run scripts\\Prepopulate-UserFiles.ps1 -PersonName "<YourName>" -DevRoot ".\\NZFTC.EmployeeMgmt.<YourName>"

4\. Open the solution in Visual Studio 2022, restore NuGet packages and build.

5\. Set appsettings.Development.json UseMocks = true for local UI work without DB.

6\. To switch to real services, set UseMocks = false and provide a valid connection string.

