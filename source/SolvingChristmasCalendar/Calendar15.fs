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

let correct = "7"
let expectedRuntimeInMs = 30L

let get_candidates =
    let sequence =
        seq { for x in 11 .. 99 do 
                for y in 11 .. 99 do 
                    yield ( x, y, (x*y))
            }
    sequence |> Seq.toArray

let dividable_not_both_by_10 x y =
    let bx = (x % 10 = 0)
    let by = (y % 10 = 0)
    not (bx && by)

let valid_numbers x y n =
    let arr_x = (string x).ToCharArray()
    let arr_y = (string y).ToCharArray()
    let arr_n = (string n).ToCharArray() |> Array.sort
    let arr_xy = (Array.append arr_x arr_y) |> Array.sort
    arr_xy = arr_n

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()

    let numbers =
        get_candidates
        |> Array.filter (fun (_,_,n) -> n >= 1000 && n <= 9999)
        |> Array.filter (fun (x,y,_) -> dividable_not_both_by_10 x y)
        |> Array.filter (fun (x,y,n) -> valid_numbers x y n)
        |> Array.toSeq
        |> Seq.distinctBy (fun (_,_,n) -> n)
        |> Seq.toList
    let value = sprintf "%A" numbers.Length
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }