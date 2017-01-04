@REM nuget install -outputDirectory Packages NuGet.Server -version 2.11.2
@REM console:  Update-Package -Reinstall
@REM console:  Update-Package -Reinstall -ProjectName <> -IgnoreDependencies

nuget install -outputDirectory Packages   NUnit            -version 3.2.1
nuget install -outputDirectory Packages   NUnit.Mocks      -version 2.6.3
nuget install -outputDirectory Packages   NUnitTestAdapter -version 2.0.0

nuget install -outputDirectory Packages   FluentAssertions -version 4.9.0
nuget install -outputDirectory Packages   NSubstitute -version 1.10.0.0
  
@PAUSE