(*open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()
let form = new Form(Width=302, Height=350,Text = "Работа со списками")
let button1 = new Button(Left=21, Top=38, Text="вывод списка", Width=96, Height=23)
let button2 = new Button(Left=21, Top=81, Text="объединение списков", Width=96, Height=46)
let button3 = new Button(Left=21, Top=152, Text="добавления элемента всписок", Width=96, Height=55)
let button4 = new Button(Left=21, Top=244, Text="сортировка по возрастанию", Width=96, Height=43)
let textBox1 = new TextBox(Left=156, Top=38, Width=114, Height=20)
let textBox2 = new TextBox(Left=156, Top=107, Width=114, Height=20)
let textBox3 = new TextBox(Left=156, Top=187, Width=114, Height=20)
let textBox4 = new TextBox(Left=156, Top=267, Width=114, Height=20)
let textBox5 = new TextBox(Left=156, Text="a,b,c",Top=81, Width=46,Height=20)
let textBox6 = new TextBox(Left=222, Text="x,y,z",Top=81, Width=48, Height=20)
let textBox7 = new TextBox(Left=156, Text="0",Top=152, Width=25, Height=20)
let textBox8 = new TextBox(Left=200, Text="5,6,7,8,9,10",Top=152, Width=70, Height=20)
let textBox9 = new TextBox(Left=156, Text="1; 4; 8; -2; 5",Top=244, Width=114, Height=20)

 // Form1
 // 
form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize = new System.Drawing.Size(302, 314);
form.Controls.Add(textBox9);
form.Controls.Add(textBox8);
form.Controls.Add(textBox7);
form.Controls.Add(textBox6);
form.Controls.Add(textBox5);
form.Controls.Add(textBox4);
form.Controls.Add(textBox3);
form.Controls.Add(textBox2);
form.Controls.Add(textBox1);
form.Controls.Add(button4);

form.Controls.Add(button3);
form.Controls.Add(button2);
form.Controls.Add(button1);
form.Text = "Работа со списками";
form.ResumeLayout(false);
form.PerformLayout();

button1.Click.AddHandler(fun _ _ -> 
    let list1 = [for i in 1 .. 10 -> i * i ] 
    let run = textBox1.Text<- (list1 |> Seq.map string |> String.concat ", ")
    run 
    |> ignore)

button2.Click.AddHandler(fun _ _ -> 
    let list1 = ['a' ..'c' ] 
    let list2 = ['x' ..'z' ]
    let list3 = list1 @ list2 
    let run = textBox2.Text<- (list3 |> Seq.map string |> String.concat ", ")
    run 
    |> ignore)

button3.Click.AddHandler(fun _ _ -> 
    let list1 = [ 5 .. 10 ] 
    let list2 = int textBox7.Text :: list1 
    let run = textBox3.Text<- (list2 |> Seq.map string |> String.concat ", ")
    run 
    |> ignore)

button4.Click.AddHandler(fun _ _ -> 
    let list1 = List.sort [1; 4; 8; -2; 5] 
    let run = textBox4.Text<- (list1 |> Seq.map string |> String.concat ", ")
    run 
    |> ignore)


// запуск формы
Application.Run(form)*)
open System
open System.Windows.Forms
open System.Drawing
Application.EnableVisualStyles()
let form = new Form(Width=302, Height=350,Text = "Работа со списками")

let button2 = new Button(Left=21, Top=81, Text="объединение списков", Width=96, Height=46)
let textBox2 = new TextBox(Left=156, Top=107, Width=114, Height=20)
let textBox5 = new TextBox(Left=156, Text="a,b,c",Top=81, Width=46,Height=20)
let textBox6 = new TextBox(Left=222, Text="x,y,z",Top=81, Width=48, Height=20)

 // Form1
 // 
form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize = new System.Drawing.Size(302, 314);
form.Controls.Add(textBox6);
form.Controls.Add(textBox5);
form.Controls.Add(textBox2);
form.Controls.Add(button2);
form.Text = "Работа со списками";
form.ResumeLayout(false);
form.PerformLayout();

button2.Click.AddHandler(fun _ _ -> 
    let list1 = textBox5.Text
    let list2 = textBox6.Text
    let list3 = list1+ "," + list2 + ","+ textBox2.Text 
    let run = textBox2.Text<- list3
    run 
    |> ignore)




// запуск формы
Application.Run(form)