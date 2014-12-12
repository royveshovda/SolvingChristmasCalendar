module Calendar10

//PROBLEM
//Velkommen til Knowit sitt julebord!
//På julebordet er vi 1500 mennesker som sitter rundt et stort bord. Vi er nummerert fra 1 til 1500 langs bordet.
//Vi har fått tak i en flaske med meget sterk (men god!) akevitt.
//Den første personen tar flasken og serverer person nummer to en dram.
//Akevitten er så sterk at denne personen går rett i bakken.
//Person nummer en sender så flaska videre til den tredje personen som serverer den fjerde en dram.
//Han går også rett i bakken og flasken sendes videre til femtemann.
//Dette fortsetter rundt slik at person nummer 1499 serverer person 1500 en dram (hvorpå han dundrer i gulvet) og gir flaska tilbake den første.
//Nå serverer den første personen den tredje (som deiser av stolen) og gir flaska videre til den femte...
//Dette fortsetter til det bare er en person igjen. Hvilken person sitter igjen ved julebordets slutt?
//Svaret skal være i form av nummeret på personen som sitter igjen, eksempelvis 1337

open Common

let correct = "953"
let expectedRuntimeInMs = 1L

let lastManStanding n =
    let people = Array.init (n) (fun i -> i+1)
    people.[(n - 1)] <- 1
    let rec lastManStandingImpl index = 
        let nextIndex = people.[index]
        let nextNextIndex = people.[nextIndex]
        match nextNextIndex with
        | 0 -> (index - 1)
        | _ -> people.[index] <- nextNextIndex
               people.[nextIndex] <- 0
               lastManStandingImpl nextNextIndex
    lastManStandingImpl 0

let getSolution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let survivor = lastManStanding 1500
    stopWatch.Stop()
    let value = sprintf "%i" survivor
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }