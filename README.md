
Проект: Система управління замовленнями з використанням послуг і виконавців
Компоненти проекту:
ASP.NET Core API:
Створення контролерів для операцій створення, перегляду, оновлення та видалення замовлень, клієнтів, виконавців та послуг.
Реалізація ендпойнтів для отримання інформації про замовлення, їх статус, інформацію про клієнтів та виконавців.
SQL Server та Entity Framework:
Розробка бази даних для збереження інформації про замовлення, клієнтів, виконавців та послуги.
Використання Entity Framework для зручного взаємодії з базою даних.
Аутентифікація та авторизація:
Застосування JWT для аутентифікації користувачів системи.
Реалізація механізму авторизації для забезпечення доступу тільки авторизованим користувачам.
Swagger:
Додати документацію API за допомогою Swagger.

Моделі даних
Замовлення (Order):
OrderId (ідентифікатор замовлення)
CustomerId (ідентифікатор клієнта)
ExecutorId (ідентифікатор виконавця)
Status (статус замовлення: "В обробці", "Відправлено", "Доставлено" і т.д.)
TotalAmount (загальна сума замовлення)
OrderDate (дата оформлення замовлення)
Клієнт (Customer):
CustomerId (ідентифікатор клієнта)
Name (ім'я клієнта)
Email (електронна пошта клієнта)
Address (адреса доставки)
Виконавець (Executor):
ExecutorId (ідентифікатор виконавця)
Name (ім'я виконавця)
Email (електронна пошта виконавця)
Послуги (Service):
ServiceId (ідентифікатор послуги)
Name (назва послуги)
Description (опис послуги)
Price (вартість послуги)
Деталі замовлення (OrderDetail):
OrderDetailId (ідентифікатор деталі замовлення)
OrderId (посилання на замовлення)
ServiceId (посилання на послугу)
Quantity (кількість послуг в замовленні)