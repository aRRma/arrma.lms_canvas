﻿namespace arrma.lms_canvas.api_test.api_models.Courses
{
    /// <summary>
    /// Доп. параметры для включения в запрос Course
    /// </summary>
    enum CourseInclude
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
        /// Прогресс курса
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
        /// Общее количество студентов
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
    enum CourseState
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
    /// Тип зачисления (регистрации) на курсе
    /// </summary>
    enum CourseEnrollmentState
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
    /// Тип ролей зачисления (регистрации) на курсе
    /// </summary>
    enum CourseEnrollmentRole
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
        DESIGNER
    }
}