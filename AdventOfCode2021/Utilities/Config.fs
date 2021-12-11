namespace Utilities

[<RequireQualifiedAccess>]
module Config =

    open Utilities

    let sanitizeLines lines =
        lines
        |> Seq.map String.trim
        |> Seq.where (String.isEmpty >> not)    
