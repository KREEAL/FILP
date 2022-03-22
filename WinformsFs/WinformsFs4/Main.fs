(*open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()
// Создание формы с заголовком "Работа с массивом"
let form = new Form(Text="Работа с массивом")
// Создание подписи для поля ввода
let label1 = new Label()
label1.Location<-new Point(100,25) 
label1.Text<-"массив 1" 
label1.Width<-60 
label1.Height<-12 
 
// Создание подписи для поля вывода
let label2 = new Label()
label2.Location<-new Point(100,70)
label2.Text<-" массив 2"
label2.Width<-60
label2.Height<-12
let label3 = new Label()
label3.Location<-new Point(100,110)
label3.Text<-"массив 3"
label3.Width<-60
label3.Height<-12
let label4 = new Label()
label4.Location<-new Point(100,160)
label4.Text<-"массив 4"
label4.Width<-60
label4.Height<-12
// Создание текстового поля для ввода информации
let txtInputA = new TextBox()
txtInputA.Location<-new Point(170,25)
txtInputA.Width<-100
txtInputA.Height<-25
txtInputA.Text<-"" 
// Создание текстового поля для вывода информации
let txtOutputB = new TextBox()
txtOutputB.Location<-new Point(170,70)
txtOutputB.Width<-100
txtOutputB.Height<-25
txtOutputB.Text<-""
let txtOutputC = new TextBox()
txtOutputC.Location<-new Point(170,110)
txtOutputC.Width<-100
txtOutputC.Height<-25
txtOutputC.Text<-""
let txtOutputD = new TextBox()
txtOutputD.Location<-new Point(170,130)
txtOutputD.Width<-100
txtOutputD.Height<-25
txtOutputD.Text<-""
let txtOutputE = new TextBox()
txtOutputE.Location<-new Point(170,160)
txtOutputE.Width<-100
txtOutputE.Height<-25
txtOutputE.Text<-""
let txtOutputF = new TextBox()
txtOutputF.Location<-new Point(170,180)
txtOutputF.Width<-100
txtOutputF.Height<-25
txtOutputF.Text<-""
let txtOutputG = new TextBox()
txtOutputG.Location<-new Point(170,210)
txtOutputG.Width<-100
txtOutputG.Height<-25
txtOutputG.Text<-""
// Создание кнопки с текстом "Вычислить!"
let button = new Button(Text="Вывести_1")
button.Location<-new Point(15,25) // позиция кнопки
//Добавление обработчика события - Нажатие на кнопку
button.Click.AddHandler(fun _ _ -> 
 let array3 = [|for i in 1 .. 10 -> i * i|] 
 //txtInputA.Text <- (array3 |> sprintf "%A") тоже вывод массива 
 let run = txtInputA.Text<- (array3 |> Seq.map string |> String.concat ", ")
 run 
 |> ignore)
let button1 = new Button(Text="Вывести_2")
button1.Location<-new Point(15,70)
button1.Click.AddHandler(fun _ _ -> 
 
 let arrayOfTenZeroes : string array = Array.zeroCreate 10 
 let run = txtOutputB.Text<- (arrayOfTenZeroes |> Seq.map string |> 
String.concat ", ")
 run
 |> ignore)
let button3 = new Button(Text="Вывести_3")
button3.Location<-new Point(15,110)
button3.Click.AddHandler(fun _ _ -> 
    let stringReverse (txtOutputC: string) = System.String(Array.rev (txtOutputC.ToCharArray())) 
    let run = txtOutputD.Text <- ( stringReverse (txtOutputC.Text))
    run|> ignore)


let button4 = new Button(Text="Вывести_4")
button4.Location<-new Point(15,160)
button4.Click.AddHandler(fun _ _ -> 
let array = [| 1 .. 10 |] |> Array.filter (fun elem -> elem % 2 = 0) |> Array.rev
let run = txtOutputE.Text<- ( array |> Seq.map string |> String.concat ", ")
run|> ignore)
let button2 = new Button(Text="Выход")
button2.Location<-new Point(200,235)


button2.Click.AddHandler(fun _ _ -> 
 let cl = form.Close()
 cl
 |> ignore)
//Добавление элементов на форму
form.Controls.Add(button)
form.Controls.Add(button1)
form.Controls.Add(button2)
form.Controls.Add(button3)
form.Controls.Add(button4)
form.Controls.Add(label1)
form.Controls.Add(label2)
form.Controls.Add(label3)
form.Controls.Add(label4)
form.Controls.Add(txtInputA)
form.Controls.Add(txtOutputB)
form.Controls.Add(txtOutputC)
form.Controls.Add(txtOutputD)
form.Controls.Add(txtOutputE)
//form.Controls.Add(txtOutputF)
//form.Controls.Add(txtOutputG)
// запуск формы
Application.Run(form)*)

open System
open System.Windows.Forms
open System.Drawing

Application.EnableVisualStyles()
// Создание формы с заголовком "Работа с массивом"
let form = new Form(Text="Работа с массивом")
// Создание подписи для поля ввода
let label1 = new Label()
label1.Location<-new Point(100,25) 
label1.Text<-"массив 1" 
label1.Width<-60 
label1.Height<-12 
 
// Создание подписи для поля вывода
let label2 = new Label()
label2.Location<-new Point(100,70)
label2.Text<-" массив 2"
label2.Width<-60
label2.Height<-12
let label3 = new Label()
label3.Location<-new Point(100,110)
label3.Text<-"массив 3"
label3.Width<-60
label3.Height<-12

// Создание текстового поля для ввода информации
let txtInputA = new TextBox()
txtInputA.Location<-new Point(170,25)
txtInputA.Width<-100
txtInputA.Height<-25
txtInputA.Text<-"" 
// Создание текстового поля для вывода информации
let txtOutputB = new TextBox()
txtOutputB.Location<-new Point(170,70)
txtOutputB.Width<-100
txtOutputB.Height<-25
txtOutputB.Text<-""
let txtOutputC = new TextBox()
txtOutputC.Location<-new Point(50,150)
txtOutputC.Width<-200
txtOutputC.Height<-25
txtOutputC.Text<-""

// Создание кнопки с текстом "Вычислить!"
let button = new Button(Text="Склеить")
button.Location<-new Point(15,25) // позиция кнопки

//Добавление обработчика события - Нажатие на кнопку
button.Click.AddHandler(fun _ _ -> 
 let array3 = txtInputA.Text + ", " + txtOutputB.Text
 txtOutputC.Text <- (array3 |> sprintf "%A")
 //let run = txtInputA.Text<- (array3 |> Seq.map string |> String.concat ", ")
 array3 |> ignore)




let button2 = new Button(Text="Выход")
button2.Location<-new Point(200,235)


button2.Click.AddHandler(fun _ _ -> 
 let cl = form.Close()
 cl
 |> ignore)

//Добавление элементов на форму
form.Controls.Add(button)

form.Controls.Add(button2)

form.Controls.Add(label1)
form.Controls.Add(label2)
form.Controls.Add(label3)

form.Controls.Add(txtInputA)
form.Controls.Add(txtOutputB)
form.Controls.Add(txtOutputC)

// запуск формы
Application.Run(form)