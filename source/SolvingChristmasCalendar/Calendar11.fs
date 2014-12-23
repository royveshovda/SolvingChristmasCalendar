module Calendar11

//PROBLEM
//I dagens luke skal vi finne en skikkelig skatt av et primtall. Vi er på jakt etter tallet N, som har følgende egenskaper:
//    Tallet N kan skrives som summen av 7 sammenhengende primtall.
//    Tallet N kan skrives som summen av 17 sammenhengende primtall.
//    Tallet N kan skrives som summen av 41 sammenhengende primtall.
//    Tallet N kan skrives som summen av 541 sammenhengende primtall.
//    Tallet N skal være et primtall.
//    Tallet N er det laveste positive heltallet som oppfyller disse egenskapene.
//Som et eksempel på hvordan en slik kjede fungerer kan vi ta 41. 41 er nemlig det minste primtallet som kan skrives som summen av 3 (11 + 13 + 17 = 41) og 6 (2 + 3 + 5 + 7 + 11 + 13 = 41) sammenhengende primtall.
//Dette eksemplet bruker 3 og 6 sammenhengende primtall. Oppgaven stiller andre krav til tallet N. Eksemplet med 41 er derfor kun for å illustrere hva vi mener med sammenhengende primtall og hvordan en slik kjede er ment å fungere.
//Hva er N?

open Common

let correct = "7830239"
let expectedRuntimeInMs = 350L

let get_candidates_of_length_below_limit length list limit minValue =
    let rec get_candidates_of_length_acc len (lst: int[]) position (acc: int list) limit =
        let e = (position + len)
        match e with
        | x when x > lst.Length -> 
            acc |> Set.ofList
        | _ -> 
            let sum =  (Array.sub lst position len) |> Array.sum
            match sum with
            | s when s > limit ->
                acc |> Set.ofList
            | _ ->
                let newAcc = if sum > minValue then sum::acc else acc
                get_candidates_of_length_acc len lst (position + 1) newAcc limit
    get_candidates_of_length_acc length list 0 [] limit

let intersection set1 set2 set3 set4 = 
  Set.intersect set1 set2 |> Set.intersect set3 |> Set.intersect set4

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let limit = 10000000
    let primes = get_primes limit
    let s541 = get_candidates_of_length_below_limit 541 primes limit 10000
    let min541 = Set.minElement s541
    let s41 = get_candidates_of_length_below_limit 41 primes limit min541
    let s17 = get_candidates_of_length_below_limit 17 primes limit min541
    let s7 = get_candidates_of_length_below_limit 7 primes limit min541
    let value = (intersection s541 s41 s17 s7) |> Set.toList |> List.min
    stopWatch.Stop()
    
    let valueS = sprintf "%i" value
    {
        ExpectedValue=correct;
        ActualValue=valueS;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }