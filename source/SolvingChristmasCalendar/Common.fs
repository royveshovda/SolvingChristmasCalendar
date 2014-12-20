module Common

type Result = { ExpectedValue:string; ActualValue:string; ExpectedRuntimeInMs:int64; ActualRuntimeInMs:int64 }

let formatResult result =
    let res =
        match result.ActualValue with
        | x when x = result.ExpectedValue -> sprintf "%s" result.ActualValue
        | _ -> sprintf "FAILED: A:%s (E:%s)" result.ActualValue result.ExpectedValue
    sprintf "%-25s %5ims (%5ims)" res result.ActualRuntimeInMs result.ExpectedRuntimeInMs


let get_primes limit =
    let table = Array.create limit true
    let tlimit = int (sqrt (float limit))
    let mutable curfactor = 1;
    while curfactor < tlimit-2 do
        curfactor <- curfactor+2
        if table.[curfactor]  then
            let mutable v = curfactor*2
            while v < limit do
                table.[v] <- false
                v <- v + curfactor
    let out = Array.create (limit) 0
    let mutable idx = 1
    out.[0]<-2
    let mutable curx=1
    while curx < limit-2 do
        curx <- curx + 2
        if table.[curx] then
            out.[idx]<-curx
            idx <- idx+1
    out

let is_palindrome (s: string) =
   let arr = s.ToCharArray()
   arr = Array.rev arr