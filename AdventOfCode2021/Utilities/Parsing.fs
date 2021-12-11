namespace Utilities

module Parsing =
    
    open System

    let parseInt = Int32.Parse
    let tryParseInt (str : string) =
        match Int32.TryParse str with
        | true, value -> Some value
        | false, _ -> None
