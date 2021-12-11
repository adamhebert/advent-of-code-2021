namespace Day01

[<RequireQualifiedAccess>]
module SonarSweep =
    
    module Part1 =
        let increasedDepthFromPreviousCount predicate =
            Seq.pairwise
            >> Seq.where predicate
            >> Seq.length

    module Part2 =
        let slidingWindowComparison windowSize predicate =
            Seq.windowed windowSize
            >> Part1.increasedDepthFromPreviousCount predicate
