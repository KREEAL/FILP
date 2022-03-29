man(voeneg).
man(ratibor).
man(boguslav).
man(velerad).
man(duhovlad).
man(svyatoslav).
man(dobrozhir).
man(bogomil).
man(zlatomir).

woman(goluba).
woman(lubomila).
woman(bratislava).
woman(veslava).
woman(zhdana).
woman(bozhedara).
woman(broneslava).
woman(veselina).
woman(zdislava).

parent(voeneg,ratibor).
parent(voeneg,bratislava).
parent(voeneg,velerad).
parent(voeneg,zhdana).

parent(goluba,ratibor).
parent(goluba,bratislava).
parent(goluba,velerad).
parent(goluba,zhdana).

parent(ratibor,svyatoslav).
parent(ratibor,dobrozhir).
parent(lubomila,svyatoslav).
parent(lubomila,dobrozhir).

parent(boguslav,bogomil).
parent(boguslav,bozhedara).
parent(bratislava,bogomil).
parent(bratislava,bozhedara).

parent(velerad,broneslava).
parent(velerad,veselina).
parent(veslava,broneslava).
parent(veslava,veselina).

parent(duhovlad,zdislava).
parent(duhovlad,zlatomir).
parent(zhdana,zdislava).
parent(zhdana,zlatomir).

men:-man(X),write(X),nl,fail.
women:-woman(X),write(X),nl,fail.
%11
daughter(X):- parent(X,Y),woman(Y),write(Y),nl.
daughter(X,Y):-parent(Y,X),woman(X).
%12
wife(X):-man(X),parent(X,Z),parent(Y,Z),woman(Y),write(Y),nl,!.
wife(X,Y):-woman(X),man(Y),parent(X,Z),parent(Y,Z),write(yes),nl,!.
%13
grandMa(X,Y):-parent(X,Z),parent(Z,Y),woman(X),write(yes),nl,!.
grandMas(X):-parent(Z,X),parent(Y,Z),woman(Y),write(Y),nl.
%14
grandMaAndDa(X,Y):-parent(X,Z),parent(Z,Y),woman(Y),woman(X),write(yes),nl,fail;parent(Y,Z),parent(Z,X),woman(X),grandMa(Y,X),write(yes),nl,fail.
grand_pa_and_son(X,Y):-parent(X,Z),parent(Z,Y),man(X),man(Y),write(yes),nl,fail;parent(Y,Z),parent(Z,X),man(Y),man(X),write(yes),nl,fail.
