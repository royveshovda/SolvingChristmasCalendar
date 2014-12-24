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
let expectedRuntimeInMs = 20L

let shift_number (n: int) : int =
    let get_digits n =
        let rec loop acc = function
            | n when n > 0 ->
                let m, r = System.Math.DivRem(n, 10)
                loop (r::acc) m
            | _ -> List.toArray acc
        loop [] n

    let assemble (digits: int[]) =
        let limiter = digits.Length - 1
        digits |> Array.mapi (fun i x -> x * (pown 10 (limiter - i))) |> Array.sum

    let digits = get_digits n
    let l = digits.Length
    let part2 = digits.[(l-1)..]
    let part1 = digits.[.. (l-2)]
    assemble (Array.append part2 part1)

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()

    let n =
        { 16 .. 10 .. 1000000 }
        |> Seq.find (fun n -> (shift_number n) = (4 * n))
    let value = sprintf "%i" n

    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }