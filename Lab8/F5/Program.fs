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

    override this.ToString() = "\nВодительские права:"+"\n Имя: "+ this.name + "\n Фамилия: " + this.surname+ "\n Дата рождения: "+ this.birthDt.ToShortDateString()  + "\n Место рождения: " + this.place+ "\n Дата выдачи: "+ this.extrDT.ToShortDateString() + "\n Дата конца срока: "+ this.exprDT.ToShortDateString() + "\n Номер: " + this.num.ToString()+"\n"

let driverLicenseNumEquality (dr1:driversLicense) (dr2:driversLicense) =
    if dr1.num = dr2.num then true
    else false

[<EntryPoint>]
let main argv =

    let drL1 = driversLicense("Иван","Иванов",DateTime.Parse "01.01.1991","г.Москва",DateTime.Parse "01.01.2021",DateTime.Parse "01.01.2031",7777777)
    Console.WriteLine drL1

    let drL2 = driversLicense("Петр","Петров",DateTime.Parse "02.02.1992","г.Санкт-Петербург",DateTime.Parse "02.02.2022",DateTime.Parse "02.02.2032",6666666)
    match driverLicenseNumEquality drL1 drL2 with
    |true-> Console.WriteLine("Номера документов совпадают")
    |false-> Console.WriteLine("Номера документов не совпадают")
    0 // return an integer exit code
