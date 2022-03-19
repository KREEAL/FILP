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

[<AbstractClass>]
type DocClass() =
    abstract member searchDoc: driversLicense -> bool
(*
type ArrayDocClass()=
    inherit DocClass()
    let mutable Arr = Array.empty
    override this.searchDoc(drl) =  Array.contains drl Arr 
    member this.Add (x:driversLicense) = 
        let newArr = (Array.append  Arr [|x|]) 
        Arr = Array.append [|x|] Arr
        Console.WriteLine("Элемент добавлен")
    member this.Remove(x:driversLicense) = Array.filter (fun q-> not (driverLicenseNumEquality q x)) Arr
    override this.ToString() = "Записей: " + Arr.Length.ToString()
    //member this Arr: driversLicense*)

[<EntryPoint>]
let main argv =
    
    let drL1 = driversLicense("Иван","Иванов",DateTime.Parse "01.01.1991","г.Москва",DateTime.Parse "01.01.2021",DateTime.Parse "01.01.2031",7777777)
    let Ar1 = ArrayDocClass()
    Console.WriteLine(Ar1)
    Ar1.Add(drL1)
    Console.WriteLine(Ar1)
    printfn "Hello World from F#!"
    0 // return an integer exit code
