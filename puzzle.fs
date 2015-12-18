module Puzzle
  let initialGrid = array2D [|
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 1; 1; 0; 0; 0; 0; 0; 0; 0; 1; 1; 0; 0; 0; 0; 0; 0; 0; 1; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 1; 1; 0; 0; 1; 0; 0; 0; 1; 1; 0; 0; 1; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 1; 0; 0; 0; 0; 1; 0; 0; 0; 0; 1; 0; 0; 0; 1; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 1; 1; 0; 0; 0; 0; 1; 1; 0; 0; 0; 0; 1; 0; 0; 0; 0; 1; 1; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              [|0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0|];
                              |]
  let rowTests = [
    [7;3;1;1;7];
    [1;1;2;2;1;1];
    [1;3;1;3;1;1;3;1];
    [1;3;1;1;6;1;3;1];
    [1;3;1;5;2;1;3;1];
    [1;1;2;1;1];
    [7;1;1;1;1;1;7];
    [3;3];
    [1;2;3;1;1;3;1;1;2];
    [1;1;3;2;1;1];
    [4;1;4;2;1;2];
    [1;1;1;1;1;4;1;3];
    [2;1;1;1;2;5];
    [3;2;2;6;3;1];
    [1;9;1;1;2;1];
    [2;1;2;2;3;1];
    [3;1;1;1;1;5;1];
    [1;2;2;5];
    [7;1;2;1;1;1;3];
    [1;1;2;1;2;2;1];
    [1;3;1;4;5;1];
    [1;3;1;3;10;2];
    [1;3;1;1;6;6];
    [1;1;2;1;1;2];
    [7;2;1;2;5];
  ]
  
  let colTests = [
    [7;2;1;1;7];
    [1;1;2;2;1;1];
    [1;3;1;3;1;3;1;3;1];
    [1;3;1;1;5;1;3;1];
    [1;3;1;1;4;1;3;1];
    [1;1;1;2;1;1];
    [7;1;1;1;1;1;7];
    [1;1;3];
    [2;1;2;1;8;2;1];
    [2;2;1;2;1;1;1;2];
    [1;7;3;2;1];
    [1;2;3;1;1;1;1;1];
    [4;1;1;2;6];
    [3;3;1;1;1;3;1];
    [1;2;5;2;2];
    [2;2;1;1;1;1;1;2;1];
    [1;3;3;2;1;8;1];
    [6;2;1];
    [7;1;4;1;1;3];
    [1;1;1;1;4];
    [1;3;1;3;7;1];
    [1;3;1;1;1;2;1;1;4];
    [1;3;1;4;3;3];
    [1;1;2;2;2;6;1];
    [7;1;3;2;1;1];
  ]