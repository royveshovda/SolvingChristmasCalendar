module Calendar02

//PROBLEM
//I dagens luke skal vi trikse litt med primtall.
//For et gitt nummer, n, finn tallet m, hvor det første sifferet i m = n og antall siffer i m = n og hver tosifret tallsekvens i m skal være unike primtall. Tallet skal også være lavest mulig.
//Eksempel: Dersom n = 5 blir m = 53113.
//    Første siffer i m er 5.
//    Antall siffer i m er 5.
//    De tosifrete tallsekvensene i m, 53, 31, 11 og 13, er alle unike primtall.
//    Det er det laveste mulige tallet som oppfyller alle disse egenskapene.
//Hva er m dersom n = 9?

open Common

let correct = "971131737"
let expectedRuntimeInMs = 2L

let getPrimes = 
    [|11;13;17;19;23;29;31;37;41;43;47;53;59;61;67;71;73;79;83;89;97|]

let startsWith numberToStartWith number =
    let sNumber = sprintf "%i" number
    let sNumberToStartWith = sprintf "%i" numberToStartWith
    sNumber.StartsWith sNumberToStartWith  

let findLowestStartingWith array numberToStartWith = 
    array |> Array.filter (startsWith numberToStartWith) |> Array.min

let pickNext startWithNumber numbers =
    let n = findLowestStartingWith numbers startWithNumber
    let numbers' = numbers |> Array.filter (fun x -> x <> n)

    let s = sprintf "%i" n
    let s2 = s.Substring(1)
    let i2 = System.Convert.ToInt32(s2)
    (n, i2, numbers')

let get_solution = 
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let i1 = 9
    let a = getPrimes
    let (n2, i2, a2) = pickNext i1 a
    let (_, i3, a3) = pickNext i2 a2
    let (_, i4, a4) = pickNext i3 a3
    let (_, i5, a5) = pickNext i4 a4
    let (_, i6, a6) = pickNext i5 a5
    let (_, i7, a7) = pickNext i6 a6
    let (_, i8, a8) = pickNext i7 a7
    let (_, i9, _) = pickNext i8 a8
    stopWatch.Stop()

    let value = sprintf "%i%i%i%i%i%i%i%i%i" i1 i2 i3 i4 i5 i6 i7 i8 i9
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }