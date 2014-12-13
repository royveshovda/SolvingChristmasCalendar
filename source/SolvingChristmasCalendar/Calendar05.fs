module Calendar05

//PROBLEM
//I tallteori er primfaktorene til et positivt heltall de primtallene som tallet kan deles på uten rest. For eksempel, for tallet 18 er primfaktorene 2 og 3 og den største primfaktoren for 18 er dermed 3.
//Definer STORETALL til å være alle tall som inneholder hvert av sifrene 1-9 nøyaktig én gang. (Alle tallene må inneholde hvert av sifrene fra 1-9). Eksempler på slike tall kan være 483761925 og 879456123.
//Den største primfaktoren til 483761925 er 4111, mens den største primfaktoren til 879456123 er 491.
//Finn den største primfaktoren til hvert av tallene i STORETALL. Hva er den minste av disse (største) primfaktorene?
//For eksemplet over (med kun 483761925 og 879456123) ville svaret vært 491, da 491 og 4111 er de største primfaktorene, men 491 er den minste av disse.
//Julegavetips: Gitt definisjonen av STORETALL ender vi da opp med (9! =) 362880 forskjellige tall.

open Common

let correct = "7"
let expectedRuntimeInMs = 4000L

let rec insert left x right = seq {
    match right with
    | [] -> yield left @ [x]
    | head :: tail -> 
        yield left @ [x] @ right
        yield! insert (left @ [head]) x tail
    }
 
let rec perms permute =
    seq {
        match permute with
        | [] -> yield []
        | head :: tail -> yield! Seq.collect (insert [] head) (perms tail)
    }

let decompose_prime n = 
  let rec loop c p =
    if c < (p * p) then [c]
    elif c % p = 0 then p :: (loop (c/p) p)
    else loop c (p + 1) 
  loop n 2

let rec composeNumber lst =
    let temp = List.fold (fun acc x -> acc+(string x)) "" lst
    System.Convert.ToInt32 temp

let findMaxPrimeFactor (n:int) =
    let primes = decompose_prime n
    primes |> List.max

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let solution =
        (perms [1;2;3;4;5;6;7;8;9])
        |> Seq.toList
        |> List.map composeNumber
        |> List.map findMaxPrimeFactor
        |> List.min
    stopWatch.Stop()
    let value = sprintf "%A" solution
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }