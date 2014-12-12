module Calendar21

//PROBLEM
//Not opened yet

open Common

let correct = "N/A"
let expectedRuntimeInMs = 0L

let getSolution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //TODO: Implement here
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=correct; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }