open Common

[<EntryPoint>]
let main argv = 
    argv |> ignore 
    printf "Day  1:  "; printfn "%s" (formatResult Calendar01.get_solution)
    printf "Day  2:  "; printfn "%s" (formatResult Calendar02.get_solution)
    printf "Day  3:  "; printfn "%s" (formatResult Calendar03.get_solution)
    printf "Day  4:  "; printfn "%s" (formatResult Calendar04.get_solution)
    printf "Day  5:  "; printfn "%s" (formatResult Calendar05.get_solution)
    printf "Day  6:  "; printfn "%s" (formatResult Calendar06.get_solution)
    printf "Day  7:  "; printfn "%s" (formatResult Calendar07.get_solution)
    printf "Day  8:  "; printfn "%s" (formatResult Calendar08.get_solution)
    printf "Day  9:  "; printfn "%s" (formatResult Calendar09.get_solution)
    printf "Day 10:  "; printfn "%s" (formatResult Calendar10.get_solution)
    printf "Day 11:  "; printfn "%s" (formatResult Calendar11.get_solution)
    printf "Day 12:  "; printfn "%s" (formatResult Calendar12.get_solution)
    printf "Day 13:  "; printfn "%s" (formatResult Calendar13.get_solution)
    printf "Day 14:  "; printfn "%s" (formatResult Calendar14.get_solution)
    printf "Day 15:  "; printfn "%s" (formatResult Calendar15.get_solution)
    printf "Day 16:  "; printfn "%s" (formatResult Calendar16.get_solution)
    printf "Day 17:  "; printfn "%s" (formatResult Calendar17.get_solution)
    printf "Day 18:  "; printfn "%s" (formatResult Calendar18.get_solution)
    printf "Day 19:  "; printfn "%s" (formatResult Calendar19.get_solution)
    printf "Day 20:  "; printfn "%s" (formatResult Calendar20.get_solution)
    printf "Day 21:  "; printfn "%s" (formatResult Calendar21.get_solution)
    printf "Day 22:  "; printfn "%s" (formatResult Calendar22.get_solution)
    printf "Day 23:  "; printfn "%s" (formatResult Calendar23.get_solution)
    printf "Day 24:  "; printfn "%s" (formatResult Calendar24.get_solution)

    System.Console.ReadKey() |> ignore
    0 // return an integer exit code