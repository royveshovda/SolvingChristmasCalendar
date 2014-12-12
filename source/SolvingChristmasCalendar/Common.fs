module Common

type Result = { ExpectedValue:string; ActualValue:string; ExpectedRuntimeInMs:int64; ActualRuntimeInMs:int64 }

let formatResult (result:Result) =
    let res =
        match result.ActualValue with
        | x when x = result.ExpectedValue -> sprintf "%s" result.ActualValue
        | _ -> sprintf "FAILED: A:%s (E:%s)" result.ActualValue result.ExpectedValue
    sprintf "%-25s %5ims (%5ims)" res result.ActualRuntimeInMs result.ExpectedRuntimeInMs