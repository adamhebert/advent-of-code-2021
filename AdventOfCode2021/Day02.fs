namespace Day02

[<RequireQualifiedAccess>]
module Dive =
    
    type Direction =
        | Forward of int
        | Up of int
        | Down of int

    let multiplyHorizontalByDepth (horizontal, depth) = horizontal * depth

    module Part1 =

        let calculateHorizontalPositionAndDepth directions =
            directions
            |> Seq.fold
                (fun (horizontal, depth) movement ->
                    match movement with
                    | Forward forward -> horizontal + forward, depth
                    | Up up -> horizontal, depth - up
                    | Down down -> horizontal, depth + down)
                (0, 0)

    module Part2 =
        
        let calculateHorizontalPositionAndDepth directions =
            directions
            |> Seq.fold
                (fun (horizontal, depth, aim) movement ->
                    match movement with
                    | Forward forward -> horizontal + forward, depth + (aim * forward), aim
                    | Up up -> horizontal, depth, aim - up
                    | Down down -> horizontal, depth, aim + down)
                (0, 0, 0)
            |> (fun (horizontal, depth, _) -> horizontal, depth)
