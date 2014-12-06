﻿module Calendar06

//PROBLEM
//I dagens luke skal vi på en magisk reise i den lille (og den ekstremt store) gangetabellen.
//Den lille gangetabellen ser slik ut:
//1  2  3  4  5  6  7  8  9
//2  4  6  8 10 12 14 16 18
//3  6  9 12 15 18 21 24 27
//4  8 12 16 20 24 28 32 36
//5 10 15 20 25 30 35 40 45
//6 12 18 24 30 36 42 48 54
//7 14 21 28 35 42 49 56 63
//8 16 24 32 40 48 56 64 72
//9 18 27 36 45 54 63 72 81
//Denne 9 x 9 tabellen inneholder 36 unike produkt, og de er som følger: 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 24, 25, 27, 28, 30, 32, 35, 36, 40, 42, 45, 48, 49, 54, 56, 63, 64, 72 og 81.
//Hvor mange unike produkt finnes det i en 8000 x 8000 tabell?

//CORRECT: 14509549

//C# Version
//List<int> numbers = new List<int>();
//int limit = 8000;
//for (int i = 1; i <= limit; i++)
//{
//    Console.WriteLine(i);
//    for (int j = 1; j <= limit; j++)
//    {
//        int number = i*j;
//        //if (!numbers.Contains(number))
//        //{
//            numbers.Add(number);
//        //}
//    }
//}
//var dN = numbers.Distinct();
//int length = dN.ToList().Count;


let getOneArray limit factor =
    [|1 .. limit|] |> Array.map (fun x -> x * factor)

//TODO: Fix
let getAllArrays limit =
    let d1 = [|1 .. limit|]
    let d2 = d1 |> Array.map (getOneArray limit)
    let d3 = Array.fold (fun acc x -> Array.append acc x) [||] d2
    let d4 = d3 |> Array.toSeq
    let d5 = d4 |> Seq.distinct
    Seq.length d5

let getSolution =
    let d1 = getAllArrays 8000
    sprintf "%A" d1