module Calendar24

//PROBLEM
//I kalenderens siste luke skal vi finne tallet N før vi metter oss på Disney, ribbe, pinnekjøtt, lutefisk og julegaver. N har følgende egenskaper:
//    Det siste sifferet i tallet er 6.
//    Hvis det siste 6-sifferet flyttes fra helt sist til helt først i tallet så er det nye tallet 4 ganger så stort som det originale tallet.
//    Det er minst mulig.
//    Det er et positivt heltall.
//Hva er N?
//Et eksempel på hvordan flyttingen fungerer er 146 -> 614. Merk at dette ikke gjør tallet 4 ganger større, dette er kun ment for å vise hva vi mener med flytting. Svaret ditt skal være tallet før flyttingen (altså 146, ikke 614).

open Common

let correct = "153846"
let expectedRuntimeInMs = 10L

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()

    let n =
        { 16 .. 10 .. 1000000 }
        |> Seq.filter (fun n -> (n/10%10)=4)
        |> Seq.find (fun n -> int (sprintf "6%i" (n/10)) = (4*n))
    let value = sprintf "%i" n

    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }