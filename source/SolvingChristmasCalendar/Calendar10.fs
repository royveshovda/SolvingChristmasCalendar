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

//CORRECT: 953

//C#
//private static bool Kill(Drinker worker, Drinker lastCandidate)
//{
//    if (lastCandidate.Id == worker.Id)
//    {
//        return false;
//    }
//    else
//    {
//        if (worker.Alive)
//        {
//            worker.Kill();
//            return true;
//        }
//        else
//        {
//            return Kill(worker.Next, lastCandidate);
//        }
//    }
//
//}

//static void Main(string[] args)
//{
//    const int limit = 1500;
//    var first = new Drinker(1);
//    var previous = first;
//    for (var i = 2; i <= limit; i++)
//    {
//        var drinker = new Drinker(i);
//        previous.SetNext(drinker);
//        previous = drinker;
//        if (i == limit)
//        {
//            drinker.SetNext(first);
//        }
//    }

//    bool alive = true;

//    Drinker worker = first;
//    Drinker last = first;
//    while (alive)
//    {
//        if (worker.Alive)
//        {
//            last = worker;
//            if (!Kill(worker.Next, worker))
//            {
//                alive = false;
//                break;
//            }
//            else
//            {
//                worker = worker.Next;
//            }
//        }
//        else
//        {
//            worker = worker.Next;
//        }
//    }
//    Console.WriteLine(last.Id);
//    Console.ReadKey();
//}

let nextToken (token: int) (listSize: int) =
    match token with
    | listSize -> 1
    | _ -> token + 1

let rec getNextValidToken (l: bool list) token =
    let size = l.Length
    let candidateToken = nextToken token size
    let candidate = l.[candidateToken]
    match candidate with
    | true -> token
    | false -> getNextValidToken l (token + 1)

let rec passToken l token =
    let next = getNextValidToken l token
    match next with
    | token -> token
    | _ ->
        l.[token] <- false
        let nextJump = getNextValidToken l next
        match next with
        | token -> token
        | _ -> passToken l nextJump       
        
let getSolution =
    let mutable list = List.init 1500 (fun _ -> true)
    let survivor = passToken list 1
    sprintf "%i" survivor