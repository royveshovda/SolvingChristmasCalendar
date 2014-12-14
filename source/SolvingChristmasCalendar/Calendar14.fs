module Calendar14

//PROBLEM
//I dagens luke skal vi forsøke å finne tall som kan leses likt når de blir rotert 180° (med andre ord; opp ned).
//Sifrene vi kan tolke opp ned er 0, 1, 6, 8 og 9 og noen eksempler på tall som blir like opp ned er: 1, 916 og 8008.
//Din oppgave er å telle antall heltall, fra og med 0 og opp til 100 000, som kan leses likt opp ned.

open Common

let valid_nummber (n:string) =
    match n with
    | 0 -> true
    | 1 -> true
    | 6 -> true
    | 8 -> true
    | 9 -> true
    | _ -> false

let only_valid_characters (n:int) =
    let s = sprintf "%i" n
    let arr = s.ToCharArray()
    Array.fold (fun state item -> state && (valid_nummber item)) true arr

let correct = "N/A"
let expectedRuntimeInMs = 0L

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //TODO: Implement here
    let v = only_valid_characters 123
    let value = sprintf "%A" v
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }