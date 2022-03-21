module WinformsFs.Main

open System
open System.Windows.Forms

[<EntryPoint; STAThread>]
let main argv =
    Application.EnableVisualStyles()
    Application.SetCompatibleTextRenderingDefault(false)
    use form = new StartupForm()

    let form = new Form(Width= 400, Height = 300, Text = "F# Главная форма", 
    Menu = new MainMenu())
    // Меню бар 
    let mFile = form.Menu.MenuItems.Add("Файл")
    let mForms = form.Menu.MenuItems.Add("Формы")
    let mHelp = form.Menu.MenuItems.Add("Помощь")
    // Подменю
    let miMessage = new MenuItem("Пример сообщения")
    let miSeparator = new MenuItem("-")
    let miExit = new MenuItem("Выход")
    let miAbout = new MenuItem("О программе...")
    let miForm1 = new MenuItem("Форма_1")
    let miForm2 = new MenuItem("Форма_2")
    let miForm3 = new MenuItem("Форма_3")
    // Добавление подменю в пункты меню
    mFile.MenuItems.Add(miMessage)
    mFile.MenuItems.Add(miSeparator)
    mFile.MenuItems.Add(miExit)
    mHelp.MenuItems.Add(miAbout)
    mForms.MenuItems.Add(miForm1)
    mForms.MenuItems.Add(miForm2)
    mForms.MenuItems.Add(miForm3)
    // Создаем картинки и задаем им свойства
    let image1 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 5)
    let image2 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 5, Left = 133)
    let image3 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 5, Left = 266)
    //Скопируем картинки в папку с программой здесь это: 1.png, 2.phg, 3.png.
    // Указываем местоположение картинок
    image1.ImageLocation <- "1.PNG"
    image2.ImageLocation <- "2.PNG"
    image3.ImageLocation <- "3.PNG"
    // Добавляем картинки на форму
    form.Controls.Add(image1)
    form.Controls.Add(image2)
    form.Controls.Add(image3)
    // Создаём и добавляем надпись на форму
    let Label1 = new Label(Text="Пример вывода изображений на экран", Top=150)
    Label1.Width <- form.Width
    Label1.Left <- 80
    form.Controls.Add(Label1)

    let Msg _ = MessageBox.Show("Пример сообщения в F#!", "Сообщение") |> ignore
    // Событие на нажатие пункта меню
    let _ = miMessage.Click.Add(Msg)
    // Закрытие приложения
    let Exit _ = form.Close ()
    let _ = miExit.Click.Add(Exit)



    //Форма_1
    let Form1 = new Form(Text = "Дочерняя форма №1" ,Width = 400, Height = 300)
    let Edit1 = new TextBox(Text="10")
    let Edit2 = new TextBox(Top=20, Text="5")
    let button1 = new Button(Text="+", Top=50, Width=25, Height=25)
    let button2 = new Button(Text="-", Top=50, Left=30, Width=25, Height=25)
    let button3 = new Button(Text="*", Top=50, Left=60, Width=25, Height=25)
    let button4 = new Button(Text="/", Top=50, Left=90, Width=25, Height=25)
    Form1.Controls.Add(Edit1)
    Form1.Controls.Add(Edit2)
    Form1.Controls.Add(button1)
    Form1.Controls.Add(button2)
    Form1.Controls.Add(button3)
    Form1.Controls.Add(button4)
    //let Summ_ = MessageBox.Show(string(int(Edit1.Text) + (int(Edit2.Text))), "Сумма") |>ignore
    //let Minus_ = MessageBox.Show(string(int(Edit1.Text) - (int(Edit2.Text))), "Разность") |>ignore
    //let Umnoj_ = MessageBox.Show(string(int(Edit1.Text) * (int(Edit2.Text))), "Умножение") |>ignore
    //let Del_ = MessageBox.Show(string(int(Edit1.Text)/ (int(Edit2.Text))), "Деление") |> ignore
    //вместо этих длинных штук должны быть Summ_ и тд но оно не работает
    let _ = button1.Click.Add((fun (e:EventArgs) -> (MessageBox.Show(string(int(Edit1.Text) + (int(Edit2.Text))), "Сумма") |>ignore)))
    let _ = button2.Click.Add((fun e -> (MessageBox.Show(string(int(Edit1.Text) - (int(Edit2.Text))), "Разность") |>ignore)))
    let _ = button3.Click.Add((fun e -> (MessageBox.Show(string(int(Edit1.Text) * (int(Edit2.Text))), "Умножение") |>ignore)))
    let _ = button4.Click.Add((fun e -> (MessageBox.Show(string(int(Edit1.Text)/ (int(Edit2.Text))), "Деление") |> ignore)))

    //Форма_2
    let Form2 = new Form(Width= 400, Height = 300, Text = "Дочерняя форма №2")
    let ProgressBar1 = new ProgressBar(Dock=DockStyle.Top)
    let ScrollBar1 = new TrackBar(Top = 50, Maximum = 100, Width = 400)
    let Button1 = new Button(Dock=DockStyle.Bottom, Text="Перейти на форму 3")
    Form2.Controls.Add(ProgressBar1)
    Form2.Controls.Add(ScrollBar1)
    Form2.Controls.Add(Button1)
    let Change _ = ProgressBar1.Value <- ScrollBar1.Value
    let _ = ScrollBar1.ValueChanged.Add(Change)

    //Форма_3
    let Form3 = new Form(Text = "Дочерняя форма №3" ,Width = 400, Height = 300) 
    let Cal = new MonthCalendar()
    let Button2 = new Button(Dock=DockStyle.Bottom, Text="Нажми меня")
    Form3.Controls.Add(Cal)
    Form3.Controls.Add(Button2)
    //let MsgDay_ = MessageBox.Show ("Сегодня "+string DateTime.Today, "Дата") |> ignore
    let _ = Button2.Click.Add((fun e ->(MessageBox.Show ("Сегодня "+string DateTime.Today, "Дата") |> ignore)))

    //Вызов форм
    let opForm1 _ = do Form1.ShowDialog() //|> ignore
    let opForm2 _ = do Form2.ShowDialog() //|> ignore
    let opForm3 _ = do Form3.ShowDialog() //|> ignore
    //
    let _ = miForm1.Click.Add(opForm1)
    let _ = miForm2.Click.Add(opForm2)
    let _ = miForm3.Click.Add(opForm3)
    let _ = Button1.Click.Add(opForm3)



    // Запускаем форму
    do Application.Run(form)

    // Создание сообщения
    


    //Application.Run(form)    
    
    0 // return an integer exit code