// Day 01 - Sonar Sweep
[<RequireQualifiedAccess>]
module Day01_SonarSweep =
    
    open System.IO
    open Day01
    open Utilities
    open Utilities.Parsing

    [<Literal>]
    let Part2_Window = 3

    let execute =
        fun () ->
            let readFile = File.ReadAllLines >> Config.sanitizeLines >> Seq.map parseInt

            // Original.
            let part1_sonarSweep = SonarSweep.Part1.increasedDepthFromPreviousCount (fun (prev, next) -> next > prev)

            let part2_sonarSweep =
                SonarSweep.Part2.slidingWindowComparison
                    Part2_Window
                    (fun (prev, next) ->
                        match (Array.length prev = Part2_Window), (Array.length next = Part2_Window) with
                        | true, true -> (Array.sum next) > (Array.sum prev)
                        | true, false
                        | false, true
                        | false, false -> false)
            

            let demoFileContents = readFile "Input\Day01_DepthsForDemo.txt"
            let actualFileContents = readFile "Input\Day01_DepthsForActual.txt"

            let part1_sonarSweepDemo = part1_sonarSweep demoFileContents
            let part1_sonarSweepActual = part1_sonarSweep actualFileContents

            let part2_sonarSweepDemo = part2_sonarSweep demoFileContents
            let part2_sonarSweepActual = part2_sonarSweep actualFileContents

            printfn $"Day01_Part1_SonarSweep_Demo: {part1_sonarSweepDemo}"
            printfn $"Day01_Part1_SonarSweep_Actual {part1_sonarSweepActual}"
            printfn $"Day01_Part2_SonarSweep_Demo: {part2_sonarSweepDemo}"
            printfn $"Day01_Part2_SonarSweep_Actual: {part2_sonarSweepActual}"

// Day 02 - Dive!
[<RequireQualifiedAccess>]
module Day02_Dive =
    
    open System.IO
    open Day02
    open Utilities
    open Utilities.Parsing

    let execute =

        let fileDirectionToDU =
            [ "forward", Dive.Forward
              "up", Dive.Up
              "down", Dive.Down ]
            |> Map.ofList

        fun () ->
            let readFile =
                File.ReadAllLines
                >> Config.sanitizeLines
                >> Seq.map
                    (String.trim
                     >> (fun str ->
                            let split = str.Split (' ')
                            (fileDirectionToDU |> Map.find split.[0]) (parseInt split.[1])))

            let part1_dive =
                Dive.Part1.calculateHorizontalPositionAndDepth
                >> Dive.multiplyHorizontalByDepth

            let part2_dive =
                Dive.Part2.calculateHorizontalPositionAndDepth
                >> Dive.multiplyHorizontalByDepth

            let demoFileContents = readFile "Input\Day02_DiveForDemo.txt"
            let actualFileContents = readFile "Input\Day02_DiveForActual.txt"

            let part1_diveDemo = part1_dive demoFileContents
            let part1_diveActual = part1_dive actualFileContents

            let part2_diveDemo = part2_dive demoFileContents
            let part2_diveActual = part2_dive actualFileContents

            printfn $"Day02_Part1_Dive_Demo: {part1_diveDemo}"
            printfn $"Day02_Part1_Dive_Actual: {part1_diveActual}"
            printfn $"Day02_Part2_Dive_Demo: {part2_diveDemo}"
            printfn $"Day02_Part2_Dive_Actual: {part2_diveActual}"


Day01_SonarSweep.execute ()
printfn "---------------------------------------------------------"
Day02_Dive.execute ()
