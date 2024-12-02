module AdventOfCode2024.Day1

open System.IO
open System.Text.RegularExpressions

let parseLine (line: string) =
    let pattern = Regex(@"(\d+)\s+(\d+)")
    let result = pattern.Match(line)
    match result.Success with
        | true -> (int result.Groups[1].Value, int result.Groups[2].Value)
        | false -> (raise (InvalidDataException "failed to parse line"))
    
let parse (path: string) =
    File.ReadLines(path)
    |> Seq.filter (not << System.String.IsNullOrWhiteSpace)
    |> Seq.map parseLine
    |> Seq.toArray
    
let solve = 
    let input = parse "Input/Day1.txt"
    let lhs = input |> Array.map fst
    let rhs = input |> Array.map snd
  
    let sum = Array.zip (lhs |> Array.sort) (rhs |> Array.sort)
            |> Array.map (fun(a, b) -> abs (a - b))
            |> Array.sum
        
    printfn $"{sum}"
    
    let count (value: int) = rhs |> Array.filter ((=) value) |> Array.length
    let similarityScore = input |> Array.sumBy (fun (a, _) -> a * count a)

    printfn $"{similarityScore}" 