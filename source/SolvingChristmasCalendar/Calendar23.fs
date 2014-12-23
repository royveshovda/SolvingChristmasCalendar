module Calendar23

//PROBLEM
// Vi er på jakt etter en spesiell type tall som har den følgende egenskapen: Tallet, n, kan deles i to deler, som ved summering og opphøying i andre, er lik det originale tallet n. For eksempel så er 88209 et slikt tall, fordi (88 + 209)² = 297² = 88209.
//Hvor mange slike positive heltall under 1000000 (en million) finnes det? 
//Julegavetips: Merk at 100 er også et slik tall, da (10 + 0)² = 10² = 100. 

open Common

let correct = "9"
let expectedRuntimeInMs = 3500L

//TODO: improve speed
let get_parts (n: int) =
    let text = string n
    let stop = text.Length - 1
    [|
        for i in 1 .. stop do
            let part1 = int (text.Substring(0,i))
            let part2 = int (text.Substring(i))            
            yield (part1, part2)
    |]

let check_number n =
    let parts = 
        get_parts n
        |> Array.filter (fun (p1, p2) -> n = ((p1+p2) * (p1+p2)))
    match parts.Length with
    | 0 -> false
    | _ -> true

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let values =
        [|1 .. 999999|]
        |> Array.filter check_number
    let value = sprintf "%A" values.Length
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }