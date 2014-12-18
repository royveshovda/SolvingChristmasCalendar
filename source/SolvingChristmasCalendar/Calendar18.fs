module Calendar18

//PROBLEM
// Ord som er blitt formet av samme sett med bokstaver kalles anagrammer av hverandre. For eksempel er arver, varer og raver anagrammer. Et annet eksempel er sole og lose.
//Din oppgave er å skrive et program som søker gjennom ordlista words.txt, https://dl.dropboxusercontent.com/u/42659711/words.txt, for å finne den største samlingen med anagrammer - altså den største mengden ord som finnes i ordlista og som er anagrammer av hverandre. Svaret skal være bokstavene som utgjør den største samlingen anagrammer, sortert alfabetisk og i lower case.
//Hvis vi går tilbake til eksemplene over, til ordlista med 5 ord, har vi 3 og 2 anagrammer. Her blir da 3 den største samlingen anagrammer. Svaret skal være bokstavene i anagrammene, sortert alfabetisk, som da ville vært aerrv.
//“Samme ord” kan forekomme flere ganger i ordlista, men med forskjellig casing. Disse regnes fortsatt som anagrammer av hverandre. De er tross alt forskjellige ord som bygges opp av de samme bokstavene.
//For sikkerhets skyld:
//$ md5 words.txt
//MD5 (words.txt) = 2cf1a35b9c05153d37a1ee7465893be3 

open Common
open System.IO

let correct = "N/A"
let expectedRuntimeInMs = 0L

//let filename = "..\\..\\..\\Data\\words.txt"
let filename = "/Users/royveshovda/src/SolvingChristmasCalendar/source/Data/words.txt"

let read_words (filename:string)=
    use fs = File.OpenText(filename)
    let text = fs.ReadToEnd()
    let words =
        text.Split ('\n')
        |> Seq.mapi (fun n elem -> (n,(elem.ToLower())))
        |> Seq.toArray
    words

let is_anagram (word1: string) (word2: string) =
    match (word1.Length = word2.Length) with
    | false -> false
    | true ->
        let s1 = ( word1.ToCharArray() |> Array.sort)
        let s2 = ( word2.ToCharArray() |> Array.sort)
        s1 = s2

let find_number_of_anagrams (word: string) (words: string[]) (counter: int) =
    printfn "%i" counter
    let l = word.Length
    let candidates = Array.filter (fun (elem: string) -> elem.Length = l) words
    let count =
        candidates
        |> Array.map (fun elem -> if (is_anagram word elem) then 1 else 0)
        |> Array.sum
    count

//TODO: Loop and remove found anagrams

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //let v = is_anagram "word1" "word1"
    let words = read_words filename

    let single_words = Array.map (fun (_, elem) -> elem) words

    let v3 =
        words
        |> Array.map (fun (n, elem) -> (elem, (find_number_of_anagrams elem single_words n)))
        |> Array.maxBy (fun (_, count) -> count)

    //let v2 = find_anagrams "aba" words
    //TODO: Implement more here

    let value = sprintf "%A" v3
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }