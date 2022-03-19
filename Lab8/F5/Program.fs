// Learn more about F# at http://fsharp.org

open System
open System.Text.RegularExpressions


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

let (|Regex|) pattern input =
   let m = Regex.Match(input,pattern)
   if (m.Success) then Some m.Groups.[1].Value else None

let createDrLWithValidate = 
    let dtRegex = "^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
    let strRegex = "@[A-Z][a-z]*"
    let surname = Console.ReadLine()
    let name = Console.ReadLine()
    let (birthdayDT:string) = Console.ReadLine()
    let (place:string) = Console.ReadLine()
    let extDate = Console.ReadLine()
    let expDate = Console.ReadLine()
    let num = Console.ReadLine()
       
    if (Regex.IsMatch(name,strRegex) && Regex.IsMatch(surname,strRegex)
        && Regex.IsMatch(birthdayDT,dtRegex) && Regex.IsMatch(place,strRegex)&&
        Regex.IsMatch(extDate,dtRegex)&& Regex.IsMatch(expDate,dtRegex)&& Regex.IsMatch(num,"^[1-9]+[0-9]*$")) then 
        Some(driversLicense(name,surname,DateTime.Parse birthdayDT,place,DateTime.Parse extDate,DateTime.Parse expDate,Int32.Parse num))
    else
        None


[<EntryPoint>]
let main argv =


    let drL1 = driversLicense("Иван","Иванов",DateTime.Parse "01.01.1991","г.Москва",DateTime.Parse "01.01.2021",DateTime.Parse "01.01.2031",7777777)
    Console.WriteLine drL1

    let drL2 = driversLicense("Петр","Петров",DateTime.Parse "02.02.1992","г.Санкт-Петербург",DateTime.Parse "02.02.2022",DateTime.Parse "02.02.2032",6666666)
    match driverLicenseNumEquality drL1 drL2 with
    |true-> Console.WriteLine("Номера документов совпадают")
    |false-> Console.WriteLine("Номера документов не совпадают")
    
    let q1 = createDrLWithValidate 
    match q1 with
    |driversLicense -> Console.WriteLine "Объет успешно создан"
    |None->Console.WriteLine "Объект не создан"
    0 // return an integer exit code
