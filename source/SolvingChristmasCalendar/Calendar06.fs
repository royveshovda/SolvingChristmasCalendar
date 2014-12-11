module Calendar06

//PROBLEM
//I dagens luke skal vi på en magisk reise i den lille (og den ekstremt store) gangetabellen.
//Den lille gangetabellen ser slik ut:
//1  2  3  4  5  6  7  8  9
//2  4  6  8 10 12 14 16 18
//3  6  9 12 15 18 21 24 27
//4  8 12 16 20 24 28 32 36
//5 10 15 20 25 30 35 40 45
//6 12 18 24 30 36 42 48 54
//7 14 21 28 35 42 49 56 63
//8 16 24 32 40 48 56 64 72
//9 18 27 36 45 54 63 72 81
//Denne 9 x 9 tabellen inneholder 36 unike produkt, og de er som følger: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 24, 25, 27, 28, 30, 32, 35, 36, 40, 42, 45, 48, 49, 54, 56, 63, 64, 72 og 81.
//Hvor mange unike produkt finnes det i en 8000 x 8000 tabell?

//CORRECT: 14509549
//RUNTIME: 4250ms

let allNumbers limit =
    let numbers = new System.Collections.Generic.HashSet<int>()
    for a in 1 .. limit do
        for b in a .. limit do
            numbers.Add(a*b) |> ignore
    numbers.Count


let getSolution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let d1 = allNumbers 8000
    stopWatch.Stop()
    sprintf "%A (%i ms)" d1 stopWatch.ElapsedMilliseconds