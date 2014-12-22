module Calendar16

//PROBLEM
// En toerpotens er et tall som kan skrives som 2^n der n er et heltall.
//Søk gjennom alle toerpotenser mindre enn 2^10000 og returner første n der en gitt substring forekommer.
//For eksempel, hvis stringen er “02”, så er svaret 10, fordi  2^10 = 1024 og ingen lavere toerpotenser inneholder “02”.
//Hva er n for den minste toerpotensen som inneholder “472047”? 

open Common

let correct = "1765"
let expectedRuntimeInMs = 50L

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let number = [1..10000]|>List.find(fun n -> string(bigint 2**n).Contains "472047")
    let value = sprintf "%A" number
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }