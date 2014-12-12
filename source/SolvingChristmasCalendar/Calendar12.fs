module Calendar12

//PROBLEM
// Aaahh, fredag.
//Fredag den 13. er når den 13. dagen i en måned faller på en fredag.
//I vesteuropeiske og særlig engelskspråklige land blir dagen knyttet til uhell  ulykker.
//Heldigvis er det bare fredag den 12. i dag, men hvor mange fredag den 13. har det vært siden den 1. januar 1337 og fram til i dag? 

open Common

let correct = "1166"
let expectedRuntimeInMs = 15L

let rec nextFriday (date: System.DateTime) =
    match date.DayOfWeek with
    | System.DayOfWeek.Friday -> date
    | _ -> nextFriday (date.AddDays(1.0))

let rec countFriday13 date stop =
    let rec countFriday13impl (date: System.DateTime) stop count = 
        match date with
        | d when d > stop -> count
        | _ -> 
            let next = date.AddDays 7.0
            let nextCount =
                match date.Day with
                | 13 -> count + 1
                |_  -> count
            countFriday13impl next stop nextCount
    countFriday13impl date stop 0

let getSolution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let first = new System.DateTime(1337, 1, 1)
    let start = nextFriday first
    let stop = new System.DateTime(2014, 12, 12)

    let numberOfFriday13 = countFriday13 start stop
    let value = sprintf "%i" numberOfFriday13
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }