open canopy
open runner
open System

chromeDir <- @"C:\Users\anumart.c\Documents\visual studio 2015\Projects\TestCanopy\ChromeDriver"
start chrome

"Authen for test " &&& fun _->
        url "http://localhost:50307/Account/Login" 
        "#Email" << "test@email.com"
        "#Password" << "P@ssw0rd"
        click "input[type=submit]"

"Click add link then go to create page" &&& fun _ ->
        url "http://localhost:50307/cars"
        displayed "a#gotoAdd"
        click "a#gotoAdd"
        on "http://localhost:50307/cars/create"

"Add new car" &&& fun _ ->
        let make = "Tesla"+ DateTime.Now.Ticks.ToString()
        url "http://localhost:50307/cars/create" 
        "#Make" << make
        "#Model" << "Model 3"
        click "button#btnAdd"
        on "http://localhost:50307/cars/"
        "td.item" *= make

"Add new car" &&& fun _ ->
        let make = "Tesla"+ DateTime.Now.Ticks.ToString()
        url "http://localhost:50307/cars/create" 
        "#Make" << make
        "#Model" << "Model 3"
        click "button#btnAdd"
        on "http://localhost:50307/cars/"
        "td.item" *= make

"Add new car Failed" &&& fun _ ->
        let make = "Tesla"+ DateTime.Now.Ticks.ToString()
        url "http://localhost:50307/cars/create" 
        "#Make" << make
        "#Model" << "Model 3"
        click "button#btnAdd"
        "span.error" *= "cannot add more car"
//run all tests
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()

