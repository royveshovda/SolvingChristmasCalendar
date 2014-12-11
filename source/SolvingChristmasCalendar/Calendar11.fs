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

open System

let is_sum (l: int64 list) (n: int64) =
    (List.sum l) = n

let get_candidates_of_length length (list: int64 list) =
    let rec get_candidates_of_length_acc len (lst: int64 list) position acc =
        let e = (position + len)
        match e with
        | x when x > lst.Length -> acc
        | _ -> 
            let add = lst |> List.toSeq |> Seq.skip position |> Seq.take len |> Seq.toList
            let newAcc = acc @ [add]
            get_candidates_of_length_acc len lst (position + 1) newAcc
    get_candidates_of_length_acc length list 0 []

let is_prime x =
    let rec check i =
        x > 1L &&
        (double i > sqrt (double x) || (x % i <> 0L && check (i + 1L)))
    check 2L                
 
let sequence_of_first_n_primes n =
    Seq.initInfinite (fun x -> int64 x)
    |> Seq.filter is_prime
    |> Seq.take n

let sequence_of_primes_below n =
    Seq.initInfinite (fun x -> int64 x)
    |> Seq.filter is_prime
    |> Seq.takeWhile (fun elem -> elem < n)

let get_prime_candidate n =
    (sequence_of_first_n_primes n)
    |> Seq.max

let get_next_candidate start =
    Seq.initInfinite (fun index -> get_prime_candidate (start+index))

let has_subsetsum_of_primes_of_length length prime =
    let primes = 
        (sequence_of_primes_below 41L)
        |> Seq.toList

    let candidates = get_candidates_of_length length primes
    let result =
        candidates
        |> List.filter (fun x -> is_sum x prime)
    result.Length >= 1

let is_valid n =
    //TODO: Possible to speed up here
    //let b1 = has_subsetsum_of_primes_of_length 7 n
    //let b2 = has_subsetsum_of_primes_of_length 17 n
    //let b3 = has_subsetsum_of_primes_of_length 41 n
    let b1 = true
    let b2 = true
    let b3 = true
    let b4 = has_subsetsum_of_primes_of_length 541 n
    printfn "%A" n
    b1 && b2 && b3 && b4

let getSolution =
    let b =
        get_next_candidate 542
        |> Seq.skipWhile (fun elem -> (is_valid elem) = false)
        |> Seq.take 1
    printfn "%A" b

    "Not implemented yet"


//Algoritme:
//1: Finn en lang rekke med primtall. F.eks. 2000 (kanskje flere)
//2: Start på laveste (1), og summer 541 sammenhengende. Sjekk om summen er et primtall.
//3: Hvis nei, Start på neste, og forsøk summer 541 igjen. Helt til summen blir er primtall
//4: Hvis ja. Sjekk om det er mulig å finne summen med 41, 17 og 7.
//5: Hvis nei, gå til 3
//6: Hvis ja: Der er svaret