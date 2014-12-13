module Calendar23

//PROBLEM
//Not opened yet

open Common

let correct = "N/A"
let expectedRuntimeInMs = 0L

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //TODO: Implement here
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=correct; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }