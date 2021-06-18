namespace CanvasApiCore.Models
{
    /// <summary>
    /// Доп. параметры для включения в запрос Course
    /// </summary>
    public enum CourseInclude
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Сколько заданий требуется оценить
        /// </summary>
        NEEDS_GRADING_COUNT,
        /// <summary>
        /// Html странница программы курса
        /// </summary>
        SYLLABUS_BODY,
        /// <summary>
        /// Описания курса
        /// </summary>
        PUBLIC_DESCRIPTION,
        /// <summary>
        /// Общую статистика оценок по всем заданиям
        /// </summary>
        TOTAL_SCORES,
        /// <summary>
        /// Общую статистику оценок на текущий момент???
        /// </summary>
        CURRENT_GRADING_PERIOD_SCORES,
        /// <summary>
        /// Информация о сроках и статусе курса
        /// </summary>
        TERM,
        /// <summary>
        /// Прогресс курса (только для модульных курсов)
        /// </summary>
        COURSE_PROGRESS,
        /// <summary>
        /// Информация об разделах
        /// </summary>
        SECTIONS,
        /// <summary>
        /// Квота обьема памяти на курсе
        /// </summary>
        STORAGE_QUOTA_USED_MD,
        /// <summary>
        /// Общее количество студентов (активных и приглашенных)
        /// </summary>
        TOTAL_STUDENTS,
        /// <summary>
        /// Состояние пароля
        /// </summary>
        PASSBACK_STATUS,
        /// <summary>
        /// Избранный ли данный курс для пользователя
        /// </summary>
        FAVORITES,
        /// <summary>
        /// Список преподавателей на курсе
        /// </summary>
        TEACHERS,
        /// <summary>
        /// Список наблюдателей на курсе
        /// </summary>
        OBSERVED_USERS,
        /// <summary>
        /// Включая удаленные курсы (только для запроса одного курса)
        /// </summary>
        ALL_COURSES,
        /// <summary>
        /// Разрешения текущего пользователя на курс (только для запроса одного курса)
        /// </summary>
        PERMISSIONS,
        /// <summary>
        /// картинка курса
        /// </summary>
        COURSE_IMAGE
    }

    /// <summary>
    /// Состояние курса
    /// </summary>
    public enum CourseState
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Не опубликован
        /// </summary>
        UNPUBLISHED,
        /// <summary>
        /// Опубликован
        /// </summary>
        AVAILABLE,
        /// <summary>
        /// Завершен
        /// </summary>
        COMPLETED,
        /// <summary>
        /// Удален
        /// </summary>
        DELETED
    }

    /// <summary>
    /// Состояние регистрации пользователя на курсе
    /// </summary>
    public enum CourseUserEnrollmentState
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
        /// Приглашен или в ожидании
        /// </summary>
        INVITED_OR_PENDING,
        /// <summary>
        /// Завершено
        /// </summary>
        COMPLETED
    }

    /// <summary>
    /// Тип роли регистрации пользователя на курсе
    /// </summary>
    public enum CourseUserEnrollmentType
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
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
        DESIGNER,
        /// <summary>
        /// Вид с позиции студента 
        /// </summary>
        STUDENT_VIEW
    }

    /// <summary>
    /// Тип страницы по умолчанию для курса
    /// </summary>
    public enum CourseDefaultView
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Лента активности курса
        /// </summary>
        FEED,
        /// <summary>
        /// Вики (Страницы титульной страницы)
        /// </summary>
        WIKI,
        /// <summary>
        /// Модули курса
        /// </summary>
        MODULES,
        /// <summary>
        /// Программа обучения
        /// </summary>
        SYLLABUS,
        /// <summary>
        /// Список заданий
        /// </summary>
        ASSIGNMENTS
    }
}