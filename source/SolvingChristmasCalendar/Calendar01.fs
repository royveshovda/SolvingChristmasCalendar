module Calendar01

//PROBLEM
//Et palindrom er et ord eller tall som gir samme resultat enten det leses fra høyre eller venstre, for eksempel 1001.
//Titallsystemet (eller det desimale tallsystemet) er vårt vanlige tallsystem, med grunntall 10. Det finnes også andre varianter med andre grunntall, som åttetallsystemet (eller det oktale tallsystemet) som har grunntallet 8.
//Oppgaven din er å finne ut av hvor mange tall som er palindrom-par i både ti- og åttetallsystemet, fra og med 1 og opp til 1 000 000 (i titallsystemet). Med et palindrom-par mener vi at samme tall er et palindrom i begge tallsystemene.
//Eksempler på to slike palindrom-par er 1 (10) = 1 (8) og 1496941 (10) = 5553555 (8)

open Common

let correct = "25"
let expectedRuntimeInMs = 1000L

let isPalindrome (s: string) =
   let arr = s.ToCharArray()
   arr = Array.rev arr

let check10Palindrome i =
    let s = sprintf "%i" i
    isPalindrome s

let check8Palindrome (i:int) =
    let s = System.Convert.ToString(i,8)
    isPalindrome s

let palindromesBelow i = 
    let n = [1 .. i]
    let numbers = n |> List.filter check10Palindrome |> List.filter check8Palindrome
    numbers

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let numbers = palindromesBelow 1000000
    stopWatch.Stop()

    let value = sprintf "%i" numbers.Length
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }