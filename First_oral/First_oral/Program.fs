// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

//Ex 1
let biggest: int->int->int->string = 
    fun arg1 arg2 arg3 -> 
        if arg1>arg2 && arg1>arg3 then "arg1 is the biggest"
        else if arg2 > arg1 && arg2 > arg3 then "arg2 is the biggest"
        else if arg3 > arg1 && arg3 > arg2 then "arg3 is the biggest"
        else "two or more numbers are equal"

//Ex 2
let Unpack:option<option<'a>> -> option<'a> =
    //Return the unpacked value by applying a match with statement
    fun x -> match x with
             |Some(Some(x)) -> Some(x)
             |Some(None) -> None
             |None -> None

//Ex 3

let DeOption : option<'a> list-> 'a list =
    fun optlist ->
        optlist
        //Filter the list by removing all None's with match with statement.
        |>List.filter(fun x -> match x with
                                |Some(y) -> true
                                |None -> false)
        //Manipulate the list by unpacking all the Some's with a match with statement.
        |>List.map(fun x -> match x with
                             |Some(y) -> y
                             |None -> failwith"Check filter")

//Ex 4
let ex4 : ('a*'b)-> 'c -> ('a->'b->'c)=
    // variables: f = ('a*'b); g = c; x = a; y = b.
    fun f g-> 
        fun x y -> g
          
//Ex 5 
type person =
    {
        name:string
        surname:string
        age:int
    }
 let agePlusOne _person = 
    {_person with age = _person.age + 1}

[<EntryPoint>]
let main argv = 
    //Ex 1
    printfn "Ex 1"
    printfn "input: 1 2 3" 
    printfn "output : %A" (biggest 1 2 3)
    printfn "input: 1 3 2"
    printfn "output : %A" (biggest 1 3 2)
    printfn "input: 3 2 1"
    printfn "output : %A" (biggest 3 2 1)
    printfn "input: 1 1 1"
    printfn "output : %A" (biggest 1 1 1)
    printfn ""
    printfn ""
    //Ex 2
    printfn "Ex2"
    let a = Some(Some 5)
    printfn "input : %A" a
    printfn "output : %A" (Unpack a)
    printfn ""
    printfn ""

    //Ex 3
    printfn "Ex 3"
    printfn "prints None as null"
    let c = [Unpack a; None; Some 10]
    printfn "input : %A" c
    printfn "output : %A" (DeOption c )
    printfn ""
    printfn ""

    //Ex 4
    //Nvt
    printfn "Ex 4 - > Check the code."
    printfn ""
    printfn ""

    //Ex 5
    printfn "Ex 5"
    let _person = {name="a"; surname="b"; age =1}
    let personPlusOne = agePlusOne _person
    printfn "input : %A" _person
    printfn "output : %A" personPlusOne

    let x = System.Console.ReadLine();  
    0 // return an integer exit code
