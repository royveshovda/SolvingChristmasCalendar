module Calendar08

//PROBLEM
//I dagens luke er vi på jakt etter tall med den egenskapen at summen av tallets ordentlige divisorer er lik tallet selv.
//Med ordentlig divisor menes det alle positive divisorer for tallet, ekskludert tallet selv. For eksempel er 6 sine ordentlige divisorer 1, 2 og 3, men altså ikke 6 (selv om det er en divisor for 6).
//Et eksempel på et tall med denne egenskapen er 6, da 1 + 2 + 3 = 6.
//Hvilke positive tall under 10 000 tilfredsstiller denne egenskapen? Svaret skal være i form av en kommaseparert liste, i stigende rekkefølge. Eksempelvis: 1, 2, 3
//TIPS: Også kalt "Perfect number"

open Common

let correct = "6,28,496,8128"
let expectedRuntimeInMs = 4500L

let perf n =
    n = List.fold (+) 0 (List.filter (fun i -> n % i = 0) [1..(n-1)])

let getAllPerfectNumberUnder n =
    let l = [1 .. n]
    l |> List.filter perf

let prettyPrint list =
    let s = list |> List.fold (fun acc x -> acc + (sprintf "%i," x)) ""
    (s.TrimEnd(' ').TrimEnd(','))

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let numbers = getAllPerfectNumberUnder 10000
    stopWatch.Stop()
    let value = prettyPrint numbers    
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }