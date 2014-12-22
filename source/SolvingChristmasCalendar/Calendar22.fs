module Calendar22

//PROBLEM
// I dagens luke skal vi finne tall med en egenskap vi definerer slik: Start med et positivt heltall, erstatt tallet med summen av kvadrattallet (tallet ganget med seg selv) til sifrene som utgjør tallet, repeter til tallet er 1.
//Repeteres denne prosessen nok ganger vil nummeret til slutt bli 1 (hvor det vil bli), eller havne i en uendelig løkke som ikke inkluderer 1. De startnumrene hvor denne prosessen ender i 1 er tallene vi er på jakt etter, mens de hvor det ikke gjør det forkaster vi.
//For eksempel så er 7 et slikt tall, fordi 7²=49,  4²+9²=16+81=97,  9²+7²=81+49=130, 1²+3²+0²=1+9+0=10 og 1²+0²=1+0=1.
//Et eksempel på et tall som ikke er innefor er 17. Her vil man treffe på 89 flere ganger, og dermed havne i en uendelig løkke.
//Hvilke heltall, fra og med 1 og opp til 50 har denne egenskapen? Svaret skal være i form av en kommaseparert liste, i stigende rekkefølge. Eksempelvis 1, 2, 3
//Julegavetips: Per definisjonen er 1 også et slikt tall. 

open Common

let correct = "1,7,10,13,19,23,28,31,32,44,49"
let expectedRuntimeInMs = 7L

let digit_squared_sum n =
    let b = 10
    let rec loop acc = function
        | n when n > 0 ->
            let m, r = System.Math.DivRem(n, b)
            loop (acc + (r*r)) m
        | _ -> acc
    loop 0 n

let check_number n =
    let rec check_number_impl n checked_list =
        let s = digit_squared_sum n
        match s with
        | 1 -> true
        | _ ->
            match (List.exists (fun elem -> elem = s) checked_list) with
            | true -> false
            | false -> check_number_impl s (s::checked_list)
    check_number_impl n [n]

let pretty_print list =
    let s = list |> Array.fold (fun acc x -> acc + (sprintf "%i," x)) ""
    (s.TrimEnd(' ').TrimEnd(','))

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let candidates = [|1 .. 50|]

    let value =
        candidates
        |> Array.filter check_number
        |> pretty_print

    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }