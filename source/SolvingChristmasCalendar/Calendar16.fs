module Calendar16

//PROBLEM
// En toerpotens er et tall som kan skrives som 2^n der n er et heltall.
//Søk gjennom alle toerpotenser mindre enn 2^10000 og returner første n der en gitt substring forekommer.
//For eksempel, hvis stringen er “02”, så er svaret 10, fordi  2^10 = 1024 og ingen lavere toerpotenser inneholder “02”.
//Hva er n for den minste toerpotensen som inneholder “472047”? 

//http://stackoverflow.com/questions/383587/how-do-you-do-integer-exponentiation-in-c

//MIN: 687 (SQRT (472047))
//MAX: Try 2000

open Common

let correct = "1765"
let expectedRuntimeInMs = 40L

let generate_candidates min max =
    let numbers = [| min .. max |]
    numbers |> Array.map (fun elem -> (elem, (System.Numerics.BigInteger.Pow(2I, elem))))

let is_correct (n: bigint) =
    n.ToString().Contains("472047")

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()

    let numbers = generate_candidates 687 2000
    let n2 =
        numbers
        |> Array.filter (fun (_, big) -> is_correct big)
    let (n,_) = n2.[0]
    
    let value = sprintf "%A" n

    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }