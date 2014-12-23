module Calendar23

//PROBLEM
// Vi er på jakt etter en spesiell type tall som har den følgende egenskapen: Tallet, n, kan deles i to deler, som ved summering og opphøying i andre, er lik det originale tallet n. For eksempel så er 88209 et slikt tall, fordi (88 + 209)² = 297² = 88209.
//Hvor mange slike positive heltall under 1000000 (en million) finnes det? 
//Julegavetips: Merk at 100 er også et slik tall, da (10 + 0)² = 10² = 100. 

open Common

let correct = "9"
let expectedRuntimeInMs = 3300L

let get_parts n =
    let get_digits n =
        let b = 10
        let rec loop acc = function
            | n when n > 0 ->
                let m, r = System.Math.DivRem(n, b)
                loop (r::acc) m
            | _ -> List.toArray acc
        loop [] n

    let assemble (digits: int[]) =
        let limiter = digits.Length - 1
        digits |> Array.mapi (fun i x -> x * (pown 10 (limiter - i))) |> Array.sum
    
    let digits = get_digits n
    let length = digits.Length
    [|
        for i in 1 .. (length - 1) do
            let part1 = Array.sub digits 0 i
            let part2 = Array.sub digits i (length - i)
            yield (assemble part1, assemble part2)
    |]

let check_number n =
    let parts =
        get_parts n
        |> Array.filter (fun (p1, p2) -> n = ((p1+p2) * (p1+p2)))
    match parts with
    | [||] -> false
    | _ -> true

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let values =
        [|10 .. 999999|]
        |> Array.filter check_number
    let value = sprintf "%A" values.Length

    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }