#r "packages/Suave/lib/net461/Suave.dll"

#load "Domain.fsx"
#load "Model.fsx"

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Json
open Domain
open Model

let port = "127.0.0.1"
let host = 3001

let serverConfig = {
    defaultConfig with 
        bindings = [HttpBinding.createSimple Protocol.HTTP port host]
}

let makePrediction (requestData:InputData) = 
    let prediction = predict(requestData.data)
    {label=prediction}

let app = 
    choose [
        POST >=> path "/api/predict" >=> mapJson makePrediction
    ]

startWebServer serverConfig app
