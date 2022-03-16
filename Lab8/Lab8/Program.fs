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
    member this.side: double = ap
    new(a:double) = Square(a,a)

type Circle(ap:double)=
    inherit GeometryFigure()
    let mutable radius = ap
    let pi = Math.PI
    member this.ReadWriteRadius
        with get() = radius
        and set(value) = radius <-value

    override this.Square() = pown radius 2 * pi

[<EntryPoint>]
let main argv =
    let Rect1 = Rectangle(2.0,4.0)
    Console.WriteLine (Rect1.Square())
    
    let Sqre = Square(5.0)
    Console.WriteLine(Sqre.Square())

    let Crcl = Circle(2.0)
    Console.WriteLine(Crcl.Square())

    printfn "Hello World from F#!"
    0 // return an integer exit code
