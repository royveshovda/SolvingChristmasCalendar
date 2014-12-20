module Calendar20

//PROBLEM
//Reinsdyret Rudolf trasker rundt i et rutenett som er uendelig stort i alle retninger. Han kan flytte seg en rute av gangen i retningene opp, ned, venstre eller høyre. Det betyr at fra (x,y) kan han komme til (x+1,y), (x-1,y), (x,y+1) og (x,y-1). Men Rudolf kan bare gå til ruter der tverrsummen av absoluttverdien av x-koordinatet pluss tverrsummen av absoluttverdien av y-koordinatet er mindre eller lik 19.
//For eksempel er det umulig for Rudolf å være i rute (59,79) fordi (5+9)+(7+9) = 30, som er større enn 19. Men han kan være i rute (-5,-7), siden 5+7 = 12, som er mindre enn 19.
//Hvor mange ruter er det mulig for Rudolf å komme til hvis han starter i rute (0,0), inklusive ruten han starter i?
//Tverrsummen er summen av sifrene i tallet.
//Absoluttverdien er den numeriske verdien til tallet uten hensyn til fortegnet.

open Common

let correct = "102485"
let expectedRuntimeInMs = 220000L

let digit_sum (n:int) =
    let s = string n
    s.ToCharArray()
    |> Array.map (fun elem -> System.Int32.Parse(string elem))
    |> Array.sum

let is_legal ((x:int),(y:int)) =
    let x' = System.Math.Abs(x)
    let y' = System.Math.Abs(y)
    let total = (digit_sum x') + (digit_sum y')
    total <= 19

let rec expand (x,y) (findings: (int*int)[]) =
    printfn "%i" findings.Length
    let candidates =
        [|((x + 1), y); ((x - 1), y); (x, (y + 1)); (x, (y - 1))|]
        |> Array.filter is_legal
        |> Array.filter (fun elem -> not (Array.exists (fun e -> e = elem) findings))
    match candidates.Length with
    | 0 -> findings
    | _ ->
        let findings' = Array.append findings candidates
        Array.fold (fun acc elem -> expand elem acc) findings' candidates


let rec expand2 (expandList: (int*int) list) (findings: (int*int)[]) =
    printfn "%i (%i)" findings.Length expandList.Length

    match expandList with
    | [] -> findings
    | (x,y)::tail ->        
        let candidates =
            [|((x + 1), y); ((x - 1), y); (x, (y + 1)); (x, (y - 1))|]
            |> Array.filter is_legal
            |> Array.filter (fun elem -> not (Array.exists (fun e -> e = elem) findings))
        let findings' = Array.append findings candidates
        let expandList' = tail @ (Array.toList candidates)
        expand2 expandList' findings'

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //let v = expand (0,0) [||]
    let v = expand2 [(0,0)] [|(0,0)|]
    let value = sprintf "%A" v.Length
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }