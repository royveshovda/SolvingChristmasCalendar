module Calendar15

//PROBLEM
//I dagens luke skal vi atter en gang finne tall med en spesiell egenskap.
//Vi skal finne tallene, n, som har følgende egenskaper:
//    n består av 4 siffer.
//    n = x * y.
//    x og y består av 2 siffer.
//    Sifrene i x og y utgjør sifrene i n.
//    Både x og y kan ikke være delelig på 10 (men én eller ingen kan).
//Eksempler på tall som oppfyller dette er 1260 (= 21 * 60) og 1385 (= 15 * 93).
//Eksemplene viser at vi kan stokke vilkårlig om på sifrene i x og y. Kravet er kun at de skal bestå av de samme sifrene som i n.
//Legg også merke til at i det første eksemplet er y, 60, delelig på 10, men kravet vi stiller er at både x og y ikke skal være delelig på 10, noe 21 ikke er.
//Hvor mange tall (antall n) finnes det som oppfyller disse egenskapene?

open Common

let correct = "N/A"
let expectedRuntimeInMs = 0L

let get_candidates =
    let sequence =
        seq { for x in 10 .. 99 do 
                for y in 10 .. 99 do 
                    yield ( x, y, (x*y))
            }
    sequence |> Seq.toArray

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()

    let numbers =
        get_candidates
        |> Array.filter (fun (_,_,n) -> n > 1000 && n < 9999)

    //TODO: Filter out all where both x and y is dividable with 10
    //TODO: Check if numbers in x and y can compose n

    let value = sprintf "%A" numbers.Length

    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }