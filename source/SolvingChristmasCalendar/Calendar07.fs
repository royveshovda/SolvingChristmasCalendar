module Calendar07

//PROBLEM
//Når man skal forsøke å finne julegaver til sine kjære i julestria kan man av og til bli seendes slik ut: Santa.png
//Hvor mange piksler er det av den 10. (teller fra 1) mest brukte fargen (i RGB-verdi) i dette bildet?

open Common
open FSharp.Collections.ParallelSeq

let correct = "22272"
let expectedRuntimeInMs = 1600L

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let filename = "..\\..\\..\\Data\\Santa.png"
    //let filename = "/Users/royveshovda/src/SolvingChristmasCalendar/source/Data/Santa.png"
    let bitmap = new System.Drawing.Bitmap(filename)

    let list = new System.Collections.Generic.List<int>()
    list.Capacity <- (bitmap.Height * bitmap.Width)

    for i=0 to bitmap.Height-1 do
        for j=0 to bitmap.Width-1 do
            let color = bitmap.GetPixel(j,i)
            let argb = color.ToArgb()
            list.Add(argb)
        done
    done

    let values = list.ToArray()
    let v2 =
        values
        |> PSeq.countBy id
        |> PSeq.toArray
        |> PSeq.sortBy (fun (p, n) -> (n * -1))
        |> PSeq.nth 9

    let (_, number) = v2
    stopWatch.Stop()
    let value = sprintf "%i" number
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }