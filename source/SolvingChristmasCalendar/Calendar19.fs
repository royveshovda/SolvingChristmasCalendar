module Calendar19

//PROBLEM
//Et palindrom er et ord som gir samme resultat enten det leses fra høyre eller venstre, for eksempel Lol.
//Gitt denne stringen på litt over 1200 tegn (separert med linjeskift kun for syns skyld):
//........
//Hva er det lengste substrengen du finner i denne strengen som er et palindrom? Svaret skal være palindromet. 

open Common

let correct = "etute"
let expectedRuntimeInMs = 1000L

let text =
    let t = 
        "JegtroringenkanleveetheltlivutenkjærlighetMenkjærlighetenharmange"+
        "ansikterIhøstkomdetutenboksomheterErlikKjærlighetDenbeståravsamtaler"+
        "medselgereavgatemagasinetsomnåeretablertimangenorskebyerAlleharde"+
        "enhistorieåfortelleomkjærlighetsomnoeavgjørendeEntendetertilen"+
        "partneretfamiliemedlemenvennelleretkjæledyrMangeharopplevdåbli"+
        "sveketogselvåsvikteMenutrolignokblirikkekjærlighetsevnenødelagt"+
        "allikevelDenbyggesoppigjengangpågangKjærligheteneretstedåfeste"+
        "blikketDengirossretningognoeåstyreetterDengirossverdisommennesker"+
        "ognoeåleveforPåsammemåtesomkjærligheteneretfundamentimenneskelivet"+
        "erGrunnlovenetfundamentfornasjonenNorgeFor200årsidensamletengruppe"+
        "mennsegpåEidsvollforålagelovensomskullebligrunnlagettildetselvstendige"+
        "NorgeGrunnlovensomdengangblevedtattharutvikletsegipaktmedtidenog"+
        "sikreridagdetnorskefolkrettigheterviletttarforgittihverdagenRettighetersom"+
        "menneskerimangeandrelandbarekandrømmeomogsomdeslossformedlivet"+
        "sominnsatsJeghåperatvigjennomjubileumsfeiringeni2014vilbliminnetom"+
        "hvaGrunnlovenegentligbetyrforosssåvikanfortsetteåarbeideforverdiene"+
        "vårebådeherhjemmeoginternasjonaltJegharlysttilånevnenoeneksempler"+
        "påhvordanGrunnlovenvirkerinnpåenkeltmenneskerslivTenkdegatduskriver"+
        "etkritiskinnleggomlandetsstyrepåsosialemedier"
    t.ToLower()

let get_sub_palindromes (text: string)=
    let length = text.Length
    [|
        for c in 0 .. length do
            let stop = length - c
            for i in 1 .. stop do
                let s = text.Substring(c,i)
                if (is_palindrome s) then yield s
    |]

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    let value =
        get_sub_palindromes (text.ToLower())
        |> Array.maxBy (fun (elem:string) -> elem.Length)
    stopWatch.Stop()
    {
        ExpectedValue=correct;
        ActualValue=value;
        ExpectedRuntimeInMs=expectedRuntimeInMs;
        ActualRuntimeInMs=stopWatch.ElapsedMilliseconds
    }