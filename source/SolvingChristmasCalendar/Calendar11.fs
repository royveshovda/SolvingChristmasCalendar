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

//CORRECT: 7830239

open System

let is_sum (l: int[]) (n: int) =
    (Array.sum l) = n

let get_candidates_of_length length (list: int[]) =
    let rec get_candidates_of_length_acc len (lst: int[]) position acc =
        let e = (position + len)
        match e with
        | x when x > lst.Length -> acc
        | _ -> 
            let add = lst |> Array.toSeq |> Seq.skip position |> Seq.take len |> Seq.toArray
            let newAcc = acc @ [add]
            get_candidates_of_length_acc len lst (position + 1) newAcc
    get_candidates_of_length_acc length list 0 []

let get_candidates_of_length_below_limit length (list: int[]) limit =
    let rec get_candidates_of_length_acc len (lst: int[]) position acc limit =
        let e = (position + len)
        match e with
        | x when x > lst.Length -> acc
        | _ -> 
            let add = lst |> Array.toSeq |> Seq.skip position |> Seq.take len |> Seq.toArray
            let sum = add |> Array.sum
            match sum with
            | s when s > limit -> acc
            | _ ->
                let newAcc = acc @ [add]
                get_candidates_of_length_acc len lst (position + 1) newAcc limit
    get_candidates_of_length_acc length list 0 []

let is_prime x =
    let rec check i =
        x > 1 &&
        (double i > sqrt (double x) || (x % i <> 0 && check (i + 1)))
    check 2                

let array_of_primes_below limit =
    Seq.initInfinite (fun x -> x)
    |> Seq.filter is_prime
    |> Seq.takeWhile (fun elem -> elem < limit)
    |> Seq.toArray

let getSolution =
    let limit = 1000000
    let primes = array_of_primes_below limit

    let c541 = get_candidates_of_length_below_limit 541 primes limit
    printfn "%A" c541
    //printfn "%i" p.[limit-1]
    //printfn "Generated %i primes" limit
    //let b = checkAll p 0
    //printfn "%A" b
    "Not implemented yet"


//Algoritme:
//1: Finn en lang rekke med primtall. F.eks. 2000 (kanskje flere)
//2: Start på laveste (1), og summer 541 sammenhengende. Sjekk om summen er et primtall.
//3: Hvis nei, Start på neste, og forsøk summer 541 igjen. Helt til summen blir er primtall
//4: Hvis ja. Sjekk om det er mulig å finne summen med 41, 17 og 7.
//5: Hvis nei, gå til 3
//6: Hvis ja: Der er svaret