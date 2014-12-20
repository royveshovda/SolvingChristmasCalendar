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
    |> Array.map (fun elem -> (int elem))
    |> Array.sum

//let is_legal (x,y) =
//    let y' = System.Math.Abs(y)

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let v = digit_sum 123
    let value = sprintf "%A" v
    //TODO: Implement here
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }