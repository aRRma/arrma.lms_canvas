﻿namespace arrma.lms_canvas.api_test.api_models.Assignments
{
    /// <summary>
    /// Доп. параметры для включения в запрос Assignment
    /// </summary>
    enum AssignmentInclude
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Видимость задания
        /// </summary>
        ASSIGNMENT_VISIBILITY,
        /// <summary>
        /// Cроки задания для всех разделов
        /// </summary>
        ALL_DATES,
        /// <summary>
        /// Переопределения заданий
        /// </summary>
        OVERRIDES
    }

    /// <summary>
    /// Доп. параметр для включения в запрос Assignment определенных заданий в зависимости от срока и статуса отправки
    /// </summary>
    enum AssignmentBucket
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// Прошедшее
        /// </summary>
        PAST,
        /// <summary>
        /// Просроченное
        /// </summary>
        OVERDUE,
        /// <summary>
        /// Вне даты
        /// </summary>
        UNDATED,
        /// <summary>
        /// Не проверено
        /// </summary>
        UNGRADED,
        /// <summary>
        /// Не отправлено
        /// </summary>
        UNSUBMITTED,
        /// <summary>
        /// Предстоящее
        /// </summary>
        UPCOMING,
        /// <summary>
        /// Будущее
        /// </summary>
        FUTURE
    }

    /// <summary>
    /// Доп. параметр для включения в запрос Assignment типа сортировки заданий
    /// </summary>
    enum AssignmentOrderBy
    {
        /// <summary>
        /// Не известно
        /// </summary>
        NONE,
        /// <summary>
        /// По имени
        /// </summary>
        NAME,
        /// <summary>
        /// По позиции
        /// </summary>
        POSITIONS
    }
}
