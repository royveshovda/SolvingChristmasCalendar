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

let filename = "..\\..\\..\\Data\\words.txt"

let read_words (filename:string)=
    use fs = File.OpenText(filename)
    let text = fs.ReadToEnd()
    let words =
        text.Split ('\n')
        |> Seq.toArray
    words


let is_anagram (word1: string) (word2: string) =
    let s1 = ( word1.ToCharArray() |> Array.sort)
    let s2 = ( word2.ToCharArray() |> Array.sort)
    s1 = s2

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //let v = is_anagram "word1" "word1"
    let v = read_words filename

    //TODO: Implement more here

    let value = sprintf "%A" v
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=value; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }