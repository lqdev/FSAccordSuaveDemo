#r "packages/FSharp.Data/lib/net45/FSharp.Data.dll"
#r "packages/Accord/lib/net45/Accord.dll"
#r "packages/Accord.Math/lib/net45/Accord.Math.dll"
#r "packages/Accord.Math/lib/net45/Accord.Math.Core.dll"
#r "packages/Accord.Statistics/lib/net45/Accord.Statistics.dll"
#r "packages/Accord.MachineLearning/lib/net45/Accord.MachineLearning.dll"

#load "Datahelpers.fsx"
#load "Domain.fsx"

open FSharp.Data
open Accord.IO
open Accord.Math
open Accord.Statistics.Distributions.Univariate
open Accord.MachineLearning.Bayes
open Datahelpers
open Domain

[<Literal>]
let Modelpath = "IrisNB.model"
let dataPath = "data/iris.txt"

let getData (dataPath:string) = 
    
    let data = IrisData.Load(dataPath)

    let input = 
        data.Rows
        |> Seq.map(fun sample -> 
            [|
                sample.SepalLength |> float
                sample.SepalWidth |> float
                sample.PetalLength |> float
                sample.PetalWidth |> float
            |]
        )
        |> Seq.toArray

    let output = 
        data.Rows
        |> Seq.map(fun sample -> 
            fromCategorical sample.Class
        )
        |> Seq.toArray

    (input,output)

let train = 
    let input,output = getData dataPath
    let learner = new NaiveBayesLearning<NormalDistribution>()
    let model = learner.Learn(input,output)
    Serializer.Save(learner.Model,Modelpath)

let predict (input:float[][]) = 
    let model = Serializer.Load<NaiveBayes<NormalDistribution>>(Modelpath)
    let prediction = 
        model.Decide(input)
        |> Array.map(toCategorical)
    prediction