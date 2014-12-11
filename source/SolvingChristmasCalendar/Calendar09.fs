module Calendar09

//PROBLEM
//Definer REGNESTYKKER til å være alle regnestykker hvor et tresifret tall blir summert med et annet tresifret tall, og resultatet er et firesifret tall. Alle tallene er positive heltall. Alle de 10 sifrene som utgjør et regnestykke skal inneholde hvert av sifrene 0-9 kun én gang.
//Eksempler på slike regnestykker som oppfyller disse egenskapene er 324 + 765 = 1089 og 759 + 843 = 1602.
//Hva er den minste verdien for et av leddene i REGNESTYKKER?
//For eksemplene over (med kun de to regnestykkene) ville svaret vært 324, da det er det minste leddet.  

//CORRECT: 246
//RUNTIME: 52ms

let checkLength (n:int) (length:int) =
    let s = string n
    s.Length = length

let checkForAllDigits (s:string) =
    let b0 = s.Contains("0")
    let b1 = s.Contains("1")
    let b2 = s.Contains("2")
    let b3 = s.Contains("3")
    let b4 = s.Contains("4")
    let b5 = s.Contains("5")
    let b6 = s.Contains("6")
    let b7 = s.Contains("7")
    let b8 = s.Contains("8")
    let b9 = s.Contains("9")
    b0 && b1 && b2 && b3 && b4 && b5 && b6 && b7 && b8 && b9

let checkSolution (a:int) (b:int) =
    let sum = a + b
    let b1 = checkLength a 3
    let b2 = checkLength b 3
    let b3 = checkLength sum 4
    let s = (string a) + (string b) + (string sum)
    let b4 = checkForAllDigits s
    b1 && b2 && b3 && b4

let combineAll n xs = 
    xs |> List.map (fun x -> (n, x))

let allCombinations xs ys =
    xs |> List.fold (fun acc x -> (combineAll x ys) @ acc) []

let getSolution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let n1 = [123 .. 324]
    let n2 = [765 .. 987]
    let c = allCombinations n1 n2
    let valid = c |> List.filter (fun (a,b) -> checkSolution a b)
    let first = valid |> List.sortBy (fun (a,_) -> a)
    stopWatch.Stop()
    match first with
    | [] -> "Not found"
    | (a,_)::_ -> sprintf "%i (%i ms)" a stopWatch.ElapsedMilliseconds
    