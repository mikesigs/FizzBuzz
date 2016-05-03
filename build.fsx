// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"
open Fake
open Fake.Testing

// Properties
let tempDir = "./.tmp"
let buildDir = tempDir @@ "build"
let testDir = tempDir @@ "test"
    
// Functions
let clean() = CleanDirs [tempDir]

let getBuildMode() = getBuildParamOrDefault "buildMode" "Debug"

let build() = 
    trace "Building Projects..."
    !! "**/*.csproj" -- "**/*.Test.csproj"
    |> MSBuild buildDir "Build" ["Configuration", getBuildMode()]
    |> Log "AppBuild-Output: "
  
let buildTests() =
    trace "Building Tests..."
    !! "**/*.Test.csproj"
    |> MSBuild testDir "Build" ["Configuration", getBuildMode()]
    |> Log "TestBuild-Output: "

let runTests() =
    trace "Running Unit Tests..."
    !! (testDir @@ "*.Test.dll")
    |> xUnit2 (fun p -> { p with HtmlOutputPath = Some(testDir @@ "xunit-test-results.html")
                                 ExcludeTraits = if not (hasBuildParam "includeIntegrationTests") 
                                                 then [("TestKind", "Integration")] 
                                                 else XUnit2Defaults.ExcludeTraits })
    
// Targets
Target "Clean" (fun _ -> clean())
Target "Build" (fun _ -> build())
Target "BuildTests" (fun _ -> buildTests())
Target "Test" (fun _ -> runTests())
Target "Default" DoNothing

// Dependencies
"Clean"
    ==> "Build"
    ==> "BuildTests"
    ==> "Test"
    ==> "Default"
    
// start build
RunTargetOrDefault "Default"
