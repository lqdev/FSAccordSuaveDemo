# F# Suave Accord Demo

This sample project shows how to expose a machine learning model built with [Accord.NET](http://accord-framework.net/) via a [Suave](https://suave.io/) API

## Install

### Windows

```bash
.paket\paket.exe install
```

### Mac/Linux

```bash
mono .paket\paket.exe install
```

## Train Model

To train the model, run the `App.fsx` script

## Start Server

To initialize the server, run the `Server.fsx` script

## Get Prediction

With the server running, using a REST client like POSTMAN or Insomnia make an HTTP POST request to the enpoint `http://localhost:3001/api/predict`. In the request body include the `data` property which is a 2D array of type `float`.

### Sample Request Body
```json
{
	"data": [[3.3,1.6,0.2,5.1]] 
}
```

### Sample Response

```json
{
    "label": [
        "Iris-virginica"
    ]
}
```