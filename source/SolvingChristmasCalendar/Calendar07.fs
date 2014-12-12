module Calendar07

//PROBLEM
//Når man skal forsøke å finne julegaver til sine kjære i julestria kan man av og til bli seendes slik ut: 
//http://upload.wikimedia.org/wikipedia/en/archive/f/f4/20100830193250!The_Scream.jpg
//Hvor mange piksler er det av den 10. (teller fra 1) mest brukte fargen (i RGB-verdi) i dette bildet?

open Common

let correct = "22272"
let expectedRuntimeInMs = 2542L

let getSolution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let filename = "..\\..\\..\\Data\\Santa.png"
    //let filename = "/Users/royveshovda/src/SolvingChristmasCalendar/source/Data/Santa.png"
    // get the image
    let bitmap = new System.Drawing.Bitmap(filename)

    let list = new System.Collections.Generic.List<int>()
    list.Capacity <- (bitmap.Height * bitmap.Width)

    for i=0 to bitmap.Height-1 do
        for j=0 to bitmap.Width-1 do
            // Get the color of the [x,y] pixel
            let color = bitmap.GetPixel(j,i)
            let argb = color.ToArgb()
            list.Add(argb)
        done
    done

    let values = list.ToArray()
    let v2 = values |> Seq.countBy id |> Seq.toArray |> Array.sortBy (fun (p, n) -> (n * -1))

    let (_, number) = v2.[9]
    stopWatch.Stop()
    let value = sprintf "%i" number
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }