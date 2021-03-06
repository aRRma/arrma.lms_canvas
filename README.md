# CanvasApiCore
Проект для работы с API платформы электронного обучения LMS Canvas.

```
[Repo]: https://github.com/instructure/canvas-lms
[Doc]: https://canvas.instructure.com/doc/api/
```



Для обращения к серверу нужно иметь на нем аккаунт и сгенерировать специальный token. 

```
[Guide]: https://community.canvaslms.com/t5/Admin-Guide/How-do-I-manage-API-access-tokens-as-an-admin/ta-p/89 
[Swagger]: https://lms.misis.ru//doc/api/live
```



В зависимости от уровня вашего аккаунта (администратор, преподаватель, студент и тд.) вы имеете право на выполнение тех или иных запросов к серверу.

Реализованы базовые методы для запроса:

- описание, профиль пользователя;
- представления задания студента;
- списка курсов для текущего пользователя;
- списка курсов для конкретного пользователя;
- списка пользователей на курсе;
- списка заданий на курсе;
- списка групп заданий;

Все реализованные запросы к серверу можно параметризировать дополнительными параметрами.



# CanvasEFCore

Проект для работы с базой данных для проекта CanvasApiCore. Используется ORM Entity Framework Core.
