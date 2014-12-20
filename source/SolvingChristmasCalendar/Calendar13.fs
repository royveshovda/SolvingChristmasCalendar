module Calendar13

//PROBLEM
// Vi definerer MIRPTALL som primtall som fortsatt er primtall når sifrene reverseres, uten at de er palindromer. (Et palindrom er et ord eller tall som gir samme resultat enten det leses fra høyre eller venstre).
//For eksempel er 13 et primtall, fordi reversen, 31, også er et primtall. Dette blir da et MIRPTALL.
//Eksempler på tall som ikke er MIRPTALL er for eksempel 23. Dette er et primtall, men reverserer vi det får vi 32, som ikke er et primtall. 5 og 101 er heller ikke MIRPTALL, da disse er palindromer.
//Hvor mange positive heltall under 1000 er MIRPTALL?
//Julegavetips: Selv om 13 og 31 reverseres til hverandre er de fortsatt MIRPTALL “hver for seg” (på grunn av definisjonen). Begge må derfor telles med som en del av resultatet. 

open Common

let correct = "36"
let expectedRuntimeInMs = 6L

let is_not_palindrome i =
    let s = sprintf "%i" i
    let arr = s.ToCharArray()
    arr <> Array.rev arr

let get_reverse i =
    let s = sprintf "%i" i
    let arr = s.ToCharArray()
    int (new System.String((Array.rev arr)))

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()

    let limit = 1000

    let primes_without_palindromes =
        get_primes limit
        |> Array.filter (fun elem -> is_not_palindrome elem)

    let reverse_values =
        primes_without_palindromes
        |> Array.map get_reverse

    let s1 = Set.ofArray primes_without_palindromes
    let s2 = Set.ofArray reverse_values
    let s = Set.intersect s1 s2
    let value = sprintf "%i" s.Count
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }