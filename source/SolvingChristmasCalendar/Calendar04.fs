module Calendar04

//PROBLEM
//Desember kan ofte være litt kjølig. Filen Data/kilma_data_blindern.txt viser klimadata målt på Blindern hver dag siden 1. januar 1950 og frem til 1. januar 2014.
//I denne julenøtten ønsker vi å finne hvilken dato den laveste temperaturen i en desember måned ble målt på Blindern. Om den laveste temperaturen ble målt på flere datoer er det den tidligste vi er ute etter.
//Svaret skal oppgis på følgende form dd.mm.åååå. Eksempelvis: 24.12.2014
//Julegavetips: Det er i kolonnen med overskriften TAN dere finner den laveste målte temperaturen for et døgn.

//CORRECT: 14.12.1981
//RUNTIME: ??

open System
open System.IO

let parseLine (line:string) =
    let splits = line.Split(' ') |> Seq.filter (fun elem -> elem.Length > 0) |> Seq.toArray
    let date = DateTime.Parse splits.[1]
    let value = splits.[3]
    let fValue = Double.Parse value
    (date,fValue)

//TODO: Improve parsing of file and sections
let readFile (filename:string)=
    use fs = File.OpenText(filename)
    let text = fs.ReadToEnd()
    let (date, temp) =
        text.Split ('\n')
        |> Seq.skip 24
        |> Seq.take 23377
        |> Seq.map parseLine
        |> Seq.filter (fun (date:DateTime, value) -> date.Month = 12)
        |> Seq.sortBy (fun (_,temp) -> temp)
        |> Seq.head

    (date, temp)

let getSolution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let filename = "..\\..\\..\\Data\\kilma_data_blindern.txt"
    let (date, temp) = readFile filename
    stopWatch.Stop()
    sprintf "%s (%.1f) (%i ms)" (date.ToShortDateString()) temp stopWatch.ElapsedMilliseconds