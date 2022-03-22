(*open System.Drawing
open System.Windows.Forms

let form = new Form(
 Width= 373, Height = 266, 
 Visible = true, 
 Text = "Кортежи в F#", 
 Menu = new MainMenu()
 )

let button1 = new Button(Text="Сумма", Left=10, Top=9, Width=75,Height=23)
let button2 = new Button(Text="Произведение", Left=91, Top=9, Width=108, Height=23)
let button3 = new Button(Text="Разность", Left=205, Top=9, Width=75, Height=23)
let button4 = new Button(Text="Деление", Left=286, Top=9, Width=75, Height=23)
let textBox1 = new TextBox(Text="0", Left=10, Top=55, Width=55, Height=20)
let textBox2 = new TextBox(Text="0", Left=71, Top=55, Width=55, Height=20)
let textBox3 = new TextBox(Text="0", Left=151, Top=55, Width=55, Height=20)
let textBox4 = new TextBox(Text="0", Left=212, Top=55, Width=55, Height=20)
let label1 = new Label(Text="?", Left=132, Top=58, Width=13, Height=13)
let label2 = new Label(Text="a", Left=31, Top=39, Width=13, Height=13)
let label3 = new Label(Text="bi", Left=88, Top=39, Width=13, Height=13)
let label4 = new Label(Text="c", Left=171, Top=39, Width=13, Height=13)
let label5 = new Label(Text="di", Left=233, Top=39, Width=13, Height=13)
let button5 = new Button(Text="=", Left=273, Top=53, Width=32, Height=23)
let label6 = new Label(Text="0", Left=311, Top=58, Width=60, Height=13)
let label7 = new Label(Text="Модуль комплексного числа a+bi", Left=10, Top=85, Width=250, Height=13)
let label8 = new Label(Text="a", Left=31, Top=100, Width=10, Height=13)
let label9 = new Label(Text="b", Left=88, Top=100, Width=10, Height=13)
let textBox5 = new TextBox(Text="0", Left=10, Top=120, Width=55, Height=20)
let textBox6 = new TextBox(Text="0", Left=70, Top=120, Width=55, Height=20)
let button6 = new Button(Text="=", Left=130, Top=119, Width=32, Height=23)
let label10 = new Label(Text="0", Left=170, Top=122, Width=100, Height=13)
let label11 = new Label(Text="Аргумент комплексного числа", Left=10, Top=150, Width=290, Height=13)
let label12 = new Label(Text="Im", Left=30, Top=163, Width=30, Height=13)
let label13 = new Label(Text="Re", Left=87, Top=163, Width=30, Height=13)
let textBox7 = new TextBox(Text="0", Left=10, Top=180, Width=55, Height=20)
let textBox8 = new TextBox(Text="0", Left=70, Top=180, Width=55, Height=20)
let button7 = new Button(Text="=", Left=130, Top=179, Width=32, Height=23)

let label14 = new Label(Text="Градусы = 0", Left=170, Top=182, Width=100, Height=13)
form.Controls.Add(label14)
form.Controls.Add(button7)
form.Controls.Add(textBox8)
form.Controls.Add(textBox7)
form.Controls.Add(label13)
form.Controls.Add(label12)
form.Controls.Add(label11)
form.Controls.Add(label10)
form.Controls.Add(button6)
form.Controls.Add(textBox6)
form.Controls.Add(textBox5)
form.Controls.Add(label9)
form.Controls.Add(label8)
form.Controls.Add(label7)
form.Controls.Add(label6)
form.Controls.Add(button5)
form.Controls.Add(label5)
form.Controls.Add(label4)
form.Controls.Add(label3)
form.Controls.Add(label2)
form.Controls.Add(label1)
form.Controls.Add(textBox4)
form.Controls.Add(textBox3)
form.Controls.Add(textBox2)
form.Controls.Add(textBox1)


let contextMenuStrip1 = new ContextMenuStrip()
let toolStrip1 = new ToolStripMenuItem("+ (Сумма)")
let toolStrip2 = new ToolStripMenuItem("- (Разность)")
let toolStrip3 = new ToolStripMenuItem("* (Произведение)")
let toolStrip4 = new ToolStripMenuItem("/ (Деление)")

contextMenuStrip1.Items.Add(toolStrip1)
contextMenuStrip1.Items.Add(toolStrip2)
contextMenuStrip1.Items.Add(toolStrip3)
contextMenuStrip1.Items.Add(toolStrip4)
label1.ContextMenuStrip <- contextMenuStrip1


let krt _ = label1.Text <- "+"
let _ = toolStrip1.Click.Add(krt)
//////////////////////////////////////////////////////////////
let umn _ =label1.Text <- "*"
let _ = toolStrip3.Click.Add(umn)
//////////////////////////////////////////////////////////////
let raz _ =label1.Text <- "-"
let _ = toolStrip2.Click.Add(raz)
//////////////////////////////////////////////////////////////
let delenie _ =label1.Text <- "/"
let _ = toolStrip4.Click.Add(delenie)
//////////////////////////////////////////////////////////////

let ravno _ = 
    match label1.Text with
    |"/" ->
        let del (a, b) (c, d) =
            let znam = c*c + d*d
            let dei = ((a*c + b*d)/znam)
            let mni = ((-a*d + b*c)/znam)
            (dei , mni)
        let d1 = (float textBox1.Text, float textBox2.Text)
        let d2 = (float textBox3.Text, float textBox4.Text)
        let d3 = del d1 d2 
        label6.Text <- string d3
    |"+" ->
        let summ (r1, i1) (r2, i2) = 
            let dei = r1 + r2
            let mni = i1 + i2
            (dei , mni)
        let s1 = (float textBox1.Text, float textBox2.Text)
        let s2 = (float textBox3.Text, float textBox4.Text)
        let s3 = summ s1 s2
        label6.Text <- string s3
    |"-" ->
        let raznost (a, b) (c, d) =
            let dei = a - c
            let mni = b - d
            (dei , mni)
        let r1 = (float textBox1.Text, float textBox2.Text)
        let r2 = (float textBox3.Text, float textBox4.Text)
        let r3 = raznost r1 r2 
        label6.Text <- string r3
    |"*" ->
        let umnoj ((a:float), b:float) (c:float, d:float) =
            let dei = (a*c) - (b*d)
            let mni = (a*d) + (b*c)
            (dei , mni)
        let u1 = (float textBox1.Text, float textBox2.Text)
        let u2 = (float textBox3.Text, float textBox4.Text)
        let u3 = umnoj u1 u2 
        label6.Text <- string u3

let _ = button5.Click.Add(ravno)

let modul _ = 
    let mo = sqrt((float textBox5.Text*float textBox5.Text)+(float textBox6.Text*float textBox6.Text)) 
    label10.Text <- string mo
let _ = button6.Click.Add(modul)
let arg _ = 
    let x = float textBox7.Text
    let y = float textBox8.Text
    let ar = atan(x/y)
    let grad = (ar*180.0)/3.14159265
    label14.Text <- "Градусы = "+string grad
let _ = button7.Click.Add(arg)

do Application.Run(form)*)

