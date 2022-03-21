// Learn more about F# at http://fsharp.org

open System
open System.Diagnostics

type driversLicense(nam:string, surnam:string, birtDt:DateTime, plac:string, extDt: DateTime, expDt:DateTime,nm:int ) =
    member this.name:string = nam
    member this.surname:string = surnam
    member this.birthDt:DateTime = birtDt
    member this.place:string = plac
    member this.extrDT:DateTime = extDt
    member this.exprDT:DateTime = expDt
    member this.num:int = nm
    override this.Equals(b) =
        match b with
        | :? driversLicense as p -> (this.num) = (p.num)
        | _ -> false
    override this.GetHashCode() = this.num.GetHashCode()
    interface System.IComparable with

    member this.CompareTo yobj =
        match yobj with
          | :? driversLicense as y -> if ((this.num) = (y.num)) then 1 else 0
          | _ -> invalidArg "yobj" "cannot compare values of different types" 
    end
    override this.ToString() = "\nВодительские права:"+"\n Имя: "+ this.name + "\n Фамилия: " + this.surname+ "\n Дата рождения: "+ this.birthDt.ToShortDateString()  + "\n Место рождения: " + this.place+ "\n Дата выдачи: "+ this.extrDT.ToShortDateString() + "\n Дата конца срока: "+ this.exprDT.ToShortDateString() + "\n Номер: " + this.num.ToString()+"\n"

[<AbstractClass>]
type DocClass() =
    abstract member searchDoc: driversLicense -> bool


type ArrayDocClass(list:'driversLicense list)=
    inherit DocClass()
    member this.Arr = Array.ofList list
    override this.searchDoc(drl) = 

        let watch = new Stopwatch()
        watch.Start()
        let startTime = watch.ElapsedTicks
        Console.WriteLine(startTime)

        let res = Array.exists (fun (x:driversLicense)-> x = drl) this.Arr

        watch.Stop()
        let endTime = watch.ElapsedTicks
        Console.WriteLine(endTime)

        Console.WriteLine(endTime-startTime)
        res

type ListDocClass(list:'driversLicense list)=
    inherit DocClass()
    member this.lIst = list
    override this.searchDoc(drl) = 

        let watch = new Stopwatch()
        watch.Start()
        let startTime = watch.ElapsedTicks
        Console.WriteLine(startTime)

        let res = List.exists (fun (x:driversLicense)-> x = drl) this.lIst

        watch.Stop()
        let endTime = watch.ElapsedTicks
        Console.WriteLine(endTime)

        Console.WriteLine(endTime-startTime)
        res

    override this.ToString() = "Записей: " + this.lIst.Length.ToString()


type SetDocClass(list:'driversLicense list)=
    inherit DocClass()
    member this.set = Set.ofList list
    override this.searchDoc(drl) = 

        let watch = new Stopwatch()
        watch.Start()
        let startTime = watch.ElapsedTicks
        Console.WriteLine(startTime)

        let res = Set.contains drl this.set

        watch.Stop()
        let endTime = watch.ElapsedTicks
        Console.WriteLine(endTime)

        Console.WriteLine(endTime-startTime)
        res

    override this.ToString() = "Записей: " + this.set.Count.ToString()

type BinaryTreeDocClass(list:'driversLicense list)=
    inherit DocClass()
    let rec binSearch (l:'driversLicense list) (el:driversLicense) =
        match List.length l with
        |0->false
        |i->let middle = i/2
            match sign <| compare el l.[middle] with
            |0->true
            |1->binSearch l.[..middle - 1] el
            |_->binSearch l.[middle + 1..] el              

    member this.binaryList = List.sortBy (fun (x:driversLicense)-> x.num) list 
    
    override this.searchDoc(drl) = 

        let watch = new Stopwatch()
        watch.Start()
        let startTime = watch.ElapsedTicks
        Console.WriteLine(startTime)

        let res = binSearch this.binaryList drl

        watch.Stop()
        let endTime = watch.ElapsedTicks
        Console.WriteLine(endTime)

        Console.WriteLine(endTime-startTime)
        res
    override this.ToString() = "Записей: " + this.binaryList.Length.ToString()

type Tree=
    |Leaf of int
    |Node of Tree * Tree


[<EntryPoint>]
let main argv =
    
    let drL1 = driversLicense("Иван","Иванов",DateTime.Parse "01.01.1991","г.Москва",DateTime.Parse "01.01.2021",DateTime.Parse "01.01.2031",7777777)
    let drL2 = driversLicense("Петр","Петров",DateTime.Parse "02.02.1992","г.Санкт-Петербург",DateTime.Parse "02.02.2022",DateTime.Parse "02.02.2032",6666666)
    let drL3 = driversLicense("Алексей","Алексеев",DateTime.Parse "03.03.1993","г.Рязань",DateTime.Parse "03.03.2023",DateTime.Parse "02.02.2033",5555555)
    let drL4 = driversLicense("Илья","Ильин",DateTime.Parse "04.04.1994","г.Краснодар",DateTime.Parse "04.04.2024",DateTime.Parse "02.02.2034",4444444)
    let drL5 = driversLicense("Егор","Егоров",DateTime.Parse "05.05.1995","г.Тихорецк",DateTime.Parse "05.05.2025",DateTime.Parse "02.02.2035",3333333)
    
    let licensesList = [drL1]@[drL2]@[drL3]@[drL4]@[drL5]

    ////********************************************************//
    let coolArray = ArrayDocClass(licensesList)
    coolArray.searchDoc(drL4)//где-то 50 тиков проходит(45-60)
    ////********************************************************//


    ////********************************************************//
    let coolList = ListDocClass(licensesList)
    coolList.searchDoc(drL4)//три раза подряд дало 53 тика
    ////********************************************************//

    ////********************************************************//
    let coolSet = SetDocClass(licensesList)
    coolSet.searchDoc(drL4)//47-77 тиков
    ////**************************

    ////********************************************************//
    let coolBinaryList = SetDocClass(licensesList)
    coolBinaryList.searchDoc(drL4)//56-61
    ////***************************


    //Console.WriteLine(Ar1)
    printfn "Hello World from F#!"
    0 // return an integer exit code
