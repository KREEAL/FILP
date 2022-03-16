// Learn more about F# at http://fsharp.org

open System

[<AbstractClass>]
type GeometryFigure() =
    abstract member Square: unit -> double

type Rectangle(ap:double,bp:double)=
    inherit GeometryFigure()
    let mutable width = ap
    let mutable height = bp
    member this.ReadWriteWidth
        with get() = width
        and set(value) = width <-value
    member this.ReadWriteHeight
        with get() = height
        and set(value) = height <-value
    override this.Square() = (height * width)

type Square(ap:double,bp:double)=
    inherit Rectangle(ap,bp)
    let mutable side = ap
    member this.ReadWriteSide
        with get() = side
        and set(value) = side <-value
    new(a:double) = Square(a,a)

[<EntryPoint>]
let main argv =
    let Rect1 = Rectangle(2.0,4.0)
    Console.WriteLine (Rect1.Square())
    
    let Sqre = Square(5.0)
    Console.WriteLine(Sqre.Square())

    printfn "Hello World from F#!"
    0 // return an integer exit code
