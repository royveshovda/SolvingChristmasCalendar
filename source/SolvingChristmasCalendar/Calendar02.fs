module Calendar02

//PROBLEM
//I dagens luke skal vi trikse litt med primtall.
//For et gitt nummer, n, finn tallet m, hvor det første sifferet i m = n og antall siffer i m = n og hver tosifret tallsekvens i m skal være unike primtall. Tallet skal også være lavest mulig.
//Eksempel: Dersom n = 5 blir m = 53113.
//    Første siffer i m er 5.
//    Antall siffer i m er 5.
//    De tosifrete tallsekvensene i m, 53, 31, 11 og 13, er alle unike primtall.
//    Det er det laveste mulige tallet som oppfyller alle disse egenskapene.
//Hva er m dersom n = 9?


let getPrimes = 
    [|11;13;17;19;23;29;31;37;41;43;47;53;59;61;67;71;73;79;83;89;97|]

//TODO: Improve

let getNumber = 
    //97
    // 71
    //  11
    //   13
    //    31
    //     17
    //      73
    //       37
    971131737

let getSolution = 
    sprintf "%i" getNumber
