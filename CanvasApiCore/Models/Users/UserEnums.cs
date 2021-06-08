namespace CanvasApiCore.Models.Users
{
    /// <summary>
    /// Доп. параметры для включения в запрос User
    /// </summary>
    public enum UserInclude
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Email
        /// </summary>
        EMAIL,
        /// <summary>
        /// Зачисления (в разделы на курсе)
        /// </summary>
        ENROLLMENTS,
        /// <summary>
        /// Заблокирован?
        /// </summary>
        LOCKED,
        /// <summary>
        /// Url аватарки
        /// </summary>
        AVATAR_URL,
        /// <summary>
        /// Тестовый студент
        /// </summary>
        TEST_STUDENT,
        /// <summary>
        /// О себе
        /// </summary>
        BIO,
        /// <summary>
        /// Кастомные ссылки
        /// </summary>
        CUSTOM_LINKS,
        /// <summary>
        /// Текущие показатели оценок
        /// </summary>
        CURRENT_GRADING_PERIOD_SCORES,
    }

    /// <summary>
    /// Тип зачисления пользователя
    /// </summary>
    public enum UserEnrollmentType
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Вид с позиции студента
        /// </summary>
        STUDENT_VIEW,
        /// <summary>
        /// Студент
        /// </summary>
        STUDENT = 3,
        /// <summary>
        /// Преподаватель
        /// </summary>
        TEACHER = 4,
        /// <summary>
        /// Ассистент
        /// </summary>
        TA = 5,
        /// <summary>
        /// Наблюдатель
        /// </summary>
        OBSERVER,
        /// <summary>
        /// Дизайнер курса
        /// </summary>
        DESIGNER
    }

    /// <summary>
    /// Статус зачисления пользователя
    /// </summary>
    public enum UserEnrollmentState
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Активен
        /// </summary>
        ACTIVE,
        /// <summary>
        /// Приглашен
        /// </summary>
        INVITED,
        /// <summary>
        /// Отклонено
        /// </summary>
        REJECTED,
        /// <summary>
        /// Завершено
        /// </summary>
        COMPLETED,
        /// <summary>
        /// Не активен
        /// </summary>
        INACTIVE
    }
}
