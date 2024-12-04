module AdventOfCode2024.Day2

open System.IO

let parseLine (line: string): int array =
    line.Split(" ") |> Array.map int
    
let parse (path: string) : int array array =
    File.ReadLines(path)
    |> Seq.filter (not << System.String.IsNullOrWhiteSpace)
    |> Seq.map parseLine
    |> Seq.toArray
    
let solve =
    let reports = parse("Input/Day2.txt")
    let diff (report: int seq) = report
                                |> Seq.pairwise
                                |> Seq.map (fun (a, b) -> b - a)
                                
    let increasing levels = levels |> diff |> Seq.forall(fun x -> x < 0)
    let decreasing levels = levels |> diff |> Seq.forall(fun x -> x > 0)
    let withinRange levels = levels |> diff |> Seq.forall(fun x -> abs x >= 1 && abs x <= 3)
    let safe (levels: int seq) = (increasing(levels) || decreasing(levels)) && withinRange(levels)
    
    let safeCount = reports |> Seq.filter safe |> Seq.length
    printfn $"{safeCount}"
    
    let safeWithDamping levels = levels |> Seq.mapi(fun i _ -> levels |> Seq.removeAt i) |> Seq.exists safe
    let safeCount = reports |> Seq.filter safeWithDamping |> Seq.length
    printfn $"{safeCount}"
