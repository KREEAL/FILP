
namespace WinformsFs
open WinformsFs.UiDesign

type StartupForm() as this = 
    inherit Form1()
    do
        this.button1.Click.Add <| fun _ -> this.label1.Text <- "Hello"