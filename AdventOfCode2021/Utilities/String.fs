namespace Utilities

module String =
    
    let trim (str : string) = str.Trim ()

    let isEmpty (str : string) = System.String.IsNullOrEmpty str
