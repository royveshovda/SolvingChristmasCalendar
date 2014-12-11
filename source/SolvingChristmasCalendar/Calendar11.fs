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
 
let is_prime x =
    let rec check i =
        x > 1L &&
       (double i > sqrt (double x) || (x % i <> 0L && check (i + 1L)))
    check 2L                
 
let sequence_of_first_n_primes n =
    Seq.initInfinite (fun x -> int64 x)
    |> Seq.filter is_prime
    |> Seq.take n

let get_prime_candidate n =
    (sequence_of_first_n_primes n)
    |> Seq.max

let get_next_candidate =
    let start = 542
    Seq.initInfinite (fun index -> get_prime_candidate (start+index))

let getSolution =
    let t = (sequence_of_first_n_primes 15 )|> Seq.toList
    printfn "%A" t
    let c = get_prime_candidate 542
    printfn "%i" c

    let c2 = get_next_candidate |> Seq.take 5
    printfn "%A" c2
    "Not implemented yet"


//Algoritme:
//1: Finn en lang rekke med primtall. F.eks. 2000 (kanskje flere)
//2: Start på laveste (1), og summer 541 sammenhengende. Sjekk om summen er et primtall.
//3: Hvis nei, Start på neste, og forsøk summer 541 igjen. Helt til summen blir er primtall
//4: Hvis ja. Sjekk om det er mulig å finne summen med 41, 17 og 7.
//5: Hvis nei, gå til 3
//6: Hvis ja: Der er svaret