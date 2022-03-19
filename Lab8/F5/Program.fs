// Learn more about F# at http://fsharp.org

open System

type driversLicense(nam:string, surnam:string, birtDt:DateTime, plac:string, extDt: DateTime, expDt:DateTime,nm:int ) =
    member this.name:string = nam
    member this.surname:string = surnam
    member this.birthDt:DateTime = birtDt
    member this.place:string = plac
    member this.extrDT:DateTime = extDt
    member this.exprDT:DateTime = expDt
    member this.num:int = nm

    override this.ToString() = "Водительские права:"+"\n Имя: "+ this.name + "\n Фамилия: " + this.surname+ "\n Дата рождения: "+ this.birthDt.ToShortDateString()  + "\n Место рождения: " + this.place+ "\n Дата выдачи: "+ this.extrDT.ToShortDateString() + "\n Дата конца срока: "+ this.exprDT.ToShortDateString() + "\n Номер: " + this.num.ToString() 


[<EntryPoint>]
let main argv =

    let drL1 = driversLicense("Иван","Иванов",DateTime.Parse "01.01.1990","г.Москва",DateTime.Parse "01.01.2020",DateTime.Parse "01.01.2030",7777777)
    Console.WriteLine drL1
    0 // return an integer exit code
