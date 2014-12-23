module Calendar23

//PROBLEM
//

open Common

let correct = "N/A"
let expectedRuntimeInMs = 0L

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()



    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=correct; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }