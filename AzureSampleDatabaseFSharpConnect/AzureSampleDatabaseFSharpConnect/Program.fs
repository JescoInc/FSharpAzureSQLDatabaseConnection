open System
open System.Data
open System.Data.Linq
open Microsoft.FSharp.Data.TypeProviders
open Microsoft.FSharp.Linq

type dbSchema = SqlDataConnection<"Data Source=fsharptest.database.windows.net;Initial Catalog=ConnectFSharp;Integrated Security=False;User ID=test;Password=Passw0rd;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False">
let db = dbSchema.GetDataContext()

let table1 = db.SalesLT_Customer

let query1 =
        query {
            for row in db.SalesLT_Customer do
            select row
        }
query1 |> Seq.iter (fun row -> printfn "%s %A" row.CompanyName row.Phone)
Console.ReadLine()
