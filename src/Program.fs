module AdventOfCode2024.Program

[<EntryPoint>]
let main args =
    match int args[0] with
        | 1 -> Day1.solve; 0
        | 2 -> Day2.solve; 0
        | _ -> -1