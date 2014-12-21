module Calendar21

//PROBLEM
//words.txt er en text/plain fil med et ord på hver linje. (Obs: Last ned fila og les den lokalt. Å lese programmatisk rett fra Dropbox kan i noen tilfeller medføre problemer.)
//ascii_sum = summen av asciiverdiene for hvert tegn i et ord;ascii_sum(“foo”) = (f=102 + o=111 + o=111) = 324
//Finn summen av ascii_sum for de 42 ordene som har høyest ascii_sum. Klarer du å gjøre det i O(n) i for n = antall ord?

open Common

let correct = "103003"
let expectedRuntimeInMs = 110L

let filename = "..\\..\\..\\Data\\words.txt"
//let filename = "/Users/royveshovda/src/SolvingChristmasCalendar/source/Data/words.txt"

let read_lines filename =
    System.IO.File.ReadLines(filename)

let calculate_ascii_sum (word: string) =
    System.Text.ASCIIEncoding.ASCII.GetBytes(word)
    |> Array.map (fun elem -> (int elem))
    |> Array.sum

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let ascii_sum =
        read_lines filename
        |> Seq.map calculate_ascii_sum
        |> Seq.sortBy (fun elem -> elem * (-1))
        |> Seq.take 42
        |> Seq.sum
    let value = sprintf "%i" ascii_sum

    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }