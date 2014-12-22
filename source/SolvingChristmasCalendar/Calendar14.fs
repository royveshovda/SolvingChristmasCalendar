module Calendar14

//PROBLEM
//I dagens luke skal vi forsøke å finne tall som kan leses likt når de blir rotert 180° (med andre ord; opp ned).
//Sifrene vi kan tolke opp ned er 0, 1, 6, 8 og 9 og noen eksempler på tall som blir like opp ned er: 1, 916 og 8008.
//Din oppgave er å telle antall heltall, fra og med 0 og opp til 100 000, som kan leses likt opp ned.

open Common

let correct = "99"
let expectedRuntimeInMs = 70L

let valid_character c =
    match c with
    | '0' -> true
    | '1' -> true
    | '6' -> true
    | '8' -> true
    | '9' -> true
    | _ -> false

let only_valid_characters n =
    let s = sprintf "%i" n
    let arr = s.ToCharArray()
    arr |> Array.fold (fun state item -> state && (valid_character item)) true

let flip_char c =
    match c with
    | '0' -> '0'
    | '1' -> '1'
    | '6' -> '9'
    | '8' -> '8'
    | '9' -> '6'
    | _ -> 'X'

let is_flippable n =
    let s = sprintf "%i" n
    let arr = s.ToCharArray()
    let flipped = arr |> Array.rev |> Array.map flip_char
    flipped = arr

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let all = [|0 .. 100000|]
    let valid =
        all
        |> Array.filter only_valid_characters //This speeds up the process by 40%
        |> Array.filter is_flippable

    let value = sprintf "%A" valid.Length
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }