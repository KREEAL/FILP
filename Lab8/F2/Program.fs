// Learn more about F# at http://fsharp.org

open System

type Maybe<'a> =
    | Just of 'a
    | Nothing 

//функтор 
let fmapMaybe f p =
    match p with
    | Just a -> Just (f a)
    | Nothing -> Nothing

//Аппликативный функтор
let applyMaybe fp p =
    match fp, p with
    |Just f, Just a -> Just (f a)
    |_-> Nothing   


//laws
let id x = x
let func_f x = x + 1
let func_g x = x * 2

[<EntryPoint>]
let main argv =
    
    let f1 = fmapMaybe (fun x-> x+1 ) (Just 2)
    Console.WriteLine(f1)

    let af1 = applyMaybe(Just(fun x->x+1))(Just 2)
    Console.WriteLine(af1)

    //laws checkout
    //Functor 
    //1.Пусть id – функция, которая возвращает неизменным значение аргумента. Тогда подъем этой функции в контекст не влияет на вычисление:
    Console.WriteLine (id f1)
    Console.WriteLine (fmapMaybe id f1)
    //2.Для двух функций f и g композиция их подъемов эквивалентна подъему композиции.
    let k1_1 = fmapMaybe func_f f1
    let k1_2 = fmapMaybe func_g k1_1
    let k2 = fmapMaybe(func_f >> func_g) f1
    Console.WriteLine("{0}, {1}",k1_2,k2)

    //Applicative functor
    //1.Identity.Применение поднятой функции id к поднятому значению эквивалентно применению неподнятой функции id к неподнятому значению.
    Console.WriteLine (id af1)
    Console.WriteLine(applyMaybe (Just id) af1)
    //2.Homomorphism Если y=f(x), то подъем функции f и значения х и применение к ним функции apply приведет к такому же результату, что и подъем y.
    let app_x = 1
    //let app_y = applyMaybe func_f app_x -нельзя проверить средставами F#
    let apl_y = applyMaybe (Just func_f) (Just app_x)
    Console.WriteLine("{0}",apl_y)
    //3.Закон 3 Аргументы apply можно менять местами.
    
    //4.Композиция функций apply ассоциативна. Из-за отсутствия встроенной функции <*> (apply) продемонстрировать проверку данного правила невозможно.


    0 // return an integer exit code
