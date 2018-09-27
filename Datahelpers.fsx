let fromCategorical sample =
    match sample with
        | "Iris-setosa" -> 0
        | "Iris-versicolor" -> 1
        | "Iris-virginica" -> 2
        | _ -> -1

let toCategorical encoding =
    match encoding with
        | 0 -> "Iris-setosa"
        | 1 -> "Iris-versicolor"
        | 2 -> "Iris-virginica"
        | _ -> ""