module Calendar20

//PROBLEM
//Reinsdyret Rudolf trasker rundt i et rutenett som er uendelig stort i alle retninger. Han kan flytte seg en rute av gangen i retningene opp, ned, venstre eller høyre. Det betyr at fra (x,y) kan han komme til (x+1,y), (x-1,y), (x,y+1) og (x,y-1). Men Rudolf kan bare gå til ruter der tverrsummen av absoluttverdien av x-koordinatet pluss tverrsummen av absoluttverdien av y-koordinatet er mindre eller lik 19.
//For eksempel er det umulig for Rudolf å være i rute (59,79) fordi (5+9)+(7+9) = 30, som er større enn 19. Men han kan være i rute (-5,-7), siden 5+7 = 12, som er mindre enn 19.
//Hvor mange ruter er det mulig for Rudolf å komme til hvis han starter i rute (0,0), inklusive ruten han starter i?
//Tverrsummen er summen av sifrene i tallet.
//Absoluttverdien er den numeriske verdien til tallet uten hensyn til fortegnet.

open Common

let correct = "N/A"
let expectedRuntimeInMs = 0L

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



//At a position:
//1: find candidates
//2: Check if they are legal
//3: For all legal: Add to findings
//4: For all legal: Expand using new list
//5: Keep adding to findings


let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let v = expand (0,0) [||]
    let value = sprintf "%A" v.Length
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }