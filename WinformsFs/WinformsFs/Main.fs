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
    let mFile = form.Menu.MenuItems.Add("&Файл")
    let mForms = form.Menu.MenuItems.Add("&Формы")
    let mHelp = form.Menu.MenuItems.Add("&Помощь")
    // Подменю
    let miMessage = new MenuItem("Пример сообщения")
    let miSeparator = new MenuItem("-")
    let miExit = new MenuItem("&Выход")
    let miAbout = new MenuItem("&О программе...")
    let miForm1 = new MenuItem("&Форма_1")
    let miForm2 = new MenuItem("&Форма_2")
    let miForm3 = new MenuItem("&Форма_3")
    // Добавление подменю в пункты меню
    mFile.MenuItems.Add(miMessage)
    mFile.MenuItems.Add(miSeparator)
    mFile.MenuItems.Add(miExit)
    mHelp.MenuItems.Add(miAbout)
    mForms.MenuItems.Add(miForm1)
    mForms.MenuItems.Add(miForm2)
    mForms.MenuItems.Add(miForm3)
    // Создаем картинки и задаем им свойства
    let image1 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 
    5)
    let image2 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 
    5, Left = 133)
    let image3 = new PictureBox(SizeMode = PictureBoxSizeMode.AutoSize, Top = 
    5, Left = 266)
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
    let Label1 = new Label(Text="Пример вывода изображений на экран", 
    Top=150)
    Label1.Width <- form.Width
    Label1.Left <- 80
    form.Controls.Add(Label1)
    // Запускаем форму
    do Application.Run(form)


    Application.Run(form)    
    
    0 // return an integer exit code