# Лабораторная работа
Разработать веб-приложение по теме ЖКХ с возможностью создания счетов, оплаты, расчета задолжностей.

## Механика работы программы
**Contract** - табличка contracts
**House** - табличка houses
**Charge** - табличка charges
**Payment** - табличка payments
**Saldo** - табличка saldos

1. Создается договор (Contract)
2. Добавляется номер квартиры и номер договора или изменяется номер договора у квартиры (House)
    1. Не может быть две квартиры с одним договором
    2. При изменении договора опять же не должно быть квартиры с таким же договором
3. Создается счет для оплаты с указанием квартиры (Charge). Счет имеет два важных поля: value и valueWithSaldo (данное поле является суммой value из Счета и value из Saldo).
    1. Счет может быть всего один для одного и того же месяца и года
    2. При изменении или удалении счета не должно быть произведено оплат (Payment)
    3. Если в предыдущем месяце имеется сальдо (Saldo), то оно добавляется к счету при оплате.
    4. Оплата происходит по valueWithSaldo.
4. Оплачивается счет
    1. Если счет оплачен полностью, то флаг completePayment становится true и больше производить оплату по данному счету нельзя
    2. Если счет оплачен частично, то можно оплачивать сколько угодно, пока флаг completePayment не станет true
    3. Счет за предыдущие месяца нельзя оплатить, долг или переплата перечисляется в виде сальдо на следующий месяц
    4. Можно оплатить сумму больше, чем в выставленном счете. Положительный (не до конца оплатити счет) или отрицательный (переплата) остаток пойдет в сальдо (Saldo)
5. Процедуры по выводу красивых таблиц в базе данных

## Что использовалось
    * C#
    * Postgresql
    * Entity Framework Core
    * ASP.NET Core
    * Swagger
    
## Схема базы данных
[![Base](/dataBase.jpg "Схема базы данных")](/dataBase.jpg)
