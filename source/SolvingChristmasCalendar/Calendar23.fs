module Calendar23

//PROBLEM
// Vi er på jakt etter en spesiell type tall som har den følgende egenskapen: Tallet, n, kan deles i to deler, som ved summering og opphøying i andre, er lik det originale tallet n. For eksempel så er 88209 et slikt tall, fordi (88 + 209)² = 297² = 88209.
//Hvor mange slike positive heltall under 1000000 (en million) finnes det? 
//Julegavetips: Merk at 100 er også et slik tall, da (10 + 0)² = 10² = 100. 

//#r "FSharp.Collections.ParallelSeq.dll"

open Common
open FSharp.Collections.ParallelSeq

let correct = "9"
let expectedRuntimeInMs = 220L

let check_number n=
    let rec check_number_impl div =
        match n/div, n%div with
        | 0,_ -> false
        | x,y -> (x+y)*(x+y) = n || check_number_impl (div*10)
    check_number_impl 10

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let values =
        {10 .. 999999}
        |> PSeq.filter check_number
    let value = sprintf "%A" (PSeq.length values)

    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }