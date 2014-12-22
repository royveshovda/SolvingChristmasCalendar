module Calendar17

//PROBLEM
//En klassisk keypad ser som oftest slik ut:
//1  2  3
//4  5  6
//7  8  9
//    0
//En springer (også kalt hest) i sjakk flytter i en L-formet bevegelse: Ett felt horisontalt eller vertikalt og deretter to felt vinkelrett på den første delen av trekket. Eksempel: Fra tallet 1 på keypaden kan springeren flytte til enten 6 eller 8, og fra tallet 4 kan springeren flytte til enten 3, 9 eller 0.
//Dersom man starter på tallet 1, og velger påfølgende tall slik som springeren flytter i sjakk, hvor mange unike stier av 10 tall finnes det? En sti kan besøke samme tall mer enn en gang.
//Et eksempel på en sti kan være: 1 6 1 6 1 6 1 6 1 8

open Common

let correct = "1424"
let expectedRuntimeInMs = 10L

let get_next_moves pos =
    match pos with
    | 0 -> [4;6]
    | 1 -> [6;8]
    | 2 -> [7;9]
    | 3 -> [4;8]
    | 4 -> [0;3;9]
    | 6 -> [0;1;7]
    | 7 -> [2;6]
    | 8 -> [1;3]
    | 9 -> [2;4]
    | _ -> []

let rec get_number_of_possibilities pos levels =
    match levels with
    | 0 -> 1
    | x ->
        let moves = get_next_moves pos
        moves
        |> List.map (fun elem -> get_number_of_possibilities elem (levels - 1))
        |> List.sum

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let m = get_number_of_possibilities 1 9
    let value = sprintf "%A" m
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }