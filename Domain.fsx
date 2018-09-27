#r "System.Runtime.Serialization.dll"
#r "packages/FSharp.Data/lib/net45/FSharp.Data.dll"

open System.Runtime.Serialization
open FSharp.Data

type IrisData = CsvProvider<"data/iris.txt">

[<DataContract>]
type InputData = {
  [<field: DataMember(Name="data")>]
  data:float[][]
}

[<DataContract>]
type Prediction = {
    [<field:DataMember(Name="label")>]
    label: string []
}