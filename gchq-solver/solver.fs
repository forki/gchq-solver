﻿module solver

open utility
open common
open possibles

let cellPreferUnknown first second = 
  match (first, second) with
  | (B, B) -> B
  | (W, W) -> W
  | _ -> U

let cellPreferFirst first second = 
  match (first, second) with
  | (U, _) -> second
  | _ -> first

let cellIncompatible first second = 
  match (first, second) with
  | (B, W) -> true
  | (W, B) -> true
  | _ -> false

let testAxis (axis) (test : int list) = 
  match List.exists (fun x -> x = U) axis with
  | true -> Indeterminate
  | _ -> 
    let axisGroups = getGroups axis
    let axisGroupCount = List.length axisGroups
    let testCount = List.length test
    match (axisGroupCount, testCount) with
    | (a, b) when a > b -> Fail
    | (a, b) when a = b -> 
      match List.forall2 (fun axisGroup testGroup -> (List.length axisGroup) = testGroup) axisGroups test with
      | true -> Pass
      | false -> Fail
    | _ -> Indeterminate

let trySolveAxis (axis : CellResult list) (testGroups : int list) (possibles : CellResult list list) = 
  let testAnswer = 
    match testGroups.Length with
    | 0 -> List.replicate axis.Length W
    | _ -> 
      testGroups
      |> List.collect (fun groupLength -> W :: List.replicate groupLength B)
      |> List.tail
  
  let result = 
    match testGroups with
    | [] -> List.replicate axis.Length W
    | _ -> 
      let minimumSolutionWidth = List.length testAnswer
      match axis.Length = minimumSolutionWidth with
      | true -> testAnswer
      | false -> 
        let filteredPossibles = possibles |> List.filter (fun r -> not (List.exists2 cellIncompatible axis r))
        if filteredPossibles.Length = 0 then axis
        else 
          filteredPossibles
          |> List.reduce (List.map2 cellPreferUnknown)
          |> List.map2 cellPreferFirst axis
  
  result

let tryImproveSolution (state : PuzzleState) (possiblesCache : Map<int * int list, CellResult list list>) 
    (orientation : Axis) (index : int) = 
  let currentAxisState = getAxis orientation index state.Cells
  if List.forall (fun c -> c <> U) currentAxisState then state
  else 
    let test = 
      match orientation with
      | Row -> state.RowTests.[index]
      | Column -> state.ColumnTests.[index]
    
    let possibles = possiblesCache.Item(currentAxisState.Length, test)
    let newAxisState = trySolveAxis currentAxisState test possibles
    match currentAxisState = newAxisState with
    | true -> state
    | false -> 
      let change = 
        { Orientation = orientation
          Index = index
          NewAxisState = newAxisState }
      { state with Cells = 
                     getAllAxis orientation state.Cells
                     |> List.mapi (fun i r -> 
                          if i <> index then r
                          else newAxisState)
                     |> array2D
                     |> if orientation = Column then rotate
                        else id
                   AxisChanges = change :: state.AxisChanges }



let solvePuzzle (cells : CellResult [,]) (rowTests : int list list) (colTests : int list list) =
  let width = Array2D.length2 cells
  let height = Array2D.length1 cells
  let possiblesForRows = rowTests |> List.map (fun x -> ((width, x), getPossibles width x))
  let possiblesForColumns = colTests |> List.map (fun x -> ((height, x), getPossibles height x))
  let possiblesCache = List.append possiblesForRows possiblesForColumns |> Map.ofList
  let mutable currentState = 
      { RowTests = rowTests
        ColumnTests = colTests
        Cells = cells
        AxisChanges = [] }
  let finishedIndex = 
      seq { 0..1000 } |> Seq.tryFind (fun i -> 
                           let testIndex = i % (width + height)
                           
                           let orientation = 
                             if testIndex < height then Row
                             else Column
                           
                           let index = 
                             match orientation with
                             | Row -> testIndex
                             | Column -> testIndex - height
                           
                           currentState <- tryImproveSolution currentState possiblesCache orientation index
                           let finished = 
                             rows currentState.Cells |> List.forall (fun r -> List.forall (fun c -> c <> U) r)
                           finished)
  currentState