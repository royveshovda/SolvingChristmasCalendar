module Calendar16

//PROBLEM
// En toerpotens er et tall som kan skrives som 2^n der n er et heltall.
//Søk gjennom alle toerpotenser mindre enn 2^10000 og returner første n der en gitt substring forekommer.
//For eksempel, hvis stringen er “02”, så er svaret 10, fordi  2^10 = 1024 og ingen lavere toerpotenser inneholder “02”.
//Hva er n for den minste toerpotensen som inneholder “472047”? 

//C#
//static void Main(string[] args)
//{
//    int n = 0;
//    var running = true;
//    while (running)
//    {
//                
//        var sum = (BigInteger.Pow(2, n)).ToString();
//        if (sum.Contains("472047"))
//        {
//            running = false;
//        }
//        n++;
//        if (n >= 100000)
//        {
//            running = false;
//        }
//    }
//    Console.WriteLine(n-1);
//    Console.ReadLine();
//}

open Common

let correct = "1765"
let expectedRuntimeInMs = 0L

let get_solution =
    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    //TODO: Implement here
    stopWatch.Stop()
    { ExpectedValue=correct; ActualValue=correct; ExpectedRuntimeInMs=expectedRuntimeInMs; ActualRuntimeInMs=stopWatch.ElapsedMilliseconds }