open System.Drawing
open System.Windows.Forms

let form = new Form(
 Width= 373, Height = 160, 
 Visible = true, 
 Text = "Кортежи в F#", 
 Menu = new MainMenu()
 )

let button1 = new Button(Text="Сумма", Left=10, Top=9, Width=75,Height=23)
let button2 = new Button(Text="Произведение", Left=91, Top=9, Width=108, Height=23)
let button3 = new Button(Text="Разность", Left=205, Top=9, Width=75, Height=23)
let button4 = new Button(Text="Деление", Left=286, Top=9, Width=75, Height=23)
let textBox1 = new TextBox(Text="0", Left=10, Top=55, Width=55, Height=20)
let textBox2 = new TextBox(Text="0", Left=71, Top=55, Width=55, Height=20)

let label1 = new Label(Text="?", Left=132, Top=58, Width=13, Height=13)
let label2 = new Label(Text="a", Left=31, Top=39, Width=13, Height=13)
let label3 = new Label(Text="b", Left=88, Top=39, Width=13, Height=13)

let button5 = new Button(Text="=", Left=160, Top=53, Width=32, Height=23)
let label6 = new Label(Text="0", Left=198, Top=58, Width=60, Height=13)


form.Controls.Add(label6)
form.Controls.Add(button5)
form.Controls.Add(label3)
form.Controls.Add(label2)
form.Controls.Add(label1)

form.Controls.Add(textBox2)
form.Controls.Add(textBox1)


let contextMenuStrip1 = new ContextMenuStrip()
let toolStrip1 = new ToolStripMenuItem("+ (Сумма)")
let toolStrip2 = new ToolStripMenuItem("- (Разность)")
let toolStrip3 = new ToolStripMenuItem("* (Произведение)")
let toolStrip4 = new ToolStripMenuItem("/ (Деление)")

contextMenuStrip1.Items.Add(toolStrip1)
contextMenuStrip1.Items.Add(toolStrip2)
contextMenuStrip1.Items.Add(toolStrip3)
contextMenuStrip1.Items.Add(toolStrip4)
label1.ContextMenuStrip <- contextMenuStrip1


let krt _ = label1.Text <- "+"
let _ = toolStrip1.Click.Add(krt)
//////////////////////////////////////////////////////////////
let umn _ =label1.Text <- "*"
let _ = toolStrip3.Click.Add(umn)
//////////////////////////////////////////////////////////////
let raz _ =label1.Text <- "-"
let _ = toolStrip2.Click.Add(raz)
//////////////////////////////////////////////////////////////
let delenie _ =label1.Text <- "/"
let _ = toolStrip4.Click.Add(delenie)
//////////////////////////////////////////////////////////////

let ravno _ = 
    if fst ( textBox1.Text, textBox2.Text) = "" || snd (textBox1.Text,textBox2.Text) = "" then label6.Text <- "Оишбка" 
    else
        match label1.Text with
        |"/" ->
            let del (a:double, b:double) =
                let res = 
                    if b = 0.0 then 0.0 else System.Convert.ToDouble(a/b)
                res
            let d1 = (double textBox1.Text, double textBox2.Text)
            let d3 = del d1  
            label6.Text <- string d3
        |"+" ->
            let sum (a, b) =
                let res = a+b
                res
            let d1 = (float textBox1.Text, float textBox2.Text)
            let d3 = sum d1  
            label6.Text <- string d3
        |"-" ->
            let raznost (a, b) =
                let res = a - b
                res
            let r1 = (float textBox1.Text, float textBox2.Text)
            let r3 = raznost r1 
            label6.Text <- string r3
        |"*" ->
            let umnoj (a, b) =
                let res = a * b
                res
            let u1 = (float textBox1.Text, float textBox2.Text)
            let u3 = umnoj u1 
            label6.Text <- string u3

let _ = button5.Click.Add(ravno)


do Application.Run(form